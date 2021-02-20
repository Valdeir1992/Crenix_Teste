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
/// <summary>
/// Script responsavel por gerenciar features dos slotsMundo.
/// </summary>
public class EngrenagensMundoControle : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private Dictionary<int, ISlotEngrenagem> _slotsMundo = new Dictionary<int, ISlotEngrenagem>();

    [SerializeField] private DataMovimento _data; 
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

        ResetControle.reset += Resete;
    }
    private void Start()
    {
        SetIndexSlotMundo();

        Reset();

        _data.SetCurva(); 

        StartCoroutine(RotacionarEngrenagens()); 
    }

    private void OnDisable()
    {
        onStart -= FindObjectOfType<TextoControle>().AoIniciar;

        onCompletTask -= FindObjectOfType<TextoControle>().AoCompletarTarefa;  

        onAtualizar -= FindObjectOfType<TextoControle>().AtualizarTexto; 

        ResetControle.reset -= Resete;
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

    private void Resete()
    {
        foreach (ISlotEngrenagem slot in _slotsMundo.Values)
        { 
            slot.OcultarEngrenagem();
        }
        _slotsMundo = new Dictionary<int, ISlotEngrenagem>();
        VerificarSlots();
    }
    #endregion

    private IEnumerator RotacionarEngrenagens()
    { 
        while (true)
        { 
            if(_slotsMundo.Count == 5)
            {
                foreach (ISlotEngrenagem slot in _slotsMundo.Values)
                { 
                    if(slot.IndexDoSlot < 4)
                    { 

                        slot.MoverEngrenagem(new Vector3(0,0,_data.CurvaCompleta.Evaluate(Time.time/_data.TempoRotacaoCompleta) * -_data.AnguloCompleto));
                    }
                    else
                    { 

                        slot.MoverEngrenagem(new Vector3(0, 0, _data.CurvaCompleta.Evaluate(Time.time/ _data.TempoRotacaoCompleta) * _data.AnguloCompleto));
                    }
                }
            }
            else
            {
                foreach (ISlotEngrenagem slot in _slotsMundo.Values)
                {
                    if (slot.IndexDoSlot < 4)
                    { 

                        slot.MoverEngrenagem(new Vector3(0,0,-_data.AnguloIncompleto * _data.CurvaIncompleta.Evaluate(Time.time/ _data.TempoRotacaoIncompleta))); 
                    }
                    else
                    { 

                        slot.MoverEngrenagem(new Vector3(0,0, _data.AnguloIncompleto * _data.CurvaIncompleta.Evaluate(Time.time/ _data.TempoRotacaoIncompleta)));
                    }
                }
            }
            yield return null;
        }
    }
}
