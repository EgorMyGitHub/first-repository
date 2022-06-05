using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallSpawn : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] variantsSpawn;

    [SerializeField] private Transform spawnPos;

    private void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        int random = Random.Range(0, variantsSpawn.Length);

        GameObject newGameObject = Instantiate(variantsSpawn[random], spawnPos.position, quaternion.identity);

        Destroy(newGameObject, 30);
    }
}
