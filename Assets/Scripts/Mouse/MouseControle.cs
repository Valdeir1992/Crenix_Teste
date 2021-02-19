/******************************************************************************
* Copyright (c) 2021 Crenix
* All rights reserved.
* Programador: Valdeir Antonio do Nascimento
* Data: 18/02/2021
*****************************************************************************/

using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

public delegate void OnClickSlot(ISlotEngrenagem slot);
public delegate void OnEnterSlot(ISlotEngrenagem slot);
public delegate void OnExitSlot();
/// <summary>
/// Script responsavel por gerenciar features ligadas ao mouse.
/// </summary>
public class MouseControle : MonoBehaviour
{
    #region VARIAVEIS PRIVADAS

    private IEnumerator _rotina;

    private ISlotEngrenagem _origem;

    private ISlotEngrenagem _destino;

    private CoresControle _corControle;

    [SerializeField] private Canvas _canvas;

    [SerializeField] private Image _icone;
    #endregion

    #region EVENT
    private event OnAddGear onAdd;

    private event OnRemoveGear onRemove;
    #endregion

    #region MÉTODOS UNITY

    private void Awake()
    {
        _rotina = BuscarMouse();

        _corControle = FindObjectOfType<CoresControle>();
    }
    private void OnEnable()
    {
        onAdd += FindObjectOfType<EngrenagensMundoControle>().AddGear;

        onRemove += FindObjectOfType<EngrenagensMundoControle>().RemoverGear;
    }
    private void Start()
    {
        StartCoroutine(_rotina);

        StartCoroutine(CheckClick());
    }

    private void OnDisable()
    {
        onAdd -= FindObjectOfType<EngrenagensMundoControle>().AddGear;

        onRemove -= FindObjectOfType<EngrenagensMundoControle>().RemoverGear;
    }
    #endregion

    #region MÉTODOS PRÓPRIOS

    /// <summary>
    /// Método responsavel por ativar icone do mouse.
    /// </summary>
    /// <remarks>Esse método é passado como um evento para os scripts de slot</remarks>
    /// <see cref="ISlotEngrenagem"/>
    /// <param name="slot">Recebe um slot como parametro</param>
    public void AtivarIcone(ISlotEngrenagem slot)
    {
        _icone.enabled = true;

        _icone.color = _corControle.ConverterEnumParaCor(slot.Cor);

        _origem = slot;
    }
    /// <summary>
    /// Método responsavel por registrar slot destino da engrenagem, caso o slot esteja oculpado nada acontecerá.
    /// </summary>
    /// <remarks>Esse método é passado como um evento para os scripts de slot</remarks>
    /// <see cref="ISlotEngrenagem"/>
    /// <param name="slot">Recebe um slot como parametro</param>
    public void EnterSlot(ISlotEngrenagem slot)
    {
        if (_origem == null) return;

        _destino = slot;
    }
    /// <summary>
    /// Método responsavel por apagar registrar slot destino da engrenagem.
    /// </summary>
    /// <remarks>Esse método é passado como um evento para os scripts de slot</remarks> 
    public void ExitSlot()
    {
        _destino = null;
    }
    /// <summary>
    /// Método responsavel por desativar icone do mouse.
    /// </summary>
    /// <remarks>Esse método é passado como um evento para os scripts de slot</remarks> 
    private void DesativarIcone()
    {
        _icone.enabled = false;
    }
    #endregion

    #region ROTINAS

    /// <summary>
    /// Rotina desenhada para fazer icone seguir o ponteiro do mouse.
    /// </summary>
    /// <returns></returns>
    IEnumerator BuscarMouse()
    {
        Vector2 pos;

        Camera cameraPrincipal = Camera.main;

        while (true)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform,
                                                                    Input.mousePosition,
                                                                    cameraPrincipal,
                                                                    out pos);

            _icone.rectTransform.anchoredPosition = pos;
            yield return null;
        }
    }
    /// <summary>
    /// Rotina desenhada para verificar comandos do mouse.
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckClick()
    { 
        while (true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                DesativarIcone();

                if(_origem != null &&_destino == null)
                {
                    _origem.MostrarEngrenagem();

                    _origem = null;
                }
                else if(_origem != null)
                {
                    _destino.MudarCor(_corControle.ConverterEnumParaCor(_origem.Cor),_origem.Cor);

                    _destino.MostrarEngrenagem();

                    if(_destino.GetType() == typeof(SlotMundo))
                    {
                        onAdd?.Invoke(_destino);
                    }
                    if(_origem.GetType() == typeof(SlotMundo))
                    {
                        onRemove?.Invoke(_origem);
                    } 
                    

                    _destino = null;

                    _origem = null;
                }
            }
            yield return null;
        }
    }
    #endregion
}
