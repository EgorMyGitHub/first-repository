using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Player>(out var player))
        {
            Destroy(player.gameObject);

            Time.timeScale = 0;
            
            player.ShowDieScreen();
        }
    }
}
