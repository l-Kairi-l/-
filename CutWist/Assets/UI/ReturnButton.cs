using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnButton : MonoBehaviour
{

    bool select;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (select && Input.GetMouseButtonDown(0))
        {

            if (SceneManager.GetActiveScene().name == "WorldSelect")
            {
                SceneManager.LoadScene("Title");

            }


            for (int i = 1; i <= 3; i++)
            {
                if (SceneManager.GetActiveScene().name == "World"+i)
                {
                    SceneManager.LoadScene("WorldSelect");

                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {

            select = true;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
            select = false;
        }
    }

}
