using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionResources : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // プレハブをGameObject型で取得
        GameObject obj = (GameObject)Resources.Load("Transition_1");
        obj.GetComponent<Transition>().SetinScene();

        // プレハブを元に、インスタンスを生成、
        Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
