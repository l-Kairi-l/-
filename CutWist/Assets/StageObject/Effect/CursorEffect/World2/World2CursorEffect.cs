using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World2CursorEffect : MonoBehaviour
{
    bool move;
    int vec;
    // Start is called before the first frame update
    void Start()
    {
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            if (Random.value <= 0.1f)
            {
                //SetTypeの引数にカーソルの座標を入れて、持ってこれるようにして、乱数でその座標をもとに生み出してみる

                GetComponent<World2EffectResources>().SetParticle(1, new Vector3(1.0f, 1.0f, -5.0f), 1,
                    new Vector3(1.0f, 1.0f*-vec, 0.0f), new Vector3(1.0f, 1.0f, 0.0f), new Color(0.0f, 0.0f, 0.0f, -0.01f));

            }
        }
        

        
    }

    //第一引数　動いてるがどうか
    //第二引数　trueが縦　falseが横
    //第三引数　どっちに動いてるか -1==右　1==左
    public void SetType(bool Move,int CursorType,int Vector)
    {
        move = Move;

        vec = Vector;

        //type = CursorType;
    }
}
