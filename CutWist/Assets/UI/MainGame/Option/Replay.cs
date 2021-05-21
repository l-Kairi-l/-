using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    public Sprite tex_replay;
    public Sprite tex_replay2;
    public bool isClear = false;
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
            MainSprite.sprite = tex_replay2;
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.Play();
                if (isClear)
                {
                    GameObject manager = GameObject.Find("GameManager");
                    // GameObject cleargauge = GameObject.Find("GameUI");
                    // if(cleargauge.GetComponent<ClearGauge>().GetStarCount() > manager.GetComponent<EditManager>().GetClearNumber())
                    //{
                    manager.GetComponent<EditManager>().SetData();
                    //}
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 現在シーンのリロード
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {

            Image MainSprite = GetComponent<Image>();
            MainSprite.sprite = tex_replay;

        }
    }

}
