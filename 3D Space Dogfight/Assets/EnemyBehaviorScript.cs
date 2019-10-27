using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour
{
    public GameObject bullet;

    float behaviorUpdateTimer;

    int horizAxis = 0;
    int vertAxis = 0;

    public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        behaviorUpdateTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -10 * Time.deltaTime, 0);

        behaviorUpdateTimer -= Time.deltaTime;
        if (behaviorUpdateTimer < 0)
        {
            decideBehavior();
            behaviorUpdateTimer = 1;
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
        if (health <= 0)
        {
            Debug.Log("Enemy destroyed!");
            Destroy(gameObject);
        }
    }
}
