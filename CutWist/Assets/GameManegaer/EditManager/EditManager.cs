using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditManager : MonoBehaviour
{
    //カメラの操作
   // public GameObject CameraManager;
    //背景の操作
   // public GameObject BackGroundManager;
    //ステージのUIの操作
    public GameObject StageUIManager;
    private GameObject player;


    void Start()
    {

        //カーソルモードを変更する
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().CursorMode != -2)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 現在シーンのリロード
            }
            if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
            {
                //名前を検索してプレハブを参照する
                GameObject obj = (GameObject)Resources.Load("Option");
                //書き換え終わったプレハブのクローンをインスタンス化する
                Instantiate(obj, Vector3.zero, Quaternion.identity);

            }
        }

    }

    //public void SetEditMode(bool mode)
    //{
    //    //true==EditCameraモード false==PlayCameraモード

    //    //カメラモードの変更
    //    CameraManager.GetComponent<CameraContolloer>().SetCameraType(mode);
    //    //背景の操作
    //    BackGroundManager.GetComponent<BackGround>().SetBackGroundType(mode);

    //    //if (mode) {
    //    //    StageUIManager.GetComponent<SpriteRenderer>().material.color = new Color(1.0f,1.0f,1.0f,0.0f);
    //    //}
    //    //else
    //    //{
    //    //    StageUIManager.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    //    //}

    //}
}
