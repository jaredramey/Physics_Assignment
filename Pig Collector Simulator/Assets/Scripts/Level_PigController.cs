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


    //Private variables
    private GameObject[] pigs;
    private Vector3 randPos;
    private int top;
   


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
        }
    }

    void TheEnd()
    {
        
    }
}
