using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World3CursorEffect : MonoBehaviour
{
    public bool move;
    public bool cursorType;
    public int vec;
    public int type;

    public Vector3 cursorPos;
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
            for(int i = 0;i < 10;i++){
                if(Random.value > 0.1f) continue;

                if(Random.value < 0.2f){
                    type = 2;
                }
                else if (Random.value > 0.6f){
                    type = 1;
                }
                else{
                    type = 3;
                }

                if(cursorType){
                    cursorPos = GetComponent<CursorController>().Cursor.transform.position;
                    cursorPos.y = Random.Range(-11.0f,11.0f);

                    GetComponent<World3EffectResource1>().SetParticle(type+3,cursorPos,30,new Vector3(1.0f*-vec,Random.value,0.0f),
                    new Vector3(1.0f,1.0f,1.0f),new Color(0.0f,0.0f,0.0f,-0.0075f));
                }
                else{
                    cursorPos = GetComponent<CursorController2>().Cursor.transform.position;
                    cursorPos.x = Random.Range(-18.0f,18.0f);
                        
                    GetComponent<World3EffectResource1>().SetParticle(type,cursorPos,30,new Vector3(Random.value,1.0f*-vec,0.0f),
                    new Vector3(1.0f,1.0f,1.0f),new Color(0.0f,0.0f,0.0f,-0.0075f));
                }
            }
        }

        /*GetComponent<World3EffectResource1>();
        SetParticle()*/
    }

    public void SetType(bool Move,bool CursorType,int Vector)
    {
        move = Move;
        vec = Vector;
        cursorType = CursorType;
    }
}
