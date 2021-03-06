﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFrame : MonoBehaviour
{
    bool collision;
    public int number;//どのワールドなのか
                      // List<GameObject> numberLists = new List<GameObject>();

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;

    private int Count;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        collision = false;
        c1.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        c2.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        c3.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (collision)
        {
            transform.position -= new Vector3(0.0f, 0.05f, 0.0f);
            if (transform.position.y <= 5.0f)
            {
                transform.position = new Vector3(transform.position.x, 5.0f, transform.position.z);
            }

        }
        else
        {
            transform.position += new Vector3(0.0f, 0.05f, 0.0f);
            if (transform.position.y >= 10.0f)
            {
                transform.position = new Vector3(transform.position.x, 10.0f, transform.position.z);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "CoursolPoint")
        {
            collision = true;
            Count++;
        }
        if (Count > 30)
        {
            c1.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (Count > 20)
        {
            c2.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (Count > 10)
        {
            c3.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "CoursolPoint")
        {
            //  transform.localScale = new Vector3(0.7f, 1.1f, 0.0f);
            collision = false;
            c3.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            c2.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            c1.GetComponent<SpriteRenderer>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            Count = 0;
        }
    }

}
