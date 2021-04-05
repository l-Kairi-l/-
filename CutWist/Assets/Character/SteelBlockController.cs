using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelBlockController : MonoBehaviour
{
    bool setOff;
    BoxCollider2D colliderOfGround;
    // Start is called before the first frame update
    void Start()
    {
        colliderOfGround = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (setOff)
        {
            colliderOfGround.enabled = false;
        }
        if (!setOff)
        {
            colliderOfGround.enabled = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            setOff = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            setOff = false;
        }
    }
}
