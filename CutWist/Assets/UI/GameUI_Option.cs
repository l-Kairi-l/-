using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI_Option : MonoBehaviour
{
    bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger&& Input.GetMouseButtonDown(0))
        {
            //名前を検索してプレハブを参照する
            GameObject obj = (GameObject)Resources.Load("Option");
            //書き換え終わったプレハブのクローンをインスタンス化する
            Instantiate(obj, Vector3.zero, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "CoursolPoint")
        {
             trigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
            trigger = false;
        }
    }

}
