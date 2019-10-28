using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    public GameObject canvas;
    GameObject currEnemy;
    public bool enemyAlive;

    float enemyRespawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        enemyRespawnTimer = 0;
        spawnNewEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRespawnTimer -= Time.deltaTime;
        if(!enemyAlive && enemyRespawnTimer < 0)
        {
            print("new enemy spawned");
            spawnNewEnemy();
        }
    }

    void spawnNewEnemy()
    {
        currEnemy = Instantiate(enemyPrefab);
        currEnemy.transform.position = player.transform.position + new Vector3(0, -5, 25);
        currEnemy.GetComponent<EnemyBehaviorScript>().canvas = canvas;
        currEnemy.GetComponent<EnemyBehaviorScript>().spawner = gameObject;
        enemyAlive = true;
    }

    public void enemyKilled()
    {
        print("enemy killed");
        enemyRespawnTimer = 10;
        enemyAlive = false;
    }
}
