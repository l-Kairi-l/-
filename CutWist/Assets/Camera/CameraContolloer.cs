using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContolloer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject PlayCamera;      //メインカメラ格納用
    private GameObject EditCamera;       //サブカメラ格納用 

    bool NowCamera;

    void Start()
    {
        //プレイカメラとエディットカメラをそれぞれ取得
        PlayCamera = GameObject.Find("PlayCamera");
        EditCamera = GameObject.Find("EditCamera");
        //エディットカメラを非アクティブにする
        PlayCamera.SetActive(false);

        NowCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーが押されている間、エディットカメラをアクティブにする
        if (Input.GetKeyDown(KeyCode.F1))
        {
            NowCamera = !NowCamera;
            //サブカメラをアクティブに設定
            PlayCamera.SetActive(NowCamera);
            EditCamera.SetActive(!NowCamera);
        }
    }
}
