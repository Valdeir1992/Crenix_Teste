/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 19/02/2021
*****************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnAddGear(ISlotEngrenagem slot);
public delegate void OnRemoveGear(ISlotEngrenagem slot);
public class EngrenagensMundoControle : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private Dictionary<int, ISlotEngrenagem> _slotsMundo = new Dictionary<int, ISlotEngrenagem>();
    #endregion

    #region EVENT
    private event OnStartTeste onStart;

    private event OnCompletedTask onCompletTask;

    private event OnAtualizarTask onAtualizar;
    #endregion

    #region MÉTODOS UNITY
    private void OnEnable()
    {
        onStart += FindObjectOfType<TextoControle>().AoIniciar;

        onCompletTask += FindObjectOfType<TextoControle>().AoCompletarTarefa;

        onAtualizar += FindObjectOfType<TextoControle>().AtualizarTexto;
    }
    private void Start()
    {
        SetIndexSlotMundo();

        Reset();

        StartCoroutine(RotacionarEngrenagens());
    }

    private void OnDisable()
    {
        onStart -= FindObjectOfType<TextoControle>().AoIniciar;

        onCompletTask -= FindObjectOfType<TextoControle>().AoCompletarTarefa;  

        onAtualizar -= FindObjectOfType<TextoControle>().AtualizarTexto;
    }
    #endregion

    #region MÉTODOS PRÓPRIOS

    /// <summary>
    /// Método que seta index de cada slots do mundo a partir da propriedade index.
    /// <see cref="ISlotEngrenagem"/>
    /// </summary>
    private void SetIndexSlotMundo()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).TryGetComponent(out ISlotEngrenagem slot))
            {
                slot.IndexDoSlot = i + 1; 
            }
        }
    } 

    /// <summary>
    /// Método responsavel por registrar adicao de engrenagem ao slot.
    /// </summary>
    /// <param name="slot">Recebe como parametro o slot onde a engrenagem sera adicionada</param>
    public void AddGear(ISlotEngrenagem slot)
    {
        if (_slotsMundo.ContainsKey(slot.IndexDoSlot))
        {
            _slotsMundo[slot.IndexDoSlot] = slot;
        }
        else
        { 
            _slotsMundo.Add(slot.IndexDoSlot, slot);
        } 

        VerificarSlots();
    }

    /// <summary>
    /// Método responsavel por registrar remocao de um engrenagem.
    /// </summary>
    /// <param name="slot">Recebe o slot onde a engrenagem sera removida.</param>
    public void RemoverGear(ISlotEngrenagem slot)
    {
        if (_slotsMundo.ContainsKey(slot.IndexDoSlot))
        {
            _slotsMundo.Remove(slot.IndexDoSlot);
        }
        VerificarSlots();
    }
    /// <summary>
    /// Método responsavel por fazer a contagem de engrenagens nos slots do mundo.
    /// </summary>
    private void VerificarSlots()
    {
        if(_slotsMundo.Count == 5)
        {
            onCompletTask?.Invoke();
        } 
        else
        {
            onAtualizar?.Invoke(_slotsMundo.Count);
        }
    }
    private void Reset()
    {
        onStart?.Invoke();
    }
    #endregion

    private IEnumerator RotacionarEngrenagens()
    {
        float timeElapsed = 0;
        float contador = 0;
        float resultado = 0; 
        while (true)
        {
            timeElapsed += Time.deltaTime;
            contador += Time.deltaTime;
            resultado = contador /3;
            if(resultado > 1)
            {
                contador = 0;
            }
            if(_slotsMundo.Count == 5)
            {
                foreach (ISlotEngrenagem slot in _slotsMundo.Values)
                { 
                    if(slot.IndexDoSlot < 4)
                    {
                        slot.Movimento = TipoDeMovimento.ROTACAO_COMPLETA_HORARIA;

                        slot.MoverEngrenagem(resultado);
                    }
                    else
                    {
                        slot.Movimento = TipoDeMovimento.ROTACAO_COMPLETA_ANTIHORARIA; 

                        slot.MoverEngrenagem(resultado);
                    }
                }
            }
            else
            {
                foreach (ISlotEngrenagem slot in _slotsMundo.Values)
                {
                    if (slot.IndexDoSlot < 4)
                    {
                        slot.Movimento = TipoDeMovimento.ROTACAO_INCOMPLETA_HORARIA;

                        slot.MoverEngrenagem(timeElapsed);
                    }
                    else
                    {
                        slot.Movimento = TipoDeMovimento.ROTACAO_INCOMPLETA_ANTIHORARIA;

                        slot.MoverEngrenagem(timeElapsed);
                    }
                }
            }
            yield return null;
        }
    }
}
