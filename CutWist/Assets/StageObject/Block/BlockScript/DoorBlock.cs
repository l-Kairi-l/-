using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlock : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // animator.SetBool("Open", false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set(bool type)
    {
        animator.SetBool("Open", type);

        GetComponent<BoxCollider2D>().enabled = !type;
    }

}
