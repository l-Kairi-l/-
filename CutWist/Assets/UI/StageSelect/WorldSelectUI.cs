using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSelectUI : MonoBehaviour
{
    public GameObject Number10;
    public GameObject Number1;
    public int StarValue;

    void Start()
    {
        for (int w = 0; w < 4; w++)
        {
            for (int i = 0; i < 9; i++)
            {
                StarValue += GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(w).ClearStar[i];
                if (w == 3 && i == 2) break;//EXは3ステージしかないので
            }
        }
        for (int w = 0; w < 3; w++) StarValue -= (GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(w).EX_Stage) ? 27 : 0;

        Number10.GetComponent<Number>().SetType(StarValue / 10);
        Number1.GetComponent<Number>().SetType(StarValue % 10);


    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ResetValue()
    {
        StarValue = 0;
        for (int w = 0; w < 4; w++)
        {
            for (int i = 0; i < 9; i++)
            {
                StarValue += GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(w).ClearStar[i];
                if (w == 3 && i == 2) break;//EXは3ステージしかないので
            }
        }
        for (int w = 0; w < 3; w++) StarValue -= (GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(w).EX_Stage) ? 27 : 0;

        Number10.GetComponent<Number>().SetType(StarValue / 10);
        Number1.GetComponent<Number>().SetType(StarValue % 10);


    }

}
