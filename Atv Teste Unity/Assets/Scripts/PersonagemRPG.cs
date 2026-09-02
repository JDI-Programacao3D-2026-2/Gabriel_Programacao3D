using UnityEngine;

public class PersonagemRPG : MonoBehaviour
{
    string nome;
    int vida;
    float velocidade;
    int nivel;
    bool estaVivo;

    const int VIDA_MAXIMA = 100;
    const float GRAVIDADE = 9.81f;

    void Start()
    {
        nome = "Jorge";
        vida = 100;
        velocidade = 5f;
        nivel = 1;
        estaVivo = true;

        string status = estaVivo ? "Vivo" : "Morto";
        string msg2 = $"=== Ficha do Personagem === Nome: {nome} | Nível: {nivel} Vida: {vida}/{VIDA_MAXIMA} | Velocidade: {(int)velocidade} Status: {status}";

        Debug.Log(msg2);
        vida = 50;

        msg2 = $"=== Ficha do Personagem === Nome: {nome} | Nível: {nivel} Vida: {vida}/{VIDA_MAXIMA} | Velocidade: {(int)velocidade} Status: {status}";

        Debug.Log(msg2);
    }
}
