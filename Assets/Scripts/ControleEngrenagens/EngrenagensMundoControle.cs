/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 19/02/2021
*****************************************************************************/


using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnAddGear(ISlotEngrenagem slot);
public delegate void OnRemoveGear(ISlotEngrenagem slot);
public class EngrenagensMundoControle : MonoBehaviour
{
    private Dictionary<int, ISlotEngrenagem> _slotsMundo = new Dictionary<int, ISlotEngrenagem>();

    private void Start()
    {
        SetIndexSlotMundo();
    }

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

    public void RemoverGear(ISlotEngrenagem slot)
    {
        if (_slotsMundo.ContainsKey(slot.IndexDoSlot))
        {
            _slotsMundo.Remove(slot.IndexDoSlot);
        }
        VerificarSlots();
    }

    private void VerificarSlots()
    {
        if(_slotsMundo.Count == 5)
        {
            Debug.Log("Slots preenchidos");
        }
        else
        {
            Debug.Log($"{5 - _slotsMundo.Count} precisam ser preenchidos");
        }
    }
}
