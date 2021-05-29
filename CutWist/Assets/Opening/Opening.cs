using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    private float frame;

    // Start is called before the first frame update
    void Start()
    {
        // プレハブをGameObject型で取得
        GameObject obj = (GameObject)Resources.Load("Transition_1");
        obj.GetComponent<Transition>().SetinScene();

        // プレハブを元に、インスタンスを生成、
        Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);

        frame = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (frame > 1300)
        {
            // プレハブをGameObject型で取得
            GameObject obj = (GameObject)Resources.Load("Transition_1");
            obj.GetComponent<Transition>().SetNextScene("WorldSelect");

            // プレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);
            frame = -1;
        }
        if (frame >= 0)
        {
            frame += 1.0f * (Time.deltaTime * 60.0f);
        }
    }
}
