using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTextScript : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        text.alignment = TextAnchor.MiddleCenter;
    }

    // Update is called once per frame
    void Update()
    {
        text.alignment = TextAnchor.MiddleCenter;
        transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }
}
