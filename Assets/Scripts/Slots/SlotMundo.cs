/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 17/02/2021
*****************************************************************************/

using System;
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

    private TipoDeMovimento _movimento;

    [SerializeField] private CoresEngrenagens _corAtual; 
    #endregion

    #region VARIABEIS PUBLICAS

    public bool Ocupado { get => _ocupado; }

    public int IndexDoSlot { get => _index; set => _index = value; }

    public CoresEngrenagens Cor { get => _corAtual; }
    public TipoDeMovimento Movimento { get => _movimento; set => _movimento = value; }
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
    public Transform GetTransform()
    {
        return _transform;
    }

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

    public void MoverEngrenagem(float valor)
    {
        switch (_movimento)
        {
            case TipoDeMovimento.ROTACAO_COMPLETA_ANTIHORARIA: RotacaoCompleta(valor); return;

            case TipoDeMovimento.ROTACAO_COMPLETA_HORARIA: RotacaoCompleta(-valor); return;

            case TipoDeMovimento.ROTACAO_INCOMPLETA_ANTIHORARIA: RotacaoIncompleta(valor); return;

            case TipoDeMovimento.ROTACAO_INCOMPLETA_HORARIA: RotacaoIncompleta(-valor); return;

        }

    }

    private void RotacaoIncompleta(float valor)
    {
        transform.rotation = Quaternion.Euler(0, 0, 90 * Mathf.PingPong(valor,1));
    }

    private void RotacaoCompleta(float v)
    {
        transform.rotation = Quaternion.Euler(0, 0, 360 * v); 
    }





    #endregion
}
