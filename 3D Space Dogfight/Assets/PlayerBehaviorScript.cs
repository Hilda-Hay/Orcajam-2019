using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorScript : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -10 * Time.deltaTime, 0);

        handleInput();
    }

    void handleInput()
    {
        if(Input.GetAxis("Vertical") < 0)
        {
            transform.Rotate(50 * Time.deltaTime, 0, 0);
        } else if (Input.GetAxis("Vertical") > 0)
        {
            transform.Rotate(-50 * Time.deltaTime, 0, 0);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(0, -100 * Time.deltaTime, 0);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(0, 100 * Time.deltaTime, 0);
        }

        if(Input.GetKeyDown("space"))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
