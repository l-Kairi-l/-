using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberResources : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNumber(int number,Vector3 pos,int frame)
    {
        switch (number)
        {
            case 0:
                GameObject obj = (GameObject)Resources.Load("cloud");
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;

        }

    }

   //void ResourcesNumber()

}
