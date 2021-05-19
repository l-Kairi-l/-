using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite tex_home;
    public Sprite tex_home2;
    public bool isClear = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
            Image MainSprite = GetComponent<Image>();
            MainSprite.sprite = tex_home2;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isClear)
                {
                    GameObject manager = GameObject.Find("GameManager");
                    // GameObject cleargauge = GameObject.Find("GameUI");
                    // if(cleargauge.GetComponent<ClearGauge>().GetStarCount() > manager.GetComponent<EditManager>().GetClearNumber())
                    //{
                    manager.GetComponent<EditManager>().SetData();
                    //}
                }
                // プレハブをGameObject型で取得
                GameObject obj = (GameObject)Resources.Load("Transition_1");
                obj.GetComponent<Transition>().SetNextScene("WorldSelect");

                // プレハブを元に、インスタンスを生成、
                Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {

            Image MainSprite = GetComponent<Image>();
            MainSprite.sprite = tex_home;
        }
    }

}
