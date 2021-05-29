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

    public Sprite black;

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
            if (Size <= 2.0f)
            {
                SceneManager.LoadScene(NextStageName);

               transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);

                GetComponent<SpriteRenderer>().sprite = black;

            }
            Size -= 8.0f*(Time.deltaTime*60);
        }
        else
        {
            transform.localScale = new Vector3(Size, Size, 1.0f);
            if (Size >= 270.0f)
            {
                Destroy(gameObject);
            }
            Size += 8.0f * (Time.deltaTime * 60);

        }


    }

    //次のシーンに移り変わるときのアニメーション
    public void SetNextScene(string next)
    {
        NextStageName = next;

        Size = 270.0f;

        transform.localScale = new Vector3(Size, Size, 1.0f);

        Type = true;

        Debug.Log(Type);

    }
    //新しいシーンに来た時のシーン
    public void SetinScene()
    {
        Size = 2.0f;

        transform.localScale = new Vector3(Size, Size, 1.0f);

        Type = false;

    }

}
