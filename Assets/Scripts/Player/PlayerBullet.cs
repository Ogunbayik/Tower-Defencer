using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private PlayerAttackController playerAttackController;

    private Vector3 movementDirection;
    private float movementSpeed;
    private int bulletDamage;
    private void Awake()
    {
        playerAttackController = FindObjectOfType<PlayerAttackController>();
        bulletDamage = playerAttackController.GetBulletDamage();
    }
    void Update()
    {
        BulletMovement(movementDirection, movementSpeed);
    }

    public void BulletMovement(Vector3 direction, float speed)
    {
        movementDirection = direction;
        movementSpeed = speed;

        transform.Translate(direction * speed * Time.deltaTime);
    }
    
    public int GetBulletDamage()
    {
        return bulletDamage;
    }
}
