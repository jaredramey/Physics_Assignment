using UnityEngine;
using System.Collections;

public class Pig_LegController : MonoBehaviour
{

    private GameObject PigBody;
    //Set maximum velocity possible to add
    public int randVel;

    // Use this for initialization
    //Using awake instead of start in this script since pigs are spawned in at runtime
    void Awake()
    {
        //Get the body of the pig
        //Yes I have to dig up the tree quite a bit to get the proper object
        PigBody = transform.parent.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * If anything ends up needing to be updated
        */
    }

    /*
     * This function is made to launch the pig in the opposite dirrection of whichever leg hits the ground
    */
    void OnCollisionEnter(Collision collision)
    {
        /*
         * TODO:
         * Add a random velocity in a random direction 
        */
        //PigBody.GetComponent<Rigidbody>().velocity = -PigBody.GetComponent<Rigidbody>().velocity;
        //Get a random direction
        int randDir = Random.Range(0, 4);
        float actRandVel = Random.Range(0, randVel);
        switch(randDir)
        {
            //Back
            case 0:
                //Print out to make sure this is working
                //print("back");
                PigBody.GetComponent<Rigidbody>().velocity += Vector3.back * Random.Range(0, actRandVel);
                break;
            //Forward
            case 1:
               // print("forward");
                PigBody.GetComponent<Rigidbody>().velocity += Vector3.forward * Random.Range(0, actRandVel);
                break;
            //Left
            case 2:
                //print("left");
                PigBody.GetComponent<Rigidbody>().velocity += Vector3.left * Random.Range(0, actRandVel);
                break;
            //Right
            case 3:
                //print("right");
                PigBody.GetComponent<Rigidbody>().velocity += Vector3.right * Random.Range(0, actRandVel);
                break;
            //Up
            case 4:
                //print("up");
                PigBody.GetComponent<Rigidbody>().velocity += Vector3.up * Random.Range(0, actRandVel);
                break;

            //If something happens to out of scope my rand
            //default will just keep the pig going
            default:
                //print("default");
                break;
        }
        
    }

    /*Quick little randomizer funtion that can be coppied over to any other script*/
    //float Randomizer(int seed)
    //{
    //    //Random number to return
    //    float rand = 0;

    //    //Set the seed
    //    Random.seed = seed;

    //    return rand = Random.value;
    //}

    // ^^^ saving this code block for later reference
}
