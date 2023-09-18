using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int deployCost=75;
    [SerializeField] float buildDelay=1f;

    void Start() {
        StartCoroutine(Build());    
    }
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
    
    IEnumerator Build(){
        foreach(Transform child in transform){
            child.gameObject.SetActive(false);
            foreach(Transform grandChild in child){
                grandChild.gameObject.SetActive(false);
            }
        }

        foreach(Transform child in transform){
            child.gameObject.SetActive(true);

            yield return new WaitForSeconds(buildDelay);

            foreach(Transform grandChild in child){
                grandChild.gameObject.SetActive(true);
            }
        }

        
    }
}
