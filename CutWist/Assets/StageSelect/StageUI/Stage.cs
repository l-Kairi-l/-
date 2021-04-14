using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Renderer renderer;

        renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);

    }

    // Update is called once per frame
    void Update()
    {


        //     Debug.Log(Input.mousePosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "CoursolPoint")
        {
            Renderer renderer;

            renderer = GetComponent<Renderer>();

            renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

             Debug.Log(transform.position);

        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "CoursolPoint")
        {
            Renderer renderer;

            renderer = GetComponent<Renderer>();

            renderer.material.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }
    }

    
}
