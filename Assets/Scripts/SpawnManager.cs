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

    [SerializeField] private float maxStartTimer;

    private SpawnState currentState;
    private float spawnTimer;
    private float startTimer = 0;
    private int spawnCount = 0;
    private int waveIndex = 0;

    void Start()
    {
        startTimer = maxStartTimer;

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
                if (GameManager.Instance.currentState == GameManager.GameStates.InGame)
                    startTimer -= Time.deltaTime;

                if (startTimer <= 0)
                {
                    currentState = SpawnState.Spawning;
                    startTimer = maxStartTimer;
                }

                break;

            case SpawnState.Spawning:
                StartSpawn(waves[waveIndex]);
                break;
            case SpawnState.Waiting:
                if (enemyList.Count <= 0)
                {
                    currentState = SpawnState.Pass;
                }

                break;
            case SpawnState.Pass:
                
                break;
        }
    }

    private void StartSpawn(Wave wave)
    {
        if (spawnTimer <= 0)
        {
            if (spawnCount < wave.spawnCount)
            {
                var enemy = Instantiate(wave.enemies[0]);
                enemy.transform.position = wave.spawnPoint.position;
                enemyList.Add(enemy.GetComponent<EnemyHealth>());

                spawnCount++;
                spawnTimer = wave.delayTimer;
            }
            else
            {
                //Spawned All Enemies
                currentState = SpawnState.Waiting;
            }
        }
        else
        {
            spawnTimer -= Time.deltaTime;
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

