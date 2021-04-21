using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            string s_name = "World";
            string s_number = "" + number;

            SceneManager.LoadScene(s_name+ s_number);

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
