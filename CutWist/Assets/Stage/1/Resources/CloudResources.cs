using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudResources : MonoBehaviour
{
    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Random.value <= 0.01f)
        {
            // CubeプレハブをGameObject型で取得
            GameObject obj = (GameObject)Resources.Load("cloud");
            // Cubeプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-10.0f, Random.value * 20.0f+-10.0f, 70.0f), Quaternion.identity);
        }
    }
}
