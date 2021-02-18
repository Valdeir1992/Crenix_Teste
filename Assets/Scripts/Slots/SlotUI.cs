/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 17/02/2021
*****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Script responsavel pelos slots de ui.
/// </summary>
public class SlotUI : MonoBehaviour, ISlotEngrenagem, IPointerClickHandler
{
    #region VARIAVEIS PRIVADAS

    private Transform _transform;

    private bool _ocupado;

    private int _index;

    [SerializeField] private CoresEngrenagens _corAtual;
    #endregion

    #region VARIABEIS PUBLICAS

    public bool Ocupado { get => _ocupado; }

    public int IndexDoSlot { get => _index; }

    public CoresEngrenagens Cor { get => _corAtual; }
    #endregion

    #region MÉTODOS UNITY
    private void Awake()
    {
        _transform = transform; 
    }
    private void Start()
    { 
        MudarCor(FindObjectOfType<CoresControle>().ConverterEnumParaCor(_corAtual));
    }
    #endregion

    #region MÉTODOS PRÓPRIOS
    public Transform GetTransform()
    {
        return _transform;
    }

    public void MostrarEngrenagem()
    {
        _transform.GetChild(0).GetComponent<Image>().enabled = true;
    }

    public void MudarCor(Color cor)
    {
        _transform.GetChild(0).GetComponent<Image>().color = cor;
    }

    public void OcultarEngrenagem()
    {
        _transform.GetChild(0).GetComponent<Image>().enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OcultarEngrenagem();
    }


    #endregion
}
