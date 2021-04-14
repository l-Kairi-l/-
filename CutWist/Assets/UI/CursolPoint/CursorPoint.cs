using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //x=23
        //y=15
        float per_W = 23.0f / 2300;
        float per_H = 15.0f / 1500;

        Vector3 pos =Input.mousePosition;
        //座標を真ん中に持ってくる
        pos.x += -2300;
        pos.y += -1500;
        //座標を正規化する
        pos.x *= per_W;
        pos.y *= per_H;
        pos.z = -10.0f;

        transform.position = pos;

       // Debug.Log(transform.position);

        //  transform.position = Input.mousePosition;


    }
}
