using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { OneHand, TwoHand, Archer };
public enum PatrolType { Linear, Random, Loop }
public class EnemyManager : GameBehaviour<EnemyManager>
{
    public string[] enemyNames;
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;

    public List<GameObject> enemies;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //    KillAllEnemies();

        //if (Input.GetKeyDown(KeyCode.B))
        //    KillSpecificEnemy("_B");

    }

    
    void SpawnEnemy()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int rnd = Random.Range(0, enemyTypes.Length);
            GameObject go = Instantiate(enemyTypes[rnd], spawnPoints[i].position, spawnPoints[i].rotation);
            enemies.Add(go);
        }
    }

    IEnumerator SpawnEnemyDelayed()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int rnd = Random.Range(0, enemyTypes.Length);
            GameObject go = Instantiate(enemyTypes[rnd], spawnPoints[i].position, spawnPoints[i].rotation);
            enemies.Add(go);
            yield return new WaitForSeconds(2);
        }
    }

    
    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    
    void KillSpecificEnemy(string _condition)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[0].name.Contains(_condition))
                KillEnemy(enemies[0]);
        }
    }

    
    void KillAllEnemies()
    {
        int eCount = enemies.Count;
        for (int i = 0; i < eCount; i++)
        {
            KillEnemy(enemies[0]);
        }
    }

   
    public void KillEnemy(GameObject _enemy)
    {
        if (enemies.Count == 0)
            return;

        Destroy(_enemy);
        enemies.Remove(_enemy);
    }

    void OnEnemyDied(Enemy _enemy)
    {
        KillEnemy(_enemy.gameObject);
    }

    void OnGameStateChange(GameState _gameState)
    {
        switch (_gameState)
        {
            case GameState.Playing:
                StartCoroutine(SpawnEnemyDelayed());
                break;
            case GameState.Paused:
            case GameState.GameOver:
            case GameState.Title:
                StopAllCoroutines();
                break;
        }
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyDied += OnEnemyDied;
        GameEvents.OnGameStateChange += OnGameStateChange;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyDied -= OnEnemyDied;
        GameEvents.OnGameStateChange -= OnGameStateChange;
    }
}
