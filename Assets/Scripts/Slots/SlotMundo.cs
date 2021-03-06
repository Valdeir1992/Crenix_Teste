﻿/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 17/02/2021
*****************************************************************************/
 
using UnityEngine;

/// <summary>
/// Script responsavel por visualizacao do slot no mundo.
/// </summary>
public class SlotMundo : MonoBehaviour, ISlotEngrenagem
{
    #region VARIAVEIS PRIVADAS

    private Transform _transform;

    private bool _ocupado;

    private int _index; 

    [SerializeField] private CoresEngrenagens _corAtual;
    #endregion

    #region VARIABEIS PUBLICAS

    public bool Ocupado { get => _ocupado; }

    public int IndexDoSlot { get => _index; set => _index = value; }

    public CoresEngrenagens Cor { get => _corAtual; } 
    #endregion

    #region EVENT
    private event OnEnterSlot onEnterSlot;

    private event OnExitSlot onExitSlot;

    private event OnClickSlot onClickSlot;
    #endregion

    #region MÉTODOS UNITY
    private void Awake()
    {
        _transform = transform; 
    }
    private void OnEnable()
    {
        onEnterSlot += FindObjectOfType<MouseControle>().EnterSlot;

        onExitSlot += FindObjectOfType<MouseControle>().ExitSlot;

        onClickSlot += FindObjectOfType<MouseControle>().AtivarIcone;
    }
    private void Start()
    { 
        MudarCor();
    }
    private void OnDisable()
    {
        onEnterSlot -= FindObjectOfType<MouseControle>().EnterSlot;

        onExitSlot -= FindObjectOfType<MouseControle>().ExitSlot;

        onClickSlot -= FindObjectOfType<MouseControle>().AtivarIcone; 
    }
    private void OnMouseDown()
    {
        if (!_ocupado) return;

        OcultarEngrenagem();

        onClickSlot?.Invoke(this);
    }
    private void OnMouseEnter()
    {
        if (_ocupado) return;

        onEnterSlot?.Invoke(this);
    }
    private void OnMouseExit()
    {
        onExitSlot?.Invoke();
    }
    #endregion

    #region MÉTODOS PRÓPRIOS  
    public void MostrarEngrenagem()
    {
        _transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

        MudarCor(FindObjectOfType<CoresControle>().ConverterEnumParaCor(_corAtual), _corAtual);

        _ocupado = true;
    }

    public void MudarCor(Color cor, CoresEngrenagens corEngrenagem)
    {
        _transform.GetChild(0).GetComponent<SpriteRenderer>().color = cor;

        _corAtual = corEngrenagem;
    }
    /// <summary>
    /// Métoro responsavel por deixar engrenagens dos slots no mundo transparente.
    /// </summary>
    public void MudarCor()
    {
        _transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.2f);
    }

    public void OcultarEngrenagem()
    {
        MudarCor();

        _ocupado = false;
    }
    /// <summary>
    /// Método responsavel por movimentar engrenagens dos slots do mundo.
    /// </summary>
    /// <param name="valor">Recebe um vetor para movimentar.</param>
    public void MoverEngrenagem(Vector3 valor)
    {
        Rotacao(valor);

    } 
    /// <summary>
    /// Método responsavel por aplicar rotacao as engrenagens.
    /// </summary>
    /// <param name="valor"></param>
    private void Rotacao(Vector3 valor)
    {
        _transform.GetChild(0).rotation = Quaternion.Euler(valor);
    } 
    #endregion
}
