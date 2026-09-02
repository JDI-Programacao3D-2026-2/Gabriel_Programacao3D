using UnityEngine;
using System.Collections.Generic;

public class SistemaNotas : MonoBehaviour
{
    List<float> notas =  new List<float>();

    void AdicionarNota(float nota)
    {
        notas.Add(nota);
        Debug.Log($"Nota adicionada: {nota} | Total: {notas.Count}");
    }
    float CalcularMedia()
    {
        float notaTotal = 0f;
        foreach(float nota in notas)
        {
            notaTotal+=nota;
        }
        float media = notaTotal / notas.Count;
        return media;
    }
    float NotaMaisAlta()
    {
        float notaMaior = 0f;

        foreach(float nota in notas)
        {
            if (nota > notaMaior)
            {
                notaMaior = nota;
            }
        }
        return notaMaior;
    }
    float NotaMaisBaixa()
    {
        float notaMenor = 10f;

        foreach(float nota in notas)
        {
            if (nota < notaMenor)
            {
                notaMenor = nota;
            }
        }
        return notaMenor;
    }

    void Start()
    {
        AdicionarNota(7.5f);
        AdicionarNota(5f);
        AdicionarNota(9.9f);
        AdicionarNota(2f);
        AdicionarNota(8.5f);

        Debug.Log($"Media: {CalcularMedia()} | Maior: {NotaMaisAlta()} | Menor: {NotaMaisBaixa()}");
    }
}
