using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemyScript : MonoBehaviour
{
    public float lifetime;
    GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        effect = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {
            effect.GetComponent<ParticleSystem>().Stop();
            
        }
        if(lifetime < -5)
        {
            Destroy(gameObject);
        }
    }
}
