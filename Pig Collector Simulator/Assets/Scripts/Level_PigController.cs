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

    // Use this for initialization
    void Start()
    {
        pigs = GameObject.FindGameObjectsWithTag("Pig");
        print("" + pigs.Length);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
