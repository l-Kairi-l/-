using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect_stage : MonoBehaviour
{
    public int stagenumber;
    // Start is called before the first frame update
    void Start()
    {
        
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
