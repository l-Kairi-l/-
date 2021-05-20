using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public GameObject Door;
    
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
        if (other.gameObject.tag == "Player"|| other.gameObject.tag == "Object")
        {
            Door.GetComponent<DoorBlock>().Set(true);
            transform.root.gameObject.GetComponent<Animator>().SetBool("On",true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"||other.gameObject.tag == "Object")
        {
            Door.GetComponent<DoorBlock>().Set(false);
            transform.root.gameObject.GetComponent<Animator>().SetBool("On", false);

        }
    }
}
