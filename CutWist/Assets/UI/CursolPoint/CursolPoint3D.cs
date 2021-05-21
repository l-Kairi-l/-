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
        pos.x -= (Screen.width * 0.5f);
        pos.y -= (Screen.height * 0.5f);

        RectTransform RtPos = GetComponent<RectTransform>();

         RtPos.anchoredPosition = new Vector2(pos.x,pos.y);


    }
}
