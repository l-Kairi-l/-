using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUI_EX : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Number10;
    public GameObject Number1;
    public int StarValue;
    public int NowStarValue;
    public int StageNum;


    void Start()
    {
        if (GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(StageNum-1).EX_Stage)
        {
            Destroy(gameObject);
        }


        Number10.GetComponent<Number>().SetType(StarValue / 10);
        Number1.GetComponent<Number>().SetType(StarValue % 10);
        

        for (int w = 0; w < 4; w++)
        {
            for (int i = 0; i < 9; i++)
            {
                NowStarValue += GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(w).ClearStar[i];

                if (w == 3 && i == 2) break;//EXは3ステージしかないので
            }
        }
        for (int w = 0; w < 3; w++) NowStarValue -= (GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(w).EX_Stage) ? 27 : 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
