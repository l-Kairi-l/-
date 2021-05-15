using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditManager : MonoBehaviour
{
    //カメラの操作
    public GameObject CameraManager;
    //背景の操作
    public GameObject BackGroundManager;
    //ステージのUIの操作
    public GameObject StageUIManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void SetEditMode(bool mode)
    {
        //true==EditCameraモード false==PlayCameraモード

        //カメラモードの変更
        CameraManager.GetComponent<CameraContolloer>().SetCameraType(mode);
        //背景の操作
        BackGroundManager.GetComponent<BackGround>().SetBackGroundType(mode);

        //if (mode) {
        //    StageUIManager.GetComponent<SpriteRenderer>().material.color = new Color(1.0f,1.0f,1.0f,0.0f);
        //}
        //else
        //{
        //    StageUIManager.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        //}

    }
}
