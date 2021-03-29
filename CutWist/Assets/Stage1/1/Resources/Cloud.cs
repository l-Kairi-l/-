using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;//移動速度
    public float ColorA;//α値
    public float Scale;//大きさ
    SpriteRenderer Color;
    void Start()
    {
        Color = GetComponent<SpriteRenderer>();
        Color c = Color.material.color;
        c.a = ColorA;
        Color.material.color = c;
        transform.localScale = new Vector3(Scale, Scale, 1.0f);
        if (Scale <= 0.81f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 10);
        }
        else if (Scale <= 1.21f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 9);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 8);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Speed, 0, 0);

        if (transform.position.x > 55)
        {
            Destroy(gameObject);//衝突したオブジェクトを削除
        }

    }

    public void SetCloud(float speed, float a, float scale)
    {
        Speed = speed;
        ColorA = a;
        Scale = scale;
    }

}
