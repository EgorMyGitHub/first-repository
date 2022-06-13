using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
    [field: SerializeField] 
    private TextMesh hints;

    [field: SerializeField] 
    private Transform target;

    [SerializeField] 
    private float speed;

    private bool IsMove;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            StartCoroutine(ClearHints());
        }
    }

    private void Update()
    {
        if (IsMove && hints.transform.position != target.position)
        {
            hints.transform.position = Vector3.MoveTowards
                (hints.transform.position,target.position,speed * Time.deltaTime);  
        }
    }

    private IEnumerator ClearHints()
    {
        yield return new WaitForSeconds(3);

        IsMove = true;
        
        yield return new WaitForSeconds(3);
        
        gameObject.SetActive(false);
        
        Destroy(gameObject,2);

        yield break;
    }
}
