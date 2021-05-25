using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private List<string> PrefabList = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        PrefabList.Add("W1_3DBlockNormal");
        PrefabList.Add("W2_3DBlockNormal");
        PrefabList.Add("W3_3DBlockNormal");

    }

    // Update is called once per frame
    void Update()
    {
        //一番手前
        if (Random.value <= 0.005f)
        {
            GameObject obj;
            int Type = (int)Random.Range(0.0f, (float)PrefabList.Count);
            // プレハブをGameObject型で取得
                    obj = (GameObject)Resources.Load(PrefabList[Type]);
            // プレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(-30.0f, Random.value * 20.0f + -10.0f, 5.0f), Quaternion.identity);

        }


    }

    public void InstanceUI()
    {
        // プレハブをGameObject型で取得
        GameObject obj = (GameObject)Resources.Load("TitleUI");

        // プレハブを元に、インスタンスを生成、
        Instantiate(obj, new Vector3(5.855527f, -3.669938f, -31.98817f), Quaternion.identity);

    }
}
