using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior2 : MonoBehaviour
{

    [SerializeField]
    private GameObject cursor;


    public enum CURSOR2_DIRECTION
    {
        LEFT,
        RIGHT,
    }
    public CURSOR2_DIRECTION direction = CURSOR2_DIRECTION.LEFT;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == CURSOR2_DIRECTION.LEFT)
        {
            float posx = cursor.transform.position.x - speed * Time.deltaTime;

            if (posx <= -49.6f)
            {
                cursor.transform.position = new Vector3( 49.6f, cursor.transform.position.y, cursor.transform.position.z);
            }
            else
            {
                cursor.transform.position = new Vector3( posx, cursor.transform.position.y, cursor.transform.position.z);
            }
        }
        else
        {
            float posx = cursor.transform.position.x + speed * Time.deltaTime;

            if (posx >= 49.6f)
            {
                cursor.transform.position = new Vector3(-49.6f, cursor.transform.position.y, cursor.transform.position.z);
            }
            else
            {
                cursor.transform.position = new Vector3(posx, cursor.transform.position.y, cursor.transform.position.z);
            }
        }


    }
}
