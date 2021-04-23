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
        float per_W = 26.6f / (1920.0f*0.5f);
        float per_H = 15.0f / (1080.0f*0.5f);

        Vector3 pos =Input.mousePosition;
        //座標を真ん中に持ってくる
        pos.x -= (1920.0f * 0.5f);
        pos.y -= (1080.0f * 0.5f);
        //座標を正規化する
        pos.x *= per_W;
        pos.y *= per_H;
        pos.z = -10.0f;

        transform.position = pos;

       // Debug.Log(transform.position);

        //  transform.position = Input.mousePosition;


    }
}
