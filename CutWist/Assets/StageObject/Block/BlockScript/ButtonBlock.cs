using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBlock : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("On", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set(bool type)
    {
             animator.SetBool("On", type);

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
