using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayData;

public class EditManager : MonoBehaviour
{
    //カメラの操作
   // public GameObject CameraManager;
    //背景の操作
   // public GameObject BackGroundManager;
    //ステージのUIの操作
  //  public GameObject StageUIManager;
    private GameObject player;

    public int WorldNumber;
    public int StageNumber;

    SaveData data;

    void Start()
    {

        //カーソルモードを変更する
        player = GameObject.Find("Player");

        data = GetComponent<SaveDataManager>().GetData(WorldNumber - 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().CursorMode != -2 && player.GetComponent<Player>().CursorMode != -3)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 現在シーンのリロード
            }
            if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)||Input.GetKeyDown(KeyCode.Escape))
            {
                //名前を検索してプレハブを参照する
                GameObject obj = (GameObject)Resources.Load("Option");
                //書き換え終わったプレハブのクローンをインスタンス化する
                Instantiate(obj, Vector3.zero, Quaternion.identity);

            }
        }
    }
    //星の格納
    public void SetClearNumber(int number)
    {
        data.ClearStar[StageNumber-1] = number;
    }
    //前回の星の取得
    public int GetClearNumber()
    {
        return data.ClearStar[StageNumber-1];
    }

    //save
    public void SetData()
    {
        GetComponent<SaveDataManager>().SetData(WorldNumber-1,data);
        GetComponent<SaveDataManager>().Save(WorldNumber - 1);

        
    }

}
