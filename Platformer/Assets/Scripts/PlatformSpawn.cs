using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawn : MonoBehaviour
{
    [SerializeField] 
    private GameObject prefabs1;
    
    [SerializeField] 
    private Transform Camera;
    
    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(12);
            
            float random = Random.Range(0,3);
            switch (random)
            {
                case 0:
                    Instantiate(prefabs1,new Vector3(Camera.position.x + 10f,transform.position.y,transform.position.z),Quaternion.identity);
                    break;
                
                case 1:
                    Instantiate(prefabs1,new Vector3(Camera.position.x + 10f,transform.position.y - 2f,transform.position.z),Quaternion.identity);
                    break;
                
                case 2:
                    Instantiate(prefabs1,new Vector3(Camera.position.x + 10f,transform.position.y - 4f,transform.position.z),Quaternion.identity);
                    break;
            }
        }
    }
}
