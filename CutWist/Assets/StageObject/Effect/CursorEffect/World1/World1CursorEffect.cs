using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World1CursorEffect : MonoBehaviour
{
    // Start is called before the first frame update
    bool move;

    int vec;

    bool type;

    void Start()
    {
        move = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (move)
        {

            //横か縦か
            if (type)
            {
                if (Random.value <= 0.1f)
                {

                    //SetTypeにの引数にカーソルの座標を入れて、持ってこれるようにして、乱数でその座標を元に生み出してみる

                    GetComponent<World1EffectResources>().SetParticle(0,
                        new Vector3(GetComponent<CursorController>().Cursor.transform.position.x, Random.value * 24.0f - 12.0f/*高さの幅から半分を引く*/, -5.0f), 1,
                        new Vector3(0.1f * -vec, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), new Color(0.0f, 0.0f, 0.0f, -0.1f));

                }


            }
            else
            {
                if (Random.value <= 0.1f)
                {
                   

                    //SetTypeにの引数にカーソルの座標を入れて、持ってこれるようにして、乱数でその座標を元に生み出してみる

                    GetComponent<World1EffectResources>().SetParticle(1, 
                        new Vector3( Random.value*47.0f-23.5f/*高さの幅から半分を引く*/, GetComponent<CursorController2>().Cursor.transform.position.y, -5.0f), 1,
                        new Vector3(0.0f, 0.1f * -vec, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), new Color(0.0f, 0.0f, 0.0f, -0.1f));

                }

            }
        }
        //

        //    SetParticle
    }
    //第一引数　動いてるかどうか
    //第二引数　trueが縦　falseが横
    //第三引数　どっちに動いてるか 1==右上　-1==左下
    public void SetType(bool Move,bool CursorType,int Vector)
    {
        move=Move;

        vec = Vector;

        type = CursorType;
    }
}
