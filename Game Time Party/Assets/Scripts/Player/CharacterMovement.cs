﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ControlTypes { GAMEPAD_CONTROLLER, KEYBOARD_PC }
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 15f;
    CharacterController characterController;
    [SerializeField] float forcaDoPulo = 10f;


    [SerializeField] bool estaNoChao;

    [SerializeField] float turnSmoothTime = 0.15f;
    [SerializeField] bool apenasNaHorizontal, apenasNaVertical;

    float turnSmoothVelocity;

    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;
    [SerializeField] Transform groundChecker;
    [SerializeField] float raioDoPulo = 4f;
    
    [SerializeField] LayerMask groundLayer;
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
        characterController.detectCollisions = false;
        //characterController.isTrigger = true;
        Cursor.lockState = CursorLockMode.Locked;
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
    public void Pular()
    {
        estaNoChao = Physics.CheckSphere(groundChecker.position, raioDoPulo,groundLayer);
        if(estaNoChao && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        //velocity.y += gravity * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            velocity.y = Mathf.Sqrt(forcaDoPulo * -2f * gravity);
        }
        //gravidade
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
    public void Movement()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Pular();
        //print(estaNoChao);
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
