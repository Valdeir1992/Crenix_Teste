/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 20/02/2021
*****************************************************************************/

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsavel por features ligadas ao inventario de engrenagens.
/// </summary>
public class InventarioControle : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private List<ISlotEngrenagem> _engrenagensInventario = new List<ISlotEngrenagem>();
    #endregion

    #region MÉTODOS UNITY
    private void OnEnable()
    {
        ResetControle.reset += Resete;
    }
    void Start()
    {
        PegarTodosEngrenagens();
    }
    private void OnDisable()
    {
        ResetControle.reset -= Resete;
    }
    #endregion

    #region MÉTODOS PRÓPRIOS

    /// <summary>
    /// Método responsavel por pegar referencia de todos os slotsUI.
    /// </summary>
    private void PegarTodosEngrenagens()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).TryGetComponent(out ISlotEngrenagem slot))
            {
                _engrenagensInventario.Add(slot);
            }
        } 
    }
    
    /// <summary>
    /// Método responsavel por resetar slosUI.
    /// <see cref="ResetControle"/>
    /// </summary>
    private void Resete()
    {
        int contador = 0;
        foreach (ISlotEngrenagem slot in _engrenagensInventario)
        { 
            slot.MudarCor(FindObjectOfType<CoresControle>().ConverterEnumParaCor((CoresEngrenagens)contador), (CoresEngrenagens)contador);

            slot.MostrarEngrenagem();

            contador++;
        }
    }
    #endregion
}
