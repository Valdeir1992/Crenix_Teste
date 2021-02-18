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
            case CoresEngrenagens.AMARELO: return _data.Amarelo;

            case CoresEngrenagens.ROJO: return _data.Rojo;

            case CoresEngrenagens.AZUL_TONALIDADE_DESCONHECIDA: return _data.Azul;

            case CoresEngrenagens.ROSA: return _data.Rosa;

            case CoresEngrenagens.VERDE: return _data.Verde;

            default: return Color.white;
        }
    }
    #endregion
}
