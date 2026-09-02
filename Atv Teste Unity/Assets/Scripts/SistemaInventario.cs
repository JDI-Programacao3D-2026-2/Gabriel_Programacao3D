using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SistemaInventario : MonoBehaviour
{
    List<string> items = new List<string>();
    void AdicionarItem(string item)
    {
        items.Add(item);
        Debug.Log($"Adicionado: {item}| Total: {items.Count}");
    }
    void RemoverItem(string item)
    {
        if(items.Count > 0)
        {
            items.Remove(item);
            Debug.Log($"Removendo: {item}");
        }
        else
        {
            Debug.Log("Nenhum Abacate armazenado...");
        }
    }
    bool TemItem(string item)
    {
        foreach(string it in items)
        {
            if (it == item)
            {
                return true;
            } 
        }
        return false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
           AdicionarItem("abacate"); 
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
           RemoverItem("abacate"); 
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
           MostrarInventario(); 
        }
    }

    void MostrarInventario()
    {
        Debug.Log("=== INVENTARIO ===");
        foreach(string it in items)
        {
            Debug.Log($"- {it}");
        }
        Debug.Log("===            ===");
    }
}
