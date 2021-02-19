using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public delegate void OnStartTeste();
public delegate void OnCompletedTask();
public delegate void OnAtualizarTask(int texto);
public class TextoControle : MonoBehaviour
{
    [SerializeField] private TextoData _data;

    [SerializeField] private TextMeshProUGUI _balaoTexto; 

    public void AoIniciar() => _balaoTexto.text = _data.FalaInicio;
    public void AoCompletarTarefa()  => _balaoTexto.text = _data.FalaEngrenagensCompletas;

    public void AtualizarTexto(int texto) 
    {
        if(texto == 0)
        {
            AoIniciar();
            return;
        }
        _balaoTexto.text = _data.TextoPorEngrenagem[texto - 1];
    }  
}
