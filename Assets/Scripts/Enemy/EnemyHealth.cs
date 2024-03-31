using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO;

    private int currentHealth;
    void Start()
    {
        currentHealth = enemySO.GetMaxHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Test>())
        {
            SpawnManager.Instance.RemoveAtList(this);
        }
    }
}
