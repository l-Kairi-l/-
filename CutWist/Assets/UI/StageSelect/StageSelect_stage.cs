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

    public GameObject Select;

    public float add_a;
    public bool trigger;

    // Start is called before the first frame update
    void Start()
    {
        add_a = 0.003f;
        trigger = false;

        Select.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        Select.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

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
        if (trigger)
        {

            Select.GetComponent<SpriteRenderer>().material.color += new Color(0.0f, 0.0f, 0.0f, add_a);

            if (Select.GetComponent<SpriteRenderer>().material.color.a >= 0.5f)
            {
                add_a = -0.003f;
            }
            if (Select.GetComponent<SpriteRenderer>().material.color.a <= 0.1f)
            {
                add_a = 0.003f;
            }
            if (Input.GetMouseButtonDown(0))
            {
                string s_worldname = "W"+ worldnumber;
                string s_stagename = "_Stage" + stagenumber;

                SceneManager.LoadScene(s_worldname + s_stagename);

                //            // プレハブをGameObject型で取得
                //GameObject obj = (GameObject)Resources.Load("Transition_1");
                //obj.GetComponent<Transition>().SetNextScene(s_name + s_number);

                //// プレハブを元に、インスタンスを生成、
                //Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
            trigger = true;

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
           // trigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
            Select.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            trigger = false;
        }

    }
    }
