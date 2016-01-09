using UnityEngine;
using System.Collections;

public class PigPen_Controller : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        print("Collision w/ pen!");
        if (collision.gameObject.tag.ToString() == "Pig")
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }
}
