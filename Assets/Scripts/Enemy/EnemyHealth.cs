using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private event EventHandler OnDeath;

    [SerializeField] private EnemySO enemySO;
    [SerializeField] private Image fillBar;

    private int currentHealth;
    private float healthRate;
    void Start()
    {
        currentHealth = enemySO.GetMaxHealth();
        healthRate = (float)currentHealth / enemySO.GetMaxHealth();
        fillBar.fillAmount = healthRate;
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
        healthRate = (float)currentHealth / enemySO.GetMaxHealth();
        fillBar.fillAmount = healthRate;
    }

    private void Dead()
    {
        Destroy(this.gameObject);
        SpawnManager.Instance.RemoveAtList(this);
    }
}
