﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour
{
    // Start is called before the first frame update

    public int number;
    AudioSource audioSource;
    bool select;
    void Start()
    {
        select = false;
        Renderer renderer;

        renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        audioSource = GetComponent<AudioSource>();

        if (number > 1)
        {
            int StarValue = 0;
            for (int i = 0; i < 9; i++)
            {
                StarValue += GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(number - 2).ClearStar[i];
            }
            if (StarValue < 20)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (select&& Input.GetMouseButtonDown(0))
        {
            string s_name = "World";
            string s_number = "" + number;
            audioSource.Play();
            // プレハブをGameObject型で取得
            GameObject obj = (GameObject)Resources.Load("Transition_1");
            obj.GetComponent<Transition>().SetNextScene(s_name + s_number);

            // プレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);

        }

        //     Debug.Log(Input.mousePosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "CoursolPoint")
        {
            Renderer renderer;

            renderer = GetComponent<Renderer>();

            renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            Debug.Log(transform.position);
            select = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "CoursolPoint" )
        {

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "CoursolPoint")
        {
            Renderer renderer;

            renderer = GetComponent<Renderer>();

            renderer.material.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);

            select = false;
        }
    }


}
