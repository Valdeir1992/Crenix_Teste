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

    [SerializeField] private Color _rojo;

    [SerializeField] private Color _rosa;

    [SerializeField] private Color _amarelo;

    [SerializeField] private Color _verde;

    [SerializeField] private Color _azul;

    [SerializeField] private Color _corDeFundo;

    [SerializeField] private Color _corPanel;
    #endregion

    #region PROPRIEDADES

    public Color Rojo { get => _rojo; }

    public Color Rosa { get => _rosa; }

    public Color Amarelo { get => _amarelo; }

    public Color Verde { get => _verde; }

    public Color Azul { get => _azul; }

    public Color CorFundo { get => _corDeFundo; }

    public Color CorPanel { get => _corPanel; } 
    #endregion
}
