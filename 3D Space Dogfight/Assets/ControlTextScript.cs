using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTextScript : MonoBehaviour
{
    float displayTime;

    // Start is called before the first frame update
    void Start()
    {
        displayTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        displayTime -= Time.deltaTime;
        if(displayTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
