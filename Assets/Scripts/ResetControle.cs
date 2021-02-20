/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 20/02/2021
*****************************************************************************/
using UnityEngine;

public delegate void OnReset();
/// <summary>
/// Script responsavel por gerenciar feature de reset.
/// </summary>
public class ResetControle : MonoBehaviour
{
    #region EVENTS

    public static event OnReset reset;
    #endregion

    #region MÉTODOS PRÓPRIOS

    /// <summary>
    /// Métoro anexado ao botao de resete.
    /// </summary>
    public void ReseteButton() => reset?.Invoke();
    #endregion
}
