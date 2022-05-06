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

    public void PelletMode()
    {
        if(CORE.score >= 1)
        {
          void OnTriggerEnter(Collider other)
            {
                if (other.gameObject.tag.Equals("Ghost"))
                {
                    CORE.score++;
                    Destroy(theghostAgent);

                }
            }
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
