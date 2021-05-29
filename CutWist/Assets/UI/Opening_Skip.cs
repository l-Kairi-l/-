using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_Skip : MonoBehaviour
{
    bool trigger;
    public Sprite on;
    public Sprite off;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Transition") == null)
        {
            if (trigger && Input.GetMouseButtonDown(0))
            {
                // プレハブをGameObject型で取得
                GameObject obj = (GameObject)Resources.Load("Transition_1");
                obj.GetComponent<Transition>().SetNextScene("WorldSelect");

                // プレハブを元に、インスタンスを生成、
                Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "CoursolPoint")
        {
            trigger = true;
            GetComponent<SpriteRenderer>().sprite = on;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
            trigger = false;
            GetComponent<SpriteRenderer>().sprite = off;

        }
    }

}
