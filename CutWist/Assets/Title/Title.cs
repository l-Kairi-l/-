using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InstanceUI()
    {
        // プレハブをGameObject型で取得
        GameObject obj = (GameObject)Resources.Load("TitleUI");

        // プレハブを元に、インスタンスを生成、
        Instantiate(obj, new Vector3(5.855527f, -3.669938f, -31.98817f), Quaternion.identity);

    }
}
