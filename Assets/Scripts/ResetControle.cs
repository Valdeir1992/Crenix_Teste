using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnReset();
public class ResetControle : MonoBehaviour
{
    public static event OnReset reset;


    public void ReseteButton()
    {
        reset?.Invoke();
    }
}
