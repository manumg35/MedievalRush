using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPB;
    [SerializeField] int poolSize=5;
    [SerializeField] float spawnRate = 1f;

    GameObject[] pool;
    void Awake()
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for(int i=0; i<pool.Length; i++)
        {
            pool[i]= Instantiate(enemyPB, transform);
            pool[i].SetActive(false);
        }
    }
    IEnumerator SpawnEnemy()
    {
        while (Application.isPlaying)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void EnableObjectInPool()
    {
        for(int i =0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy==false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
