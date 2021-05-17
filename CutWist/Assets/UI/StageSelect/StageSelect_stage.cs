using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayData;

public class StageSelect_stage : MonoBehaviour
{

    public GameObject manager;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

    public int stagenumber;
    public int worldnumber;

    public Sprite ClearNot;



    // Start is called before the first frame update
    void Start()
    {
        Star1.GetComponent<Star>().SetTexture(false);
        Star2.GetComponent<Star>().SetTexture(false);
        Star3.GetComponent<Star>().SetTexture(false);

        SaveData data =manager.GetComponent<SaveDataManager>().GetData(worldnumber-1);

        if (data.ClearStar[stagenumber-1]==3)
        {
                Star3.GetComponent<Star>().SetTexture(true);
        }
        if (data.ClearStar[stagenumber - 1] >= 2)
        {
            Star2.GetComponent<Star>().SetTexture(true);
        }
        if (data.ClearStar[stagenumber - 1] >= 1)
        {
            Star1.GetComponent<Star>().SetTexture(true);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = ClearNot;
            Star1.GetComponent<SpriteRenderer>().enabled = false;
            Star2.GetComponent<SpriteRenderer>().enabled = false;
            Star3.GetComponent<SpriteRenderer>().enabled = false;

        }


    }

    // Update is called once per frame
    void Update()
    {
        //SceneManager.LoadScene("World1");

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "CoursolPoint" && Input.GetMouseButtonDown(0))
        {


            string s_name = "Stage";
            string s_number="" + stagenumber;

            SceneManager.LoadScene(s_name + s_number);

            //            // プレハブをGameObject型で取得
            //GameObject obj = (GameObject)Resources.Load("Transition_1");
            //obj.GetComponent<Transition>().SetNextScene(s_name + s_number);

            //// プレハブを元に、インスタンスを生成、
            //Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);

        }
    }

}
