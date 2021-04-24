using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NumberList
{
    public int Frame;
    public Vector3 Pos;
    public int Type;
    public int nowframe;
   //public void Set(int type, Vector3 pos, int frame)
   // {
   //     Frame = frame;
   //     Pos = pos;
   //     Type = type;
   // }

}

public class NumberResources : MonoBehaviour
{
    List<NumberList> numberLists = new List<NumberList>();

    // Start is called before the first frame update
    void Start()
    {
        SetNumber(0, new Vector3(0.0f, 0.0f, -10.0f), 100);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(numberLists.Count);

            for (int i = 0; i < numberLists.Count; i++)
            {
                NumberList list = numberLists[i];

                if (list.nowframe == list.Frame)
                {
                    InstanceNumber(list);

                    numberLists.Remove(numberLists[i]);
                i--;
                }
                else
                {
                    list.nowframe++;
                }
            }
    }

    public void SetNumber(int type,Vector3 pos,int frame)
    {
        NumberList number= new NumberList();
        number.Type= type;
        number.Pos = pos;
        number.Frame = frame;
        number.nowframe = 0;
        numberLists.Add(number);
    }

    void InstanceNumber(NumberList number)
    {
        GameObject obj = (GameObject)Resources.Load("Number_white");

        Instantiate(obj, new Vector3(number.Pos.x, number.Pos.y, number.Pos.z), Quaternion.identity);
        obj.GetComponent<Number>().SetType(number.Type);
    }

}


