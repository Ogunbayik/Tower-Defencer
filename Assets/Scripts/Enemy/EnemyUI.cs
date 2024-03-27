using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO;

    [SerializeField] private TextMeshProUGUI nameText;

    private string enemyName;
    void Start()
    {
        enemyName = enemySO.GetName();
        nameText.text = enemyName;
    }

}
