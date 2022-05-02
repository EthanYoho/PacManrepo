using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float speed = 2.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardMovement();
    }
    void KeyboardMovement()
    {
        if (Input.GetKey("space"))
        {
            //print("space key was pressed");
            rb.velocity = Vector3.up * speed;
        }
        else
        if (Input.GetKey("w"))
        {
            //print("w key was pressed");
            rb.velocity = Vector3.forward * speed;
        }
        else
        if (Input.GetKey("s"))
        {
            //print("s key was pressed");
            rb.velocity = Vector3.back * speed;
        }
        else
        if (Input.GetKey("a"))
        {
            //print("a key was pressed");
            rb.velocity = Vector3.left * speed;
        }
        else
        if (Input.GetKey("d"))
        {
            //print("d key was pressed");
            rb.velocity = Vector3.right * speed;
        }
    }
}
