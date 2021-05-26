using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    // Start is called before the first frame update

    bool flag;

    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)|| GetComponent<SpriteRenderer>().color.a<0.0f)
        {
            GameObject sd = (GameObject)Resources.Load("SoundTitle");
            Instantiate(sd, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            SceneManager.LoadScene("Title");
        }
        if (flag)
        {
            GetComponent<SpriteRenderer>().color += new Color(0.0f, 0.0f, 0.0f, -0.02f* (Time.deltaTime * 60));

            
        }
    }

    public void Set()
    {
        flag = true;
    }
}
