/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 20/02/2021
*****************************************************************************/
 
using UnityEngine;

/// <summary>
/// Script responsavel por armazenar dados sobre o movimento das engrenagens.
/// </summary>
[CreateAssetMenu(menuName ="Prototipo/Data/Movimento")]
public class DataMovimento : ScriptableObject
{
    #region VARIAVEIS PRIVADAS

    [SerializeField] private float _anguloCompleto;

    [SerializeField] private float _anguloIncompleto;

    [SerializeField] [Min(1)] private float _tempoRotacaoCompleto;

    [SerializeField] [Min(1)] private float _tempoRotacaoIncompleto;

    [SerializeField] private AnimationCurve _curvaCompleta;

    [SerializeField] private AnimationCurve _curvaIncompleta;
    #endregion

    #region PROPRIEDADES

    public AnimationCurve CurvaCompleta { get => _curvaCompleta; }
    public float AnguloCompleto { get => _anguloCompleto; }
    public float AnguloIncompleto { get => _anguloIncompleto; }
    public AnimationCurve CurvaIncompleta { get => _curvaIncompleta; }
    public float TempoRotacaoCompleta { get => _tempoRotacaoCompleto; }
    public float TempoRotacaoIncompleta { get => _tempoRotacaoIncompleto; }
    #endregion

    /// <summary>
    /// Métoro responsavel por setar curva de animacao em loop.
    /// </summary>
    public void SetCurva()
    {
        _curvaCompleta.postWrapMode = WrapMode.Loop;

        _curvaIncompleta.postWrapMode = WrapMode.Loop;
    }
}
