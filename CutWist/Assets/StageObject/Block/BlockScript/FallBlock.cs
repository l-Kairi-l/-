using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class FallBlock : MonoBehaviour /*: KinematicObject*/
{
    // Start is called before the first frame update

    public bool AddPlayer;
    
    void Awake()
    {
        AddPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            GameObject player =other.gameObject.GetComponent<PlayerHitBox>().GetPlayer();
            float vec = 0.0f;


            if (player.GetComponent<Player>().transform.position.x < transform.parent.gameObject.transform.position.x)
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

            if (!AddPlayer)
            {
                vec = 0;
            }

            transform.parent.gameObject.transform.position += new Vector3(vec, 0.0f, 0.0f);
        }
        if(other.gameObject.tag == "Object")
        {
            //if (player.GetComponent<Player>().transform.position.x < transform.parent.gameObject.transform.position.x)
            //{
            //    if (other.gameObject.transform.position.x < transform.parent.gameObject.transform.position.x)
            //    {
            //        AddPlayer = true;
            //    }
            //    else
            //    {
            //        AddPlayer = false;
            //    }
            //}
            //else
            //{
            //    if (other.gameObject.transform.position.x > transform.parent.gameObject.transform.position.x)
            //    {
            //        AddPlayer = true;
            //    }
            //    else
            //    {
            //        AddPlayer = false;
            //    }

            //}

            AddPlayer = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Object")
        {
            AddPlayer = true;
        }

    }

}
