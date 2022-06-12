using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var p))
        {
            gameObject.SetActive(false);
            
            p.ChangeColor();
        }
    }
}
