
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform[] enemyTypes;
    [SerializeField] float initilWait = 1f;
    [SerializeField] float spawnWait = 2.5f;
    [SerializeField] int numToSpawn;
    [SerializeField] int WavesToBoss = 3;
    int spawnIndex = 0;
    int enemyIndex = 0;
    [SerializeField]int enemysAlive = 0;
    [SerializeField] int enemysKilled = 0;

    private void OnEnable() {
        EventManager.OnEnemyKilled += ReduceEnemyCount;
        EventManager.OnGameOver += CancelAllSpawning;
    }

    private void OnDisable() {
        EventManager.OnEnemyKilled -= ReduceEnemyCount;
        EventManager.OnGameOver -= CancelAllSpawning;
    }

    // Update is called once per frame
    void Update () {
        Testing();
	}

    private void Testing() {
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log("Begin Wave");
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave() {
        enemysAlive = 0;
        // WE are adding the level to the number to spawn, adding only 1 extra enemy each time
        numToSpawn = Mathf.FloorToInt(numToSpawn + GameManager.Instance.Level);
        yield return new WaitForSeconds(initilWait);
        while(enemysAlive < numToSpawn) {
            for (int i = 0; i < numToSpawn; i++) {
                if(GameManager.Instance.Level -1 > enemyTypes.Length) {
                    Debug.Log("Max Enemy types reached");
                    enemyIndex = Random.Range(0, enemyTypes.Length); //Prevent overflow
                }
                else {
                    enemyIndex = Random.Range(0, GameManager.Instance.Level - 1); // Adds new enemy type for each level
                }
                
                spawnIndex = Random.Range(0, spawnPoints.Length);
                Instantiate(enemyTypes[enemyIndex], spawnPoints[spawnIndex].GetChild(0).position, Quaternion.identity);
                enemysAlive++;
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    IEnumerator SpawnBossWave() {
        enemysAlive = 0;
        
        numToSpawn = Mathf.FloorToInt(numToSpawn + GameManager.Instance.Level); 
        yield return new WaitForSeconds(initilWait);
        while (enemysAlive < numToSpawn) {
            for (int i = 0; i < numToSpawn; i++) {
                enemyIndex = Random.Range(0, enemyTypes.Length);
                spawnIndex = Random.Range(0, spawnPoints.Length);
                Instantiate(enemyTypes[enemyIndex], spawnPoints[spawnIndex].GetChild(0).position, Quaternion.identity);
                enemysAlive++;
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    void ReduceEnemyCount() {
        enemysKilled++;
        if(enemysKilled >= numToSpawn) {
            Debug.Log("NextWave");
            GameManager.Instance.Level++;
            StartCoroutine(SpawnWave());
        }

    }

    void CancelAllSpawning() {
        Debug.Log("stopping spawing");
        StopAllCoroutines();
    }
}
