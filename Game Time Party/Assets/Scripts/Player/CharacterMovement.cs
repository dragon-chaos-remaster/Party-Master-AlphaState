using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ControlTypes { GAMEPAD_CONTROLLER, KEYBOARD_PC }
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 15f, jumpForce = 400f;
    CharacterController characterController;

    [SerializeField] float turnSmoothTime = 0.15f;
    [SerializeField] bool apenasNaHorizontal, apenasNaVertical;

    float turnSmoothVelocity;
    //Input input;
    //[SerializeField] Transform cam;
    Vector3 playerMovement;

    Vector3 direcaoDeMovimento;

    PlayerActions controls;
    [SerializeField] ControlTypes controlTypes;
    bool PC;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        controls = new PlayerActions();
        switch (controlTypes)
        {
            case ControlTypes.GAMEPAD_CONTROLLER:
                controls.Gameplay.Move.performed += ctx => Movement();
                break;
            case ControlTypes.KEYBOARD_PC:
                PC = true;
                break;
        }
        

       
    }

    //void CheckMovementConditions(float xAxis,float zAxis)
    //{
    //    if (apenasNaHorizontal && !apenasNaVertical)
    //    {
    //        zAxis = 0f;
    //        direcaoDeMovimento = new Vector3(xAxis, 0f, zAxis).normalized;
    //    }
    //    else if (apenasNaVertical && !apenasNaHorizontal)
    //    {
    //        xAxis = 0f;
    //        direcaoDeMovimento = new Vector3(xAxis, 0f, zAxis).normalized;
    //    }
    //}

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    void Update()
    {
        if (PC)
        {
            Movement();
        }
    }
    void Movement()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
     
        if (apenasNaHorizontal && !apenasNaVertical)
        {
            //zAxis = 0f;
            direcaoDeMovimento = new Vector3(xAxis, 0f, 0).normalized;
        }
        else if (apenasNaVertical && !apenasNaHorizontal)
        {
            //xAxis = 0f;
            direcaoDeMovimento = new Vector3(0f, 0f, zAxis).normalized;
        }
        else
        {
            direcaoDeMovimento = new Vector3(xAxis, 0f, zAxis).normalized;
        }

        if (direcaoDeMovimento.magnitude >= 0.1f)
        {
            float anguloDeVisao = Mathf.Atan2(direcaoDeMovimento.x, direcaoDeMovimento.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float anguloDeRotacao = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloDeVisao, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, anguloDeRotacao, 0f);

            playerMovement = Quaternion.Euler(0f, anguloDeVisao, 0f) * Vector3.forward;
            characterController.Move(playerMovement.normalized * playerSpeed * Time.deltaTime);
        }
    }
}
