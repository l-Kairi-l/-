using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExChangeDoorBlock : MonoBehaviour
{
    private Animator animator;
    public GameObject ButtonBlock;
    public bool DoorOpen;

    public GameObject ChangeMatrialObject;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Open", false);
    }

    // Update is called once per frame
    void Update()
    {
       // if (Button.GetComponent<ExChangeButton>().Change == 1)
        {
            Set(ButtonBlock.GetComponent<ExChangeButtonBlock>().open);
        }
    }

    public void Set(bool type)
    {
        animator.SetBool("Open", (type)?!DoorOpen:DoorOpen);

        GetComponent<BoxCollider2D>().enabled = (type)?DoorOpen:!DoorOpen;
        if (type)
        {
            ChangeMatrialObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            ChangeMatrialObject.GetComponent<Renderer>().material.color = Color.red;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //     animator.SetBool("On", true);

        //}
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //  animator.SetBool("On", false);

    }
}
