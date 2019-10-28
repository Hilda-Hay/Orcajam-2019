using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject canvas;
    public GameObject spawner;
    public GameObject deathText;
    public GameObject hitExplosionPrefab;
    public GameObject deathExplosionPrefab;

    GameObject currentExplosion;
    

    float behaviorUpdateTimer;
    float explosionTimer;

    int horizAxis = 0;
    int vertAxis = 0;

    public int health;

    float speed;

    Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        behaviorUpdateTimer = 0;

        speed = 10;

        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -1 * speed * Time.deltaTime, 0);

        behaviorUpdateTimer -= Time.deltaTime;
        if (behaviorUpdateTimer < 0)
        {
            decideBehavior();
            behaviorUpdateTimer = 1;
        }

        explosionTimer -= Time.deltaTime;
        if (explosionTimer < 0f && !(currentExplosion is null))
        {
            currentExplosion.GetComponent<ParticleSystem>().Stop();
        }

        handleInput();
    }

    void decideBehavior()
    {
        float vertDecide = Random.value * 4.0f;
        float horizDecide = Random.value * 4.0f;

        if(vertDecide < 1.0)
        {
            vertAxis = 1;
        }
        else if (vertDecide >= 1.0 && vertDecide < 2.0)
        {
            vertAxis = -1;
        }
        else if (vertDecide >= 2.0 && vertDecide < 3.0)
        {
            vertAxis = 0;
        }

        if (horizDecide < 1.0)
        {
            horizAxis = 1;
        }
        else if (horizDecide >= 1.0 && horizDecide < 2.0)
        {
            horizAxis = -1;
        }
        else if (horizDecide >= 2.0 && horizDecide < 3.0)
        {
            horizAxis = 0;
        }
    }

    void handleInput()
    {

            if (vertAxis < 0)
        {
            transform.Rotate(40 * Time.deltaTime, 0, 0);
        }
        else if (vertAxis > 0)
        {
            transform.Rotate(-40 * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }

        if (horizAxis < 0)
        {
            transform.Rotate(0, -80 * Time.deltaTime, 0);
        }
        else if (horizAxis > 0)
        {
            transform.Rotate(0, 80 * Time.deltaTime, 0);
        } else
        {
            transform.Rotate(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit!");
        health -= 1;
        if(!(currentExplosion is null))
        {
            currentExplosion.GetComponent<ParticleSystem>().Stop();
        }
        currentExplosion = Instantiate(hitExplosionPrefab, transform);
        explosionTimer = 3f;
        if (health <= 0)
        {
            GameObject msg = Instantiate(deathText);
            msg.transform.parent = canvas.transform;

            GameObject deathExplosion = Instantiate(deathExplosionPrefab);
            // deathExplosion.transform.localScale *= 4;
            deathExplosion.transform.position = transform.position;
            deathExplosion.GetComponent<Rigidbody>().velocity = -transform.up * speed;

            Debug.Log("Enemy destroyed!");
            spawner.GetComponent<EnemySpawnerScript>().enemyKilled();
            Destroy(gameObject);
        }
    }
}
