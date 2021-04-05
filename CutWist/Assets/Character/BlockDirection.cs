using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDirection : MonoBehaviour
{

    //ブロックの向き、0 上　1 右　2 下　3 左
    public int blkDirection;
    //テクスチャが整え次第描画と当たり判定を実装する

    public Vector3 StartPosition;
    public Vector3 EndPosition;
    public float MaxRotateScale;
    public float RotateTime;
    public float RotateSpeed;
    private Vector3 BlockDefaultScale;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = gameObject.GetComponent<Transform>().position;
        EndPosition = StartPosition;
        BlockDefaultScale = gameObject.GetComponent<Transform>().localScale;
        RotateTime = 240.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Mathf.Abs(EndPosition.y - gameObject.GetComponent<Transform>().position.y) > 0.1f)
        {
            float posy = gameObject.GetComponent<Transform>().position.y;
            float sscale = (0.5f - Mathf.Abs((posy - StartPosition.y) / (EndPosition.y - StartPosition.y) - 0.5f)) * 2.0f * MaxRotateScale;

            posy += (EndPosition.y - StartPosition.y) / Mathf.Abs(EndPosition.y - StartPosition.y) * RotateSpeed;

            gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, posy, gameObject.GetComponent<Transform>().position.z);
            gameObject.GetComponent<Transform>().localScale = BlockDefaultScale * (1.0f + sscale);

        }else if(Mathf.Abs(EndPosition.x - gameObject.GetComponent<Transform>().position.x) > 0.1f)
        {
            float posx = gameObject.GetComponent<Transform>().position.x;
            float sscale = (0.5f - Mathf.Abs((posx - StartPosition.x) / (EndPosition.x - StartPosition.x) - 0.5f)) * 2.0f * MaxRotateScale;

            posx += (EndPosition.x - StartPosition.x) / Mathf.Abs(EndPosition.x - StartPosition.x) * RotateSpeed;

            gameObject.GetComponent<Transform>().position = new Vector3(posx, gameObject.GetComponent<Transform>().position.y, gameObject.GetComponent<Transform>().position.z);
            gameObject.GetComponent<Transform>().localScale = BlockDefaultScale * (1.0f + sscale);
        }
        else
        {
            gameObject.GetComponent<Transform>().position = EndPosition;
            gameObject.GetComponent<Transform>().localScale = BlockDefaultScale;
        }
    }
}
