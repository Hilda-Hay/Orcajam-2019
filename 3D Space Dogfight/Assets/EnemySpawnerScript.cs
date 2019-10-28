using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    public GameObject canvas;
    public GameObject killCountText;
    GameObject currEnemy;
    public bool enemyAlive;

    int enemiesKilled;
    int nextEnemyHealth;

    float enemyRespawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        enemiesKilled = 0;
        enemyRespawnTimer = 0;
        nextEnemyHealth = 3;

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
        currEnemy.transform.position = player.transform.position;
        currEnemy.transform.rotation = player.transform.rotation;
        currEnemy.transform.Translate(new Vector3(0, -25, -5));
        currEnemy.GetComponent<EnemyBehaviorScript>().canvas = canvas;
        currEnemy.GetComponent<EnemyBehaviorScript>().spawner = gameObject;
        currEnemy.GetComponent<EnemyBehaviorScript>().health = nextEnemyHealth;
        enemyAlive = true;

        print("Spawned an enemy with " + nextEnemyHealth + " health.");
    }

    public void enemyKilled()
    {
        enemiesKilled++;
        enemyRespawnTimer = 10;
        enemyAlive = false;

        nextEnemyHealth += nextEnemyHealth * 2 / 5;

        killCountText.GetComponent<Text>().text = "Enemies Killed: " + enemiesKilled;   
    }
}
