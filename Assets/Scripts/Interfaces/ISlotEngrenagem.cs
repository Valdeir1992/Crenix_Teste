/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 17/02/2021
*****************************************************************************/

using UnityEngine;
/// <summary>
/// Interface base de engrenagens
/// </summary>
public interface ISlotEngrenagem
{
    #region VARIAVEIS PÚBLICAS
    bool Ocupado { get; } 

    int IndexDoSlot { get; set; } 

    CoresEngrenagens Cor { get; }

    TipoDeMovimento Movimento { get; set; }
    #endregion

    #region MÉTODOS PRÓPRIOS


    /// <summary>
    /// Método responsavel por ocultar engrenagem do slot.
    /// </summary>
    void OcultarEngrenagem();

    /// <summary>
    /// Método responsavel por mostrar engrenagem do slot.
    /// </summary>
    void MostrarEngrenagem();

    /// <summary>
    /// Método responsavel por mudar cor da engrenagem.
    /// </summary>
    /// <param name="cor">Recebe a cor desejada para a engrenagem</param>
    void MudarCor(Color cor, CoresEngrenagens corEngrenagem);
 
    /// <summary>
    /// Método responsavel por retornar transform do slot.
    /// </summary>
    /// <returns></returns>
    Transform GetTransform();

    void MoverEngrenagem(float valor);
    #endregion
}
