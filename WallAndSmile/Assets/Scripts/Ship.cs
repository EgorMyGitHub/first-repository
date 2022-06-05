using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Rigidbody2D ship;

    private void Awake()
    {
        ship = GetComponent<Rigidbody2D>();
    }
}
