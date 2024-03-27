using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable Object/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] private string enemyName;
    [SerializeField] private int maximumHealth;

    public string GetName()
    {
        return enemyName;
    }

    public int GetMaxHealth()
    {
        return maximumHealth;
    }
}
