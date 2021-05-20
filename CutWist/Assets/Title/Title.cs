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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //  SceneManager.LoadScene("WorldSelect");

            // プレハブをGameObject型で取得
            GameObject obj = (GameObject)Resources.Load("Transition_1");
            obj.GetComponent<Transition>().SetNextScene("WorldSelect");

            // プレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(0.0f,0.0f, -90.0f), Quaternion.identity);

        }
    }
}
