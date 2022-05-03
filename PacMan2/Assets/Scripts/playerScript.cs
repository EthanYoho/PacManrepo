using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent ghostAgent;
    TextMesh theScoreTextMesh;

    public float speed = 2.0f;
    private Rigidbody rb;
    
    public GameObject scoreText;
    public GameObject theghostAgent;
    public GameObject powerPellet;
    private bool goForward = false;
    private bool goBackward = false;
    private bool goRight = false;
    private bool goLeft = false;
    private int count = 0;


    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        ghostAgent = this.theghostAgent.GetComponent<UnityEngine.AI.NavMeshAgent>();
        ghostAgent.speed = 2.0f;
        this.theScoreTextMesh = this.scoreText.GetComponent<TextMesh>();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.theScoreTextMesh.text = "Score: " + count;

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Pellet"))
        {
            Destroy(powerPellet);
            count++;
            this.theScoreTextMesh.text = "Score: " + count;
        }
        else 
        if(collision.gameObject.tag.Equals("RightTp"))
        {
            this.gameObject.transform.position = new Vector3(-9.874f, 0.3454f, 0.538f);
        }
        else
        if (collision.gameObject.tag.Equals("LeftTp"))
        {
            this.gameObject.transform.position = new Vector3(9.874f, 0.3454f, 0.538f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        this.ghostAgent.SetDestination(this.gameObject.transform.position);
        if (goForward)
        {
            rb.velocity = Vector3.forward * speed;
        }
        else if (goBackward)
        {
            rb.velocity = Vector3.back * speed;
        }
        else if (goLeft)
        {
            rb.velocity = Vector3.left * speed;
        }
        else if (goRight)
        {
            rb.velocity = Vector3.right * speed;
        }

        if (Input.GetKeyDown("up"))
        {
            this.transform.rotation = Quaternion.LookRotation(Camera.main.transform.up);
            goForward = true;
            goBackward = false;
            goRight = false;
            goLeft = false;

        }
        else if (Input.GetKeyDown("down"))
        {
            this.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.up);

            goForward = false;
            goBackward = true;
            goRight = false;
            goLeft = false;

        }
        else if (Input.GetKeyDown("left"))
        {
            this.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.right);

            goForward = false;
            goBackward = false;
            goRight = false;
            goLeft = true;

        }
        else if (Input.GetKeyDown("right"))
        {
            this.transform.rotation = Quaternion.LookRotation(Camera.main.transform.right);

            goForward = false;
            goBackward = false;
            goRight = true;
            goLeft = false;

        }
    }
}
