using UnityEngine;

public class CalculadoraDano : MonoBehaviour
{
    int ataque = 25;
    int defesa = 10;
    float multiplicador = 1.5f;
    float vidaRestante = 100f;

    float danoReal;

    void Start()
    {
        danoReal = (ataque - defesa) * multiplicador;
        CausarDano();
    }

    void CausarDano()
    {
        for (int i = 0; i < 3; i++)
        {
            string dan =  danoReal > 20 ? "Dano Massivo!" : "";
            vidaRestante -= danoReal;
            string msg2 = $"=== Turno {i+1} === Dano real: {danoReal} | {dan} Vida restante: {vidaRestante}";
            Debug.Log(msg2);
        }
    }
}
