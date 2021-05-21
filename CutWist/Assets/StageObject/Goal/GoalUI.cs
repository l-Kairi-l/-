using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalUI : MonoBehaviour
{
    // Start is called before the first frame update

        public GameObject tex1;
        public GameObject tex2;
        public GameObject tex3;
        public GameObject clock;


    int frame;
    void Start()
    {
        frame = 0;
        tex1.GetComponent<SpriteRenderer>().enabled = false;
        tex2.GetComponent<SpriteRenderer>().enabled = false;
        tex3.GetComponent<SpriteRenderer>().enabled = false;
        clock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (frame >20)
        {
            tex3.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (frame > 40)
        {
            tex2.GetComponent<SpriteRenderer>().enabled = true;

        }
        if (frame > 60)
        {
            tex1.GetComponent<SpriteRenderer>().enabled = true;
            clock.SetActive(true);

        }


        frame++;
    }
}
