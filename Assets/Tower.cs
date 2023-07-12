using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int deployCost=75;

    
    public bool CreateTower( Tower tower ,Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) return false;

        if (bank.CurrentBalance >= deployCost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(deployCost);
            return true;
        }
        return false;
    }
    
}
