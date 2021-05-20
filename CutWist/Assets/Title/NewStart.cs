﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayData;
public class NewStart : MonoBehaviour
{
    private bool trigger;

    public Sprite off;
    public Sprite on;

    public GameObject UI;

    private SaveData[] data = new SaveData[3];
    // Start is called before the first frame update
    void Start()
    {
       // data 
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            if (Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < 3; i++)
                {
                    data[i] = UI.GetComponent<SaveDataManager>().GetData(i);
                    data[i].Init(i);

                    UI.GetComponent<SaveDataManager>().Save(i);
                }
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
            trigger = true;
            GetComponent<SpriteRenderer>().sprite = on;

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
            trigger = false;
            GetComponent<SpriteRenderer>().sprite = off;

        }

    }

}
