using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpScript : MonoBehaviour
{
    public GameObject theOtherTp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
            other.gameObject.transform.position = this.theOtherTp.transform.position;
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
