using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    private event EventHandler OnDeath;

    private PlayerAttackController playerAttackController;

    [SerializeField] private EnemySO enemySO;

    private int currentHealth;
    private void Awake()
    {
        playerAttackController = FindObjectOfType<PlayerAttackController>();
    }
    void Start()
    {
        currentHealth = enemySO.GetMaxHealth();
    }

    private void OnEnable()
    {
        OnDeath += EnemyHealth_OnDeath;
    }

    private void EnemyHealth_OnDeath(object sender, EventArgs e)
    {
        Dead();
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerBullet = other.gameObject.GetComponent<PlayerBullet>();
        var bulletDamage = playerBullet.GetBulletDamage();

        if(playerBullet)
        {
            if (currentHealth > bulletDamage)
                TakeDamage(bulletDamage);
            else
                OnDeath?.Invoke(this, EventArgs.Empty);

            Destroy(playerBullet.gameObject);
        }
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    private void Dead()
    {
        Destroy(this.gameObject);
        SpawnManager.Instance.RemoveAtList(this);
    }
}
