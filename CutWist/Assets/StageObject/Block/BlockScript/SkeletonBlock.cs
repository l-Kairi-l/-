using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Block;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Block.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (other.gameObject.name == "GoalSheep")
        {
            Block.GetComponent<BoxCollider2D>().enabled = false;
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Block.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (other.gameObject.name == "GoalSheep")
        {
            Block.GetComponent<BoxCollider2D>().enabled = true;
        }


    }


}
