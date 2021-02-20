/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 17/02/2021
*****************************************************************************/
 
using UnityEngine;

/// <summary>
/// Script responsavel por armazenar informações sobre cores.
/// </summary>
[CreateAssetMenu(menuName ="Prototipo/Data/Cores")]
public class CoresData : ScriptableObject
{
    #region VARIAVEIS PRIVADAS

    [SerializeField] private Color _cor01;

    [SerializeField] private Color _cor02;

    [SerializeField] private Color _cor03;

    [SerializeField] private Color _cor04;

    [SerializeField] private Color _cor05;

    [SerializeField] private Color _corDeFundo;

    [SerializeField] private Color _corPanel;
    #endregion

    #region PROPRIEDADES

    public Color Cor01 { get => _cor01; }

    public Color Cor02 { get => _cor02; }

    public Color Cor03 { get => _cor03; }

    public Color Cor04 { get => _cor04; }

    public Color Cor05 { get => _cor05; }

    public Color CorFundo { get => _corDeFundo; }

    public Color CorPanel { get => _corPanel; } 
    #endregion
}
