using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContolloer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject PlayCamera;      //メインカメラ格納用
    private GameObject EditCamera;       //サブカメラ格納用 

    void Start()
    {


        ////プレイカメラとエディットカメラをそれぞれ取得
        //PlayCamera = GameObject.Find("PlayCamera");
        //EditCamera = GameObject.Find("EditCamera");
        ////エディットカメラを非アクティブにする
        //EditCamera.SetActive(false);

      //  NowCamera = true;
    }
    private void Update()
    {
    }

}
