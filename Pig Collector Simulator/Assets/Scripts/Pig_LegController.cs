using UnityEngine;
using System.Collections;

public class Pig_LegController : MonoBehaviour
{

    private GameObject PigBody;
    public Vector3 PigBodyVel;

    // Use this for initialization
    void Start()
    {
        //Get the body of the pig
        PigBody = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        PigBodyVel = PigBody.GetComponent<Rigidbody>().velocity;
    }

    /*
     * This function is made to launch the pig in the opposite dirrection of whichever leg hits the ground
    */
    void OnCollisionEnter(Collision collision)
    {
        /*
         * TODO:
         * Need to figure out a way to make the pig bounce when the legs hit the ground
        */
        PigBody.GetComponent<Rigidbody>().velocity = -PigBody.GetComponent<Rigidbody>().velocity;
    }
}
