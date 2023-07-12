using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints = 0;

    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProccessHit();
    }

    private void ProccessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            enemy.RewardGold();
            gameObject.SetActive(false);
        }
    }

}
