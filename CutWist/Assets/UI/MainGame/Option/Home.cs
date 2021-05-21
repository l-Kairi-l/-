using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    public Sprite tex_home;
    public Sprite tex_home2;
    public bool isClear = false;

    private bool select;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (select)
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
                audioSource.Play();
                GameObject sound = GameObject.FindGameObjectWithTag("Sound");
                if (sound != null)
                {
                    Destroy(sound);
                }
                GameObject sd = (GameObject)Resources.Load("SoundTitle");
                Instantiate(sd, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

                // プレハブをGameObject型で取得
                GameObject obj = (GameObject)Resources.Load("Transition_1");
                obj.GetComponent<Transition>().SetNextScene("WorldSelect");

                // プレハブを元に、インスタンスを生成、
                Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);
            }
        }

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
            Image MainSprite = GetComponent<Image>();
            MainSprite.sprite = tex_home2;
            select = true;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {

            Image MainSprite = GetComponent<Image>();
            MainSprite.sprite = tex_home;
            select = false;
        }
    }

}
