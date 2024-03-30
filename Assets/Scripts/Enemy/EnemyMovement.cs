using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private const string MOVEMENT_POSITION = "MovePosition";

    private NavMeshAgent agent;

    [SerializeField] private Transform[] movementPositions;

    private Transform desiredPosition;
    private int movementIndex;
    private void Awake()
    {
        
    }
    void Start()
    {
        InitializeMovementPosition();
    }

    private void InitializeMovementPosition()
    {
        agent = GetComponent<NavMeshAgent>();
        Transform movePosition = GameObject.Find(MOVEMENT_POSITION).transform;

        for (int i = 0; i < movePosition.childCount; i++)
        {
            var children = movePosition.GetComponentsInChildren<Transform>();
            movementPositions = children;
        }

        movementIndex = 1;
        desiredPosition = movementPositions[movementIndex];
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        agent.SetDestination(desiredPosition.position);

        var distanceBetweenDesiredPoint = Vector3.Distance(transform.position, desiredPosition.position);
        if (distanceBetweenDesiredPoint <= 0.6f)
        {
            movementIndex++;
            desiredPosition = movementPositions[movementIndex];
        }
    }
}
