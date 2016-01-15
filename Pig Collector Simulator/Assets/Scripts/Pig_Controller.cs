using UnityEngine;
using System.Collections;

public class Pig_Controller : MonoBehaviour
{
    /*
     * Custom class for the Pigs that will allow them to bounce infinitly.
     * Will also add functionality later on that will allow them to bounce
     * off in the opposite direction of when the feet touch.
     =
     =
     * Credit to OnCollisionEnter function: Powenko
     *                                Link: http://forum.unity3d.com/threads/the-perfect-bouncing-ball.25804/
    */

    // Use this for initialization
    void Start()
    {
        //print("Test Start");
    }

    // Update is called once per frame
    void Update()
    {
        //print("Test Update");
    }


    private bool firstTimeVelocitySave = false;
    public Vector3 savedVelocity;
    public float BounceRate = 1.5f;

    void OnCollisionEnter(Collision collision)
    {
        if (!firstTimeVelocitySave)
        {
            //print("Collision!"); //<--- Testing to make sure function works properly
            //Get the objects velocity
            savedVelocity = gameObject.GetComponent<Rigidbody>().velocity;
            //savedVelocity.y = (savedVelocity.x + savedVelocity.z) / 2
            firstTimeVelocitySave = true;
        }

        //Reset the velocity to ignore any velocity loss
        gameObject.GetComponent<Rigidbody>().velocity = savedVelocity;
        //Decrement y velocity over time however the user may want
        //savedVelocity.x = savedVelocity.x / BounceRate;
        //savedVelocity.y = savedVelocity.y / BounceRate;
        //savedVelocity.z = savedVelocity.z / BounceRate;
    }
}
