using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExChangeButtonBlock : MonoBehaviour
{
    public bool open;

    private Animator animator;

    public GameObject ChangeMatrialObject;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("On", false);
        ChangeMatrialObject.GetComponent<Renderer>().material.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Set(bool type)
    {
        if (type)
        {
            open = !open;
          
            ChangeMatrialObject.GetComponent<Renderer>().material.color = (open)?Color.blue: Color.red;
        }
        else
        {
            ChangeMatrialObject.GetComponent<Renderer>().material.color = (open) ? Color.blue : Color.red;
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
