using UnityEngine;
using System.Collections;

public class ClawScript : MonoBehaviour {

    public Pig_Controller grabbedPig;
    private float dropDelay = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (grabbedPig)
        {
            grabbedPig.transform.position = this.transform.position;
            grabbedPig.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity;
            grabbedPig.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
            if (Input.GetButton("Jump"))
            {
                grabbedPig = null;
                dropDelay = 2;
            }
        }
        dropDelay -= Time.deltaTime;
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Claw Trigger!");
        if (other.GetComponent<Pig_Controller>())
        {
            if (dropDelay <= 0 && grabbedPig == null)
            {
                grabbedPig = other.gameObject.GetComponent<Pig_Controller>();
            }
        }
    }
}
