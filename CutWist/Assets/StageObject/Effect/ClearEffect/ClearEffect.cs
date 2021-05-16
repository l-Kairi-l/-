using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearEffect : MonoBehaviour
{
    //clearの絵
    public GameObject ClearTexture;
    //横になっている牛のオブジェクト
  //  public GameObject sheep;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;

        ClearTexture.transform.position = new Vector3(0.0f, 0.1f, -2.0f);
        ClearTexture.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
        //    sheep.transform.Rotate(new Vector3(0.0f, 2.0f, 0.0f));


            ClearTexture.transform.localScale += new Vector3(0.01f,0.01f,0.0f);
            ClearTexture.GetComponent<SpriteRenderer>().material.color = new Color(1.0f,1.0f,1.0f,1.0f);

            if (ClearTexture.transform.localScale.x >= 0.7f|| ClearTexture.transform.localScale.y >= 0.7f)
            {
                // プレハブをGameObject型で取得
                GameObject obj = (GameObject)Resources.Load("Transition_1");
                obj.GetComponent<Transition>().SetNextScene("World1");

                // プレハブを元に、インスタンスを生成、
                Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);

            }
        }
    }

    public void Set(Vector3 pos)
    {
        flag = true;

        //名前を検索してプレハブを参照する
        GameObject obj = (GameObject)Resources.Load("GoalSheep2");


        //書き換え終わったプレハブのクローンをインスタンス化する
        Instantiate(obj, new Vector3(pos.x,
            pos.y, pos.z), Quaternion.identity);


      //  sheep = GameObject.Find("GoalSheep2(Clone)");

        ClearTexture.transform.localScale = new Vector3(0.001f, 0.001f, 0.0f);
        ClearTexture.transform.position = new Vector3(0.0f, 0.1f, -2.0f);

    }
}
