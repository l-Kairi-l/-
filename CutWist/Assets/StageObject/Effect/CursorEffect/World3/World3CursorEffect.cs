using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World3CursorEffect : MonoBehaviour
{
    public bool move;
    public bool cursorType;
    public int vec;
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
            for(int i = 0;i < 50;i++){
                if(Random.value <= 0.01f)
                {
                    if(cursorType == true){
                        cursorPos.x = Random.Range(-18.0f,18.0f);
                        GetComponent<World3EffectResource1>().SetParticle(Random.Range(1,3),cursorPos,30,new Vector3(1.0f,1.0f*-vec,0.0f),
                        new Vector3(1.0f,1.0f,1.0f),new Color(0.0f,0.0f,0.0f,-0.005f));
                    }
                    else{
                        cursorPos.y = Random.Range(-11.0f,11.0f);
                    }
                   
                }
            }
        }

        /*GetComponent<World3EffectResource1>();
        SetParticle()*/
    }

    public void SetType(bool Move,bool CursorType,int Vector,Vector3 CursorPos)
    {
        move = Move;
        vec = Vector;
        cursorType = CursorType;
        cursorPos = CursorPos;
    }
}
