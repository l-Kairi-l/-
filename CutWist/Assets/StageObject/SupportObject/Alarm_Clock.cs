﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm_Clock : MonoBehaviour
{
    // Start is called before the first frame update
    bool Flag;
    void Start()
    {
        Flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Flag)
        {
            transform.position=new Vector3(-0.3f, 0.51f, -28.04f);


            transform.rotation= new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

            transform.localScale = new Vector3(0.0299019f, 0.0299019f, 0.0299019f);
        }
        else
        {

            transform.Rotate(new Vector3(0.0f, 2.0f, 0.0f));

        }
    }

    //時計をどうするか

    public void Set(bool flag)
    {
        Flag = flag;
    }
}
