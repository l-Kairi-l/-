using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursolPoint3D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = Input.mousePosition;
        //座標を真ん中に持ってくる
        pos.x -= (1920.0f * 0.5f);
        pos.y -= (1080.0f * 0.5f);

        RectTransform RtPos = GetComponent<RectTransform>();

         RtPos.anchoredPosition = new Vector2(pos.x,pos.y);


    }
}
