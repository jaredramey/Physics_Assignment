using UnityEngine;
using System.Collections;

public class PigPen_Controller : MonoBehaviour
{
    public int pigsInPen = 0;
    private bool isColliding = false;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        isColliding = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        //print("Collision w/ pen!");
        if (collision.gameObject.tag.ToString() == "Pig" && collision.gameObject.name == "Body")
        {
            if (isColliding) return;
            isColliding = true;

            pigsInPen++;
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            Destroy(collision.gameObject.GetComponent<Pig_Controller>());
            
            //Destroy(collision.gameObject.GetComponent<Pig_LegController>());

            /*
             * Have to drig through each layer to check every object
            */
            foreach (Transform child in collision.gameObject.transform)
            {
                /*
                 * Have to drig through each layer to check every object
                */
                print(child.gameObject.name);
                if (child.gameObject.GetComponent<Pig_Controller>())
                {
                    //print("found a body controller script");
                    Destroy(child.gameObject.GetComponent<Pig_Controller>());
                }

                foreach (Transform subChild in child.gameObject.transform)
                {
                    /*
                     * Have to drig through each layer to check every object
                    */
                    print(subChild.gameObject.name);

                    foreach (Transform subSubChild in subChild.gameObject.transform)
                    {
                        print(subSubChild.gameObject.name);
                        if(subSubChild.gameObject.GetComponent<Pig_LegController>())
                        {
                            //print("found a leg controller script");
                            Destroy(subSubChild.gameObject.GetComponent<Pig_LegController>());
                            pigsInPen++;
                        }
                    }
                }
            }
        }
    }
}
