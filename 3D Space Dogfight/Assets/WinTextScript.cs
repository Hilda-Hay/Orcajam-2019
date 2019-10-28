using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTextScript : MonoBehaviour
{
    Text text;

    float textChangeTimer;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        text.alignment = TextAnchor.MiddleCenter;
        transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        textChangeTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        textChangeTimer -= Time.deltaTime;
        if(textChangeTimer < 0f)
        {
            Destroy(gameObject);
        }
        else if(textChangeTimer < 5f)
        {
            text.text = "A new enemy will spawn in 5 seconds!";
        }
    }
}
