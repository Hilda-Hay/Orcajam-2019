using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorScript : MonoBehaviour
{
    public GameObject bullet;

    Rigidbody RB;

    float speed;

    public GameObject mainCam;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();

        mainCam = GameObject.Find("Main Camera");

        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -1 * speed * Time.deltaTime, 0);

        handleInput();

        setCamera();
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

        if(Input.GetKey("left ctrl"))
        {
            speed -= 2 * Time.deltaTime;
            if(speed < 2)
            {
                speed = 2;
            }
        } else if(Input.GetKey("left alt"))
        {
            speed += 2 * Time.deltaTime;
            if(speed > 20)
            {
                speed = 20;
            }
        }

        if(Input.GetKeyDown("space"))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    void setCamera()
    {
        mainCam.transform.localPosition = new Vector3(0, 10, 4) * (speed / 10.0f);
    }
}
