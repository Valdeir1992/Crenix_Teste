/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 19/02/2021
*****************************************************************************/

using UnityEngine;

/// <summary>
/// Scrìpt responsavel por armazenar textos do teste.
/// </summary>
[CreateAssetMenu(menuName ="Prototipo/Data/Texto")]
public class TextoData : ScriptableObject
{
    #region VARIAVEIS PRIVADAS
    [SerializeField] [TextArea(1,2)] private string _falaInicio;

    [SerializeField] [TextArea(1, 2)] private string _falaEngrenagensCompletas;

    [SerializeField] [TextArea(1, 2)] private string[] _textoPorEngrenagens;
    #endregion

    #region PROPRIEDADES
    public string FalaInicio { get => _falaInicio; }

    public string FalaEngrenagensCompletas { get => _falaEngrenagensCompletas; }

    public string[] TextoPorEngrenagem { get => _textoPorEngrenagens; }
    #endregion
}
