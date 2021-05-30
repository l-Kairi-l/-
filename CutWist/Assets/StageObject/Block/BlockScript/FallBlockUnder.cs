using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlockUnder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Object")
        {
            if (transform.parent.gameObject.transform.position.y> other.transform.position.y)
            {
                transform.parent.gameObject.transform.position = new Vector3((int)(transform.position.x), 
                    transform.position.y+ 0.2f, transform.position.z);

            }
            //   transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Object")
        {
            if (transform.parent.gameObject.transform.position.y > other.transform.position.y)
            {

            }

          //      transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

}
