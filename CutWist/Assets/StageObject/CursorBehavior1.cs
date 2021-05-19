using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior1 : MonoBehaviour
{

    [SerializeField]
    private GameObject cursor;


    public enum CURSOR1_DIRECTION
    {
        UP,
        DOWN,
    }
    public CURSOR1_DIRECTION direction = CURSOR1_DIRECTION.DOWN;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == CURSOR1_DIRECTION.DOWN)
        {
            float posy = cursor.transform.position.y - speed * Time.deltaTime;

            if (posy <= -27.1f)
            {
                cursor.transform.position = new Vector3(cursor.transform.position.x, 27.21f, cursor.transform.position.z);
            }
            else
            {
                cursor.transform.position = new Vector3(cursor.transform.position.x, posy, cursor.transform.position.z);
            }
        }
        else
        {
            float posy = cursor.transform.position.y + speed * Time.deltaTime;

            if (posy >= 27.21f)
            {
                cursor.transform.position = new Vector3(cursor.transform.position.x, -27.1f, cursor.transform.position.z);
            }
            else
            {
                cursor.transform.position = new Vector3(cursor.transform.position.x, posy, cursor.transform.position.z);
            }
        }
        

    }
}
