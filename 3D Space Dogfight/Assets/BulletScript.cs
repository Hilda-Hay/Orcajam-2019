using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float velocity;
    float lifetime;

    Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = 10;

        RB = GetComponent<Rigidbody>();

        RB.velocity =  -transform.up * velocity;
    }

    // Update is called once per frame
    void Update()
    {        
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
    }
}
