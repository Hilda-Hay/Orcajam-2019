using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemFollow : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* float dist = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(player.transform.forward);
        if(dist > 200.0f)
        {
            transform.position = player.transform.position - player.transform.up * 250.0f;
        } */
    }
}
