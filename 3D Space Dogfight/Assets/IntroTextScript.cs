using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTextScript : MonoBehaviour
{
    float textDisplayTime;

    // Start is called before the first frame update
    void Start()
    {
        textDisplayTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        textDisplayTime -= Time.deltaTime;
        if(textDisplayTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
