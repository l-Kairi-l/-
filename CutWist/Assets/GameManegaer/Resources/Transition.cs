using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    public float Size;
    public string NextStageName;
    public bool Type;
    void Start()
    {
        Debug.Log(Type);

    }

    // Update is called once per frame
    void Update()
    {

        if (Type)
        {
            transform.localScale = new Vector3(Size, Size, 1.0f);
            if (Size <= 1.0f)
            {
                SceneManager.LoadScene(NextStageName);

               transform.localScale = new Vector3(1.0f,1.0f, 1.0f);


            }
            Size -= 1.0f;
        }
        else
        {
            transform.localScale = new Vector3(Size, Size, 1.0f);
            if (Size >= 120.0f)
            {
                Destroy(gameObject);
            }
            Size += 1.0f;

        }


    }

    //次のシーンに移り変わるときのアニメーション
    public void SetNextScene(string next)
    {
        NextStageName = next;

        transform.localScale = new Vector3(120.0f, 120.0f, 1.0f);

        Type = true;

        Debug.Log(Type);

        Size = 120.0f;
    }
    //新しいシーンに来た時のシーン
    public void SetinScene()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Type = false;

        Size = 1.0f;

    }

}
