using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class NeedleManeger : MonoBehaviour
{
    public GameObject Player;
    public GameObject Needle;
    public int Count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Needle");

        Count = objects.Length;

        for (int i = 0; i < Count; i++)
        {
            if (Player.transform.position.x - objects[i].transform.position.x <= 0.1f && Player.transform.position.y - objects[i].transform.position.y < 0.1f)
            {
                Player.GetComponent<Renderer>().material.color = new Color(2.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                Player.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }

        }

        //if (Player.transform.position.x - Needle.transform.position.x <= 0
        //    && Player.transform.position.y - Needle.transform.position.y <= 0)
        //{
        //    Player.GetComponent<Renderer>().material.color = new Color(2.0f, 1.0f, 1.0f, 1.0f);
        //}
        //else
        //{
        //    Player.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        //}
    }
}
