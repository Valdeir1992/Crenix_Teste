/******************************************************************************
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
        MudarCor();
    }
    private void OnMouseDown()
    {
        OcultarEngrenagem();
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
    }

    public void MudarCor(Color cor)
    {
        _transform.GetChild(0).GetComponent<SpriteRenderer>().color = cor;
    }

    public void MudarCor()
    {
        _transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.2f);
    }

    public void OcultarEngrenagem()
    {
        MudarCor();
    }
    #endregion
}
