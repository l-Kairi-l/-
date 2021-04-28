using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World2CursorParticle : MonoBehaviour
{
    public Sprite ParticleType1;
    public Sprite ParticleType2;
    public Sprite ParticleType3;
    public Sprite ParticleType4;
    public Sprite ParticleType5;
    public Sprite ParticleType6;
    public Sprite ParticleType7;

    SpriteRenderer MySprite;

    //演出に使う変数
    public Color particle_color;
    public Vector3 particle_vector;
    public Vector3 particle_size;
    public Color particle_addcolor;

    // Start is called before the first frame update
    void Start()
    {
        MySprite = GetComponent<SpriteRenderer>();
        //演出に使う変数
        particle_color = new Vector4(1.0f,1.0f,1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += particle_vector;

        transform.localScale += particle_size;

        MySprite.material.color = particle_color;

        particle_color -= particle_addcolor;

        if (particle_color.a <= 0.0f)
        {
            Destroy(gameObject);
        }


    }

    //第一引数：　スプライトの種類
    //第二引数：　移動ベクトル
    //第三引数：　拡大率
    //第四引数：　色の変化
    public void SetType(int type,Vector3 vector,Vector3 size,Color color)
    {
        MySprite = GetComponent<SpriteRenderer>();

        switch (type)
        {
            case 1:
                MySprite.sprite = ParticleType1;
                break;
            case 2:
                MySprite.sprite = ParticleType2;
                break;
            case 3:
                MySprite.sprite = ParticleType3;
                break;
            case 4:
                MySprite.sprite = ParticleType4;
                break;
            case 5:
                MySprite.sprite = ParticleType5;
                break;
            case 6:
                MySprite.sprite = ParticleType6;
                break;
            case 7:
                MySprite.sprite = ParticleType7;
                break;
        }

        particle_vector = vector;
        particle_size = size;
        particle_color = color;
    }
}
