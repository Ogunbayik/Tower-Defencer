using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttackController : MonoBehaviour
{
    public event EventHandler OnAttack;

    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    [SerializeField] private Transform attackPosition;
    [SerializeField] private float maxAttackTimer;

    private float attackTimer = 0;

    private Vector3 bulletDirection;

    private bool canAttack;
    private void OnEnable()
    {
        OnAttack += PlayerAttackController_OnAttack;
    }

    private void PlayerAttackController_OnAttack(object sender, EventArgs e)
    {
        CreateBullet();
        attackTimer = maxAttackTimer;
    }

    void Update()
    {
        CheckAttack();
        HandleAttack();
    }

    private void CheckAttack()
    {
        if (attackTimer <= 0)
        {
            attackTimer = 0;
            canAttack = true;
        }
        else
        {
            canAttack = false;
            attackTimer -= Time.deltaTime;
        }
    }

    private void HandleAttack()
    {
        var attackButton = Input.GetKeyDown(KeyCode.Space);

        if (attackButton && canAttack)
            OnAttack?.Invoke(this, EventArgs.Empty);
    }

    private void CreateBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = attackPosition.position;

        var offsetYPosition = -0.7f;
        bulletDirection = (attackPosition.position - transform.position + new Vector3(0, offsetYPosition, 0));
        bullet.GetComponent<PlayerBullet>().BulletMovement(bulletDirection, bulletSpeed);
    }

    public int GetBulletDamage()
    {
        return bulletDamage;
    }
}
