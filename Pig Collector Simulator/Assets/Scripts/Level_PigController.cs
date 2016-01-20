using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level_PigController : MonoBehaviour
{
    /*
     * The purpouse of this script is to keep track of and control all pigs    
     * in a given level.
    */

    //All variables needed

    //Stuff user needs to set
    public GameObject pigPen_Controller;
    public GameObject pigPrefab;
    public int numPigsToSpawn;
    public GameObject minSpawnPos, maxSpawnPos;
    public Text pigsRemaning_UI;
    public Text WinningText;
    public float randVel;
    public float delay;
    public GameObject particleToCreate;


    //Private variables
    private GameObject[] pigs;
    private Vector3 randPos;
    private int top;
    private bool particlesHaveSpawned = false;
   


    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < numPigsToSpawn; i++)
        {
            SpawnPigs();
        }

        pigs = GameObject.FindGameObjectsWithTag("Pig");
        print("" + pigs.Length);
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * TODO:
         * Check to see if all pigs are in the pen
         * If all pigs are in the pen then activate "The Ending"
         * Put player back to main menu (if we have one)
        */

        CheckPen();
        UpdateUI();
    }

    Vector3 ChooseRandomPos(Vector3 minPos, Vector3 maxPos)
    {
        Vector3 chosenPos = new Vector3();

        chosenPos.x = Random.Range(minPos.x, maxPos.x);
        chosenPos.y = Random.Range(minPos.y, maxPos.y);
        chosenPos.z = Random.Range(minPos.z, maxPos.z);

        return chosenPos;
    }

    void SpawnPigs()
    {
        randPos = ChooseRandomPos(minSpawnPos.transform.position, maxSpawnPos.transform.position);

        Instantiate(pigPrefab, randPos, pigPrefab.transform.rotation);
    }

    void CheckPen()
    {
        //Check to see how many pigs are in the pen
        //pigPen_Controller = pigPen_Controller.GetComponent<PigPen_Controller>();

        int ActualPigs_InPen = pigPen_Controller.GetComponent<PigPen_Controller>().pigsInPen / 5;

        if(ActualPigs_InPen == pigs.Length)
        {
            print("All pigs have been collected");
        }
    }

    void UpdateUI()
    {
        int numPigsRemaining = numPigsToSpawn - (pigPen_Controller.GetComponent<PigPen_Controller>().pigsInPen / 5);

        pigsRemaning_UI.text = numPigsRemaining.ToString();

        if(numPigsRemaining <= 0)
        {
            WinningText.text = "You Win!";
            TheEnd();
        }
    }

    void TheEnd()
    {
        /*
         * TODO:
         * - Add a random velocity to each pig
         * - Destroy each pig limb
         * - Add particle effect to each limb
        */

        RandomVel();
        DestroyLimbs();

    }

    void RandomVel()
    {
        /*
         * TODO:
         * Add a random velocity in a random direction 
        */
        //PigBody.GetComponent<Rigidbody>().velocity = -PigBody.GetComponent<Rigidbody>().velocity;
        //Get a random direction
        foreach (GameObject pig in pigs)
        {
            int randDir = Random.Range(0, 4);
            float actRandVel = Random.Range(0, randVel);
            switch (randDir)
            {
                //Back
                case 0:
                    //Print out to make sure this is working
                    //print("back");
                    pig.GetComponent<Rigidbody>().velocity += Vector3.back * Random.Range(0, actRandVel);
                    break;
                //Forward
                case 1:
                    // print("forward");
                    pig.GetComponent<Rigidbody>().velocity += Vector3.forward * Random.Range(0, actRandVel);
                    break;
                //Left
                case 2:
                    //print("left");
                    pig.GetComponent<Rigidbody>().velocity += Vector3.left * Random.Range(0, actRandVel);
                    break;
                //Right
                case 3:
                    //print("right");
                    pig.GetComponent<Rigidbody>().velocity += Vector3.right * Random.Range(0, actRandVel);
                    break;
                //Up
                case 4:
                    //print("up");
                    pig.GetComponent<Rigidbody>().velocity += Vector3.up * Random.Range(0, actRandVel);
                    break;

                //If something happens to out of scope my rand
                //default will just keep the pig going
                default:
                    //print("default");
                    break;
            }
        }

    }

    void DestroyLimbs()
    {
        foreach(GameObject pig in pigs)
        {
            // Emtpy Game Object Wrapper
            Destroy(pig.GetComponent<HingeJoint>(), delay);

            /*
             * Have to drig through each layer to check every object
            */
            foreach (Transform child in pig.transform)
            {
                /*
                 * Have to drig through each layer to check every object
                */
                //Body of pig
                if (child.gameObject.GetComponent<HingeJoint>())
                {
                    if (particlesHaveSpawned == false)
                    {
                        //create new particle as a gameobject
                        GameObject tempObject = (GameObject)Instantiate(particleToCreate, pig.transform.position, Quaternion.identity);
                        //set parent as the latest gameObject
                        tempObject.transform.parent = child.transform;
                    }
                    Destroy(child.gameObject.GetComponent<HingeJoint>(), delay);
                }

                foreach (Transform subChild in child.gameObject.transform)
                {
                    /*
                     * Have to drig through each layer to check every object
                    */
                    //Legs back/ legs front
                    foreach (Transform subSubChild in subChild.gameObject.transform)
                    {
                        //print(subSubChild.gameObject.name);
                        if (subSubChild.gameObject.GetComponent<HingeJoint>())
                        {
                            if (particlesHaveSpawned == false)
                            {
                                //create new particle as a gameobject
                                GameObject tempObject = (GameObject)Instantiate(particleToCreate, pig.transform.position, Quaternion.identity);
                                //set parent as the latest gameObject
                                tempObject.transform.parent = subSubChild.transform;
                            }
                            Destroy(subSubChild.gameObject.GetComponent<HingeJoint>(), delay);
                        }
                    }
                }
            }
        }

        particlesHaveSpawned = true;
    }

    void BloodyTime()
    {

    }


}
