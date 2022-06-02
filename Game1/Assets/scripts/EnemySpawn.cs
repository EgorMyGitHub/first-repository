using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject prifabs;

    private void Start()
    {
        StartCoroutine(Generator());
    }

    private void OnDestroy()
    {
        StopCoroutine(Generator());
    }

    private IEnumerator Generator()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);

            float random = Random.Range(-23f, 5f);

            Instantiate(prifabs, new Vector3(random, 8, 0), Quaternion.identity);
        }
    }
}
