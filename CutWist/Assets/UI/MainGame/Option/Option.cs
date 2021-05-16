using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI_home;
    public GameObject UI_return;
    public GameObject UI_replay;


    GameObject cursor;

    private int bufmode;//その時のカーソルモード

    void Start()
    {

        //名前を検索してプレハブを参照する
        GameObject obj = (GameObject)Resources.Load("CoursolPoint3D");
        //書き換え終わったプレハブのクローンをインスタンス化する
        Instantiate(obj, new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);

        cursor = GameObject.Find("CoursolPoint3D(Clone)");

        //カーソルモードを変更する
        GameObject player = GameObject.Find("Player");
        bufmode = player.GetComponent<Player>().CursorMode;
        player.GetComponent<Player>().CursorMode = -2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UnInit()
    {
        //カーソルモードを変更する
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Player>().CursorMode = bufmode;

        Destroy(cursor);
        Destroy(gameObject);
    }



}
