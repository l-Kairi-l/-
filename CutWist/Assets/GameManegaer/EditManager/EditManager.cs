using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditManager : MonoBehaviour
{
    //カメラの操作
    public GameObject CameraManager;
    //背景の操作
    public GameObject BackGroundManager;
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

    }
}
