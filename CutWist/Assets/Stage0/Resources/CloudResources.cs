using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudResources : MonoBehaviour
{
    // Start is called before the first frame update
    // Use this for initialization
    int Count;

    void Start()
    {
        Count = 0;
    }
    // Update is called once per frame
    void Update()
    {
        //一番手前
        if (Random.value <= 0.0001f)
        {
            // CubeプレハブをGameObject型で取得
            GameObject obj = (GameObject)Resources.Load("cloud");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-30.0f, Random.value * 20.0f + -10.0f, 70.0f), Quaternion.identity);
            obj.GetComponent<Cloud>().SetCloud(0.03f, 1.0f, 1.5f);

        }

        //真ん中
        if (Random.value <= 0.0001f)
        {
            // CubeプレハブをGameObject型で取得
            GameObject obj = (GameObject)Resources.Load("cloud");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-30.0f, Random.value * 20.0f + -10.0f, 70.0f), Quaternion.identity);
            obj.GetComponent<Cloud>().SetCloud(0.01f, 0.8f, 1.2f);

        }

        //後ろ
        if (Random.value <= 0.0001f)
        {
            // CubeプレハブをGameObject型で取得
            GameObject obj = (GameObject)Resources.Load("cloud");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-30.0f, Random.value * 20.0f + -10.0f, 70.0f), Quaternion.identity);
            obj.GetComponent<Cloud>().SetCloud(0.006f, 0.6f, 0.8f);

        }


        Count++;
    }
}
