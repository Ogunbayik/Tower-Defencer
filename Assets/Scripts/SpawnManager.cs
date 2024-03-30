using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private enum SpawnState
    {
        Waiting,
        Spawning
    }

    [SerializeField] private Wave[] waves;

    private SpawnState currentState;
    private float countdownTimer;
    private int spawnCount;

    void Start()
    {
        countdownTimer = 5f;
        spawnCount = 0;
    }


    void Update()
    {
        switch(currentState)
        {
            case SpawnState.Waiting:
                countdownTimer -= Time.deltaTime;

                if (countdownTimer <= 0)
                    currentState = SpawnState.Spawning;

                break;

            case SpawnState.Spawning:
                StartSpawn(waves[0]);

                break;
        }
    }

    private void StartSpawn(Wave wave)
    {
        if (countdownTimer <= 0)
        {
            if (spawnCount < wave.spawnCount)
            {
                Debug.Log("Spawned");
                spawnCount++;
                countdownTimer = wave.delayTimer;
            }
            else
            {
                Debug.Log("Spawned All Enemies");
            }
        }
        else
        {
            countdownTimer -= Time.deltaTime;
        }
    }





    [System.Serializable]
    public class Wave
    {
        public Transform[] enemies;
        public Transform spawnPoint;
        public int spawnCount;
        public float delayTimer;
    }



}

