using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string MOVEMENT_POSITION = "MovePosition";

    [SerializeField] private Transform[] movementPositions;
    void Start()
    {
        InitializeMovementPosition();
    }

    private void InitializeMovementPosition()
    {
        Transform movePosition = GameObject.Find(MOVEMENT_POSITION).transform;

        for (int i = 0; i < movePosition.childCount; i++)
        {
            var children = movePosition.GetComponentsInChildren<Transform>();
            movementPositions = children;
        }
    }

    void Update()
    {
        
    }
}
