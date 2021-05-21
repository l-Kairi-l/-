using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Next : MonoBehaviour
{
    AudioSource audioSource;
    public Sprite tex_next;
    public Sprite tex_next2;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            MainSprite.sprite = tex_next2;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.Play();

                GameObject manager = GameObject.Find("GameManager");
                //GameObject cleargauge = GameObject.Find("GameUI_" + GameObject.Find("GameManager").GetComponent<EditManager>().WorldNumber);
                //if (cleargauge.GetComponent<ClearGauge>().GetStarCount() > manager.GetComponent<EditManager>().GetClearNumber())
                //{
                //    manager.GetComponent<EditManager>().SetClearNumber(cleargauge.GetComponent<ClearGauge>().GetStarCount());
                //}
                manager.GetComponent<EditManager>().SetData();
                // プレハブをGameObject型で取得
                GameObject obj = (GameObject)Resources.Load("Transition_1");
                string s_worldname = "W" + manager.GetComponent<EditManager>().WorldNumber;
                string s_stagename = "_Stage" + (manager.GetComponent<EditManager>().StageNumber + 1);
                obj.GetComponent<Transition>().SetNextScene(s_worldname + s_stagename);

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
            MainSprite.sprite = tex_next;
        }
    }
}
