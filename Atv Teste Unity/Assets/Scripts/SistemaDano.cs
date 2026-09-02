using UnityEngine;

public class SistemaDano : MonoBehaviour
{
    public string tipoAtaque = "Fogo";
    int danoBase = 20;
    float multi;

    void Start()
    {
        switch (tipoAtaque)
        {
            case "Fogo": multi = 2f;break;
            case "Gelo": multi = 1.5f;break;
            case "Raio": multi = 3f;break;
        }
        Debug.Log($"Dano final: {danoBase * multi}");
    }
}
