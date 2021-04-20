using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    // Start is called before the first frame update

    public int number;

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
    private void OnTriggerStay2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "CoursolPoint" && Input.GetMouseButtonDown(0))
        {
            switch (number)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;

            }
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
