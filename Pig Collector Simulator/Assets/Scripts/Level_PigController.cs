using UnityEngine;
using System.Collections;

public class Level_PigController : MonoBehaviour
{
    /*
     * The purpouse of this script is to keep track of and control all pigs    
     * in a given level.
    */

    //All variables needed
    public GameObject[] pigs;
    public GameObject corrall;
    public GameObject pigPen_Controller;

    // Use this for initialization
    void Start()
    {
        pigs = GameObject.FindGameObjectsWithTag("Pig");
        print("" + pigs.Length);

        pigPen_Controller = GameObject.Find("Level_PigContoller");
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
    }

    void CheckPen()
    {
        //Check to see how many pigs are in the pen
        PigPen_Controller controller = pigPen_Controller.GetComponent<PigPen_Controller>();

        int ActualPigs_InPen = controller.pigsInPen / 4;

        if(ActualPigs_InPen == pigs.Length)
        {
            print("All pigs have been collected");
        }
    }

    void TheEnd()
    {

    }
}
