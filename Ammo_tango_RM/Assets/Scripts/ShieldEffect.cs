using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : MonoBehaviour
{
    public float fadeTime = 2f;
    // Start is called before the first frame update


    private void OnEnable()
    {
        
        Invoke("Disable", fadeTime);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

}
