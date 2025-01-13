using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] targetEnemies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            foreach (GameObject target in targetEnemies) 
            {
                target.GetComponent<EnemyDummy>().ActivateDummy();
            }
        }
    }
}
