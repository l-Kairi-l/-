using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class FallBlock : KinematicObject
{
    // Start is called before the first frame update

    public bool move;
    void Awake()
    {
        move = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            GameObject player =other.gameObject.GetComponent<PlayerHitBox>().GetPlayer();
            float vec = 0.0f;


            if (player.GetComponent<Player>().transform.position.x < transform.position.x)
            {
                vec = 0.1f * (60 * Time.deltaTime);

            }
            else
            {
                vec = -0.1f*(60*Time.deltaTime);
            }


            //if (player.GetComponent<Player>().move.x < 0.0f)
            //{
            //}
            //else if(player.GetComponent<Player>().move.x > 0.0f)
            //{
            //}

            if (!move)
            {
                vec = 0;
            }

           transform.position += new Vector3(vec, 0.0f, 0.0f);
        }
        if(other.gameObject.tag == "Object")
        {
            move = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Object")
        {
            move = true;
        }

    }

}
