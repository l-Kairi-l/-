﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    // Start is called before the first frame update
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

        }
        if (other.gameObject.name == "GoalSheep")
        {

        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

        }
        if (other.gameObject.name == "GoalSheep")
        {

        }


    }

}
