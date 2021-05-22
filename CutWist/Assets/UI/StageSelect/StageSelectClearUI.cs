using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectClearUI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Number10;
    public GameObject Number1;
    public int WorldNumber;
    public int StarValue;

    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            StarValue+=GameObject.Find("GameManager").GetComponent<SaveDataManager>().GetData(WorldNumber-1).ClearStar[i];
        }

        Number10.GetComponent<Number>().SetType(StarValue/10);
        Number1.GetComponent<Number>().SetType(StarValue %10);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
