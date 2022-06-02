using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask whatIsSolid;

    private void Update()
    { 
        RaycastHit2D hitinfo = Physics2D.Raycast
            (transform.position, transform.up, distance, whatIsSolid);
        
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.TryGetComponent<Enemy>(out var e))
            {
                Destroy(e.gameObject);
            }
            Destroy(gameObject);
        }
        Destroy(gameObject,lifetime);

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
