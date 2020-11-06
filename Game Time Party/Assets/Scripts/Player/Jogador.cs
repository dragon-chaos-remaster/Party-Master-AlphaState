using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Jogador",menuName = "Jogador")]
public class Jogador : ScriptableObject
{
    public string nomeDoPersonagem;
    public string descricaoDoPersonagem;

    
    public CharacterMovement movimentoDoPersonagem;

    public int pontuacao;
}
