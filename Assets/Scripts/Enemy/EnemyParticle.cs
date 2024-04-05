using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticle : MonoBehaviour
{
    private EnemyHealth enemyHealth;

    [SerializeField] private ParticleSystem deadParticle;
    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        enemyHealth.OnDeath += EnemyHealth_OnDeath;
    }

    private void EnemyHealth_OnDeath(object sender, System.EventArgs e)
    {
        var particle = Instantiate(deadParticle);
        particle.transform.position = transform.position;
    }
}
