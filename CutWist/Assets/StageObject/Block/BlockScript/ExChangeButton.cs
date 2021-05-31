﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExChangeButton : MonoBehaviour
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
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Object")
        {
            transform.parent.gameObject.GetComponent<Animator>().SetBool("On", true);

            transform.parent.gameObject.GetComponent<ExChangeButtonBlock>().Set(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Object")
        {
            transform.parent.gameObject.GetComponent<Animator>().SetBool("On", false);

            transform.parent.gameObject.GetComponent<ExChangeButtonBlock>().Set(false);
        }
    }
}
