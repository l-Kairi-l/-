using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(2.7f, 2.7f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();


    }

    public void SetBackGroundType(bool type)
    {
        if(type)
        {
            transform.localScale = new Vector3(5.4f,5.4f,1.0f);

        }
        else
        {
            transform.localScale = new Vector3(2.7f,2.7f,1.0f);

        }
    }

}
