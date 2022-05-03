using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelletScript : MonoBehaviour
{
    private int count;
    private Rigidbody rb;
    public GameObject powerPellet;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("PacMan"))
        {
            Destroy(this.gameObject);
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
