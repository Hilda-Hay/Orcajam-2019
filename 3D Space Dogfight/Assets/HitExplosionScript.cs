using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitExplosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration;
    GameObject effect;   

    void Start()
    {
        effect = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;

        if(duration < 0)
        {
            effect.GetComponent<ParticleSystem>().Stop();
        }
    }
}
