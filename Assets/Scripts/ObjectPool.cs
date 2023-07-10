using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPB;
    [SerializeField] float spawnRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (Application.isPlaying)
        {
            Instantiate(enemyPB, transform);
            yield return new WaitForSeconds(spawnRate);
        }


    }
}
