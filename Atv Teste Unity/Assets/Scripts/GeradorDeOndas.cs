using UnityEngine;

public class GeradorDeOndas : MonoBehaviour
{
    GameObject inimigoPrefab;
    Vector3 posicao;
    string[] nomes = {"Jorge", "Carlos", "Marcos"};

    float vida = 100f;
    void Start()
    {
        posicao = Vector3.zero;
        for(int i = 0; i < 5; i++)
        {
            Instantiate(inimigoPrefab, posicao, Quaternion.identity);
            posicao.x += 3;
            Debug.Log($"Inimigo {i + 1} criado em {posicao}");
        }

        while(vida > 0f)
        {
            vida -= 10f;
            Debug.Log("-10 de vida.");
        }
        Debug.Log("Inimigo Morreu!");

        foreach(string nome in nomes)
        {
            Debug.Log($"Inimigo encontrado: {nome}");
        }
    }
}
