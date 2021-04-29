using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class World3CursorParticle1 : MonoBehaviour
{
    public Sprite particleType1;
    public Sprite particleType2;
    public Sprite particleType3;

    SpriteRenderer MySprite;

    // 演出用変数
    public Color particleColor;
    public Vector3 particleVector;
    public Vector3 particleScaling;
    public Color particleAddColor;

    // Start is called before the first frame update
    void Start()
    {
        MySprite = GetComponent<SpriteRenderer>();

        particleColor = new Color(1.0f,1.0f,1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += particleVector.normalized * 0.02f;
        transform.localScale = particleScaling;

        particleColor += particleAddColor;
        MySprite.material.color = particleColor;
   
        
        if(particleColor.a <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    // 第一引数：スプライトの種類
    // 第二引数：移動ベクトル
    // 第三引数：拡大率
    // 第四引数：α値の減少速度 
    public void SetType(int type, Vector3 vector,Vector3 Scaling,Color color)
    {
        MySprite = GetComponent<SpriteRenderer>();

        switch (type)
        {
            case 1:
                MySprite.sprite = particleType1;
                break;
            case 2:
                MySprite.sprite = particleType2;
                break;
            case 3:
                MySprite.sprite = particleType3;
                break;
        }

 
        particleVector = vector;
        particleScaling =Scaling;
        particleAddColor = color;
    }
}
