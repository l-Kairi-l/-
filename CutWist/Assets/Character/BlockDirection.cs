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
   // public Quaternion StartRotation;
   // public Quaternion EndRotation;
    //public float MaxRotateScale;
    static public float RotateTime = 240.0f;
    static public float PassedTime;
    //public float RotateSpeed;
    // private Vector3 BlockDefaultScale;
    private Vector3 DefaultPosition;


    public enum ROTATION_STATE_NAME
    {
        Rotating,
        Rotated,
    }

    static public ROTATION_STATE_NAME RotationState;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = gameObject.GetComponent<Transform>().position;
        EndPosition = StartPosition;
       // StartRotation = gameObject.GetComponent<Transform>().rotation;
        //EndRotation = StartRotation;
        DefaultPosition = StartPosition;
        //BlockDefaultScale = gameObject.GetComponent<Transform>().localScale;
        RotationState = ROTATION_STATE_NAME.Rotated;
        PassedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(-Mathf.Rad2Deg * Mathf.Acos(gameObject.GetComponent<Transform>().position.y / DefaultPosition.y), -Mathf.Rad2Deg*Mathf.Acos(gameObject.GetComponent<Transform>().position.x / DefaultPosition.x), 0.0f);
        if (Mathf.Abs(EndPosition.y - gameObject.GetComponent<Transform>().position.y) > 0.001f)
        {

            gameObject.GetComponent<Transform>().position = new Vector3(gameObject.GetComponent<Transform>().position.x, StartPosition.y * Mathf.Cos(Mathf.PI * PassedTime / RotateTime), -Mathf.Abs(StartPosition.y) * Mathf.Sin(Mathf.PI * PassedTime / RotateTime));

        }
        else if (Mathf.Abs(EndPosition.x - gameObject.GetComponent<Transform>().position.x) > 0.001f)
        {

            gameObject.GetComponent<Transform>().position = new Vector3(StartPosition.x * Mathf.Cos(Mathf.PI * PassedTime / RotateTime), gameObject.GetComponent<Transform>().position.y, -Mathf.Abs(StartPosition.x) * Mathf.Sin(Mathf.PI * PassedTime / RotateTime));
        }
        else
        {
            gameObject.GetComponent<Transform>().position = EndPosition;
           
            StartPosition = EndPosition;
          


        }
        
    }
}
