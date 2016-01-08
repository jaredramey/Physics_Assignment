using UnityEngine;
using System.Collections;

public class Coppter : MonoBehaviour {

    private Rigidbody thisBody;

    public float controlSpeed = 1;
    public float turnSpeed = 1;
    public float liftPower = 1;
    public float dropSpeed = 1;
    

	void Start () {
        thisBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        thisBody.AddForce(transform.forward * controlSpeed * Input.GetAxis("Vertical"));
        thisBody.AddTorque(0, Input.GetAxis("Horizontal") * turnSpeed, 0);
        if (Input.GetButton("Fire1"))
        {
            thisBody.AddForce(0, liftPower, 0);
        }
        if (Input.GetButton("Fire2"))
        {
            thisBody.AddForce(0, -dropSpeed, 0);
        }
	}
}
