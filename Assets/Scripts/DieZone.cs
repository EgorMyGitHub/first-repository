using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.TryGetComponent<PlayerMove>(out var p))
        {
            FindObjectOfType<PlayerMove>().Lose();

            Time.timeScale = 0;
        }
    }
}
