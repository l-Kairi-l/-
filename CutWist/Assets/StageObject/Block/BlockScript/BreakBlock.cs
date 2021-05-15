using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    private int Frame;

    // Start is called before the first frame update
    void Start()
    {
        Frame = -1;
    }

    // Update is called once per frame
    void Update()
    {

        {
            if (Frame >= 0)
            {

                Frame++;
            }
            if (Frame > 30)
            {
                gameObject.GetComponent<Renderer>().material.color += new Color(0.0f, 0.0f, 0.0f, -0.00666667f);
            }
            if (Frame > 150)
            {
                Destroy(gameObject);
            }

        }
    }
        private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Frame = 0;
        }
        if (other.gameObject.name == "GoalSheep")
        {

        }
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
