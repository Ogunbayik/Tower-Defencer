using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    private enum SpawnState
    {
        Idle,
        Spawning,
        Waiting,
        Pass
    }

    [SerializeField] private Wave[] waves;
    [SerializeField] private List<EnemyHealth> enemyList;

    private SpawnState currentState;
    private float countdownTimer;
    private int spawnCount;

    void Start()
    {
        countdownTimer = 5f;
        spawnCount = 0;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    void Update()
    {
        switch(currentState)
        {
            case SpawnState.Idle:
                countdownTimer -= Time.deltaTime;

                if (countdownTimer <= 0)
                    currentState = SpawnState.Spawning;
                break;

            case SpawnState.Spawning:
                StartSpawn(waves[0]);
                break;
            case SpawnState.Waiting:
                if (enemyList.Count <= 0)
                    Debug.Log("Destroyed All Enemies");

                break;
            case SpawnState.Pass:
                Debug.Log("Start Next Wave!!");
                break;
        }
    }

    private void StartSpawn(Wave wave)
    {
        if (countdownTimer <= 0)
        {
            if (spawnCount < wave.spawnCount)
            {
                var enemy = Instantiate(wave.enemies[0]);
                enemy.transform.position = wave.spawnPoint.position;
                enemyList.Add(enemy.GetComponent<EnemyHealth>());

                spawnCount++;
                countdownTimer = wave.delayTimer;
            }
            else
            {
                Debug.Log("Spawned All Enemies");
                currentState = SpawnState.Waiting;
            }
        }
        else
        {
            countdownTimer -= Time.deltaTime;
        }
    }

    public void RemoveAtList(EnemyHealth enemy)
    {
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
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

