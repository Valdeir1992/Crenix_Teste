using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioControle : MonoBehaviour
{
    private List<ISlotEngrenagem> _engrenagensInventario = new List<ISlotEngrenagem>();
    // Start is called before the first frame update

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

    private void PegarTodosEngrenagens()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).TryGetComponent(out ISlotEngrenagem slot))
            {
                _engrenagensInventario.Add(slot);
            }
        }
        Debug.Log(_engrenagensInventario.Count);
    }
    
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
}
