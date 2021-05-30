using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayData;

public class WorldSelectKey : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Key_Up;
    bool trigger;
    public float add_a;
    public GameObject Select;

    private bool animetion;
    public int StageNum;


    void Start()
    {
        animetion = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger&& !animetion)
        {
            int star=0;

            for (int w = 0; w < 4; w++)
            {
                for (int i = 0; i < 9; i++)
                {
                    star += GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(w).ClearStar[i];

                    if (w == 3 && i == 2) break;//EXは3ステージしかないので
                }
                
               
            }
            for (int w = 0; w < 3; w++) star -= (GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(w).EX_Stage) ? 27 : 0;




            //必要個数持ってたら
            if (star >= 27)
            {
                Select.GetComponent<SpriteRenderer>().color += new Color(0.0f, 0.0f, 0.0f, add_a * (Time.deltaTime * 60));

                if (Select.GetComponent<SpriteRenderer>().color.a >= 0.5f)
                {
                    add_a = -0.03f * (Time.deltaTime * 60);
                }
                if (Select.GetComponent<SpriteRenderer>().color.a <= 0.1f)
                {
                    add_a = 0.03f * (Time.deltaTime * 60);
                }
                if (Input.GetMouseButtonDown(0))
                {
                    Select.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f,0.0f);

                    animetion = true;

                    SaveData data = GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(StageNum - 1);
                    data.EX_Stage = true;

                    GameObject.Find("GameManager").GetComponent<SaveDataManager>().SetData(StageNum - 1, data);

                    GameObject.Find("GameManager").GetComponent<SaveDataManager>().Save(StageNum - 1);

                    GameObject.Find("Extra").GetComponent<WorldSelectUI>().ResetValue();

                }
            }
        }

        if (animetion)
        {
            Key_Up.transform.position += new Vector3(0,0.01f,0.0f);

            if (Key_Up.transform.position.y > -6)
            {
                transform.root.gameObject.GetComponent<StageSelect_stage>().ResetStage();

                Destroy(transform.parent.gameObject);
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
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
            trigger = false;

        }
    }

}
