/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 17/02/2021
*****************************************************************************/
 
using UnityEngine;
/// <summary>
/// Script responsavel por gerenciar cores do game.
/// </summary>
public class CoresControle : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    [SerializeField] private SpriteRenderer _fundo;

    [SerializeField] private CoresData _data;
    #endregion

    #region MÉTODOS UNITY
    private void Start()
    {
        SetupCores();
    }
    #endregion

    #region MÉTODOS PRÓPRIOS 
    /// <summary>
    /// Método responsavel por setar as configurações gerais de cores.
    /// </summary>
    private void SetupCores()
    {
        _fundo.color = _data.CorPanel;

        Camera.main.backgroundColor = _data.CorFundo;
    }

    public Color ConverterEnumParaCor(CoresEngrenagens cor)
    {
        switch (cor)
        {
            case CoresEngrenagens.COR04: return _data.Cor03;

            case CoresEngrenagens.COR02: return _data.Cor01;

            case CoresEngrenagens.COR05: return _data.Cor05;

            case CoresEngrenagens.COR01: return _data.Cor02;

            case CoresEngrenagens.COR03: return _data.Cor04;

            default: return Color.white;
        }
    }
    #endregion
}
