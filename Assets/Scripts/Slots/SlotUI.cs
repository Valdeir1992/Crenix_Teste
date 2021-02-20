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
public class SlotUI : MonoBehaviour, ISlotEngrenagem, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    #region VARIAVEIS PRIVADAS

    private Transform _transform;

    private bool _ocupado = true;

    private int _index;

    [SerializeField] private CoresEngrenagens _corAtual;
    #endregion

    #region VARIABEIS PUBLICAS

    public bool Ocupado { get => _ocupado; }

    public int IndexDoSlot { get => _index; set => _index = value; }

    public CoresEngrenagens Cor { get => _corAtual; } 
    #endregion

    #region EVENT
    private event OnClickSlot onClickSlot;

    private event OnEnterSlot onEnterSlot;

    private event OnExitSlot onExitSlot;
    #endregion

    #region MÉTODOS UNITY
    private void Awake()
    {
        _transform = transform; 
    }
    private void OnEnable()
    {
        onClickSlot += FindObjectOfType<MouseControle>().AtivarIcone;

        onEnterSlot += FindObjectOfType<MouseControle>().EnterSlot;

        onExitSlot += FindObjectOfType<MouseControle>().ExitSlot;
    }
    private void Start()
    { 
        MudarCor(FindObjectOfType<CoresControle>().ConverterEnumParaCor(_corAtual), _corAtual);
    }
    private void OnDisable()
    {
        onClickSlot -= FindObjectOfType<MouseControle>().AtivarIcone;

        onEnterSlot -= FindObjectOfType<MouseControle>().EnterSlot; 

        onExitSlot -= FindObjectOfType<MouseControle>().ExitSlot;

    }
    #endregion

    #region MÉTODOS PRÓPRIOS 
    public void MostrarEngrenagem()
    {
        _transform.GetChild(0).GetComponent<Image>().enabled = true;

        _ocupado = true;
    }

    public void MudarCor(Color cor, CoresEngrenagens corEngrenagem)
    {
        _transform.GetChild(0).GetComponent<Image>().color = cor;

        _corAtual = corEngrenagem;
    }

    public void OcultarEngrenagem()
    {
        _transform.GetChild(0).GetComponent<Image>().enabled = false;

        _ocupado = false; 
    }
    /// <summary>
    /// Método que registra click do mouse e executa evento OnClickSlot.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_ocupado) return;

        OcultarEngrenagem();

        onClickSlot?.Invoke(this);
    }
    /// <summary>
    /// ;étodo que resistra entrada do mouse no slot e executa evento OnEnterSlot.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_ocupado) return;
                
        onEnterSlot?.Invoke(this); 
    }
    /// <summary>
    /// ;étodo que resistra saida do mouse no slot e executa evento OnExitSlot.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        onExitSlot?.Invoke();
    } 
    #endregion
}
