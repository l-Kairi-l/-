using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Mechanics;

public class CursorController2 : MonoBehaviour
{
    public GameObject Cursor;
    public GameObject Player;
    public int Count;
    public GameObject RotateBoard;
 


    //public GameObject Goal_false2;
    //public GameObject Goal_true2;
    //public GameObject Needle_0;
    //public GameObject Needle_1;
    //public GameObject Needle_2;
    //public GameObject Needle_3;
    //public GameObject Needle_4;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Player.GetComponent<Player>().CursorMode == 1)
        {
            GetComponent<World1CursorEffect>().SetType(false, false, 0);
            GetComponent<World2CursorEffect>().SetType(false, false, 0);
            GetComponent<World3CursorEffect>().SetType(false, false, 0);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                Cursor.transform.position += new Vector3(0, 0.1f, 0);
                if (Cursor.transform.position.y >= 11.9f)
                {
                    Cursor.transform.position = new Vector3(
                        Cursor.transform.position.x, 11.9f, Cursor.transform.position.z);
                }

                GetComponent<World1CursorEffect>().SetType(true,false,1);
                GetComponent<World2CursorEffect>().SetType(true,false,1);
                GetComponent<World3CursorEffect>().SetType(true,false,1);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                Cursor.transform.position += new Vector3(0, -0.1f, 0);
                if (Cursor.transform.position.y <= -11.9f)
                {
                    Cursor.transform.position = new Vector3(
                        Cursor.transform.position.x, -11.9f, Cursor.transform.position.z);
                }
                GetComponent<World1CursorEffect>().SetType(true, false, -1);
                GetComponent<World2CursorEffect>().SetType(true, false, -1);
                GetComponent<World3CursorEffect>().SetType(true, false, -1);

            }
            Cursor.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);


            if(BlockDirection.RotationState == BlockDirection.ROTATION_STATE_NAME.Rotated)
            {
                GameObject[] objects;

                objects = GameObject.FindGameObjectsWithTag("Object");

                Count = objects.Length;

                bool TranLeft = Player.transform.position.y <= Cursor.transform.position.y ? false : true;

                for (int i = 0; i < Count; i++)
                {
                    if (objects[i].transform.position.y <= Cursor.transform.position.y && TranLeft || objects[i].transform.position.y > Cursor.transform.position.y && !TranLeft)
                    {
                        BlockSelectedEffect bse = objects[i].GetComponent<BlockSelectedEffect>();
                        if (bse)
                        {
                            bse.EffectEnable = true;
                        }


                    }
                    else
                    {
                        BlockSelectedEffect bse = objects[i].GetComponent<BlockSelectedEffect>();
                        if (bse)
                        {
                            bse.ColorReset();
                        }

                    }
                }
                
            }
        }
        else
        {
            Cursor.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }

        if (Player.GetComponent<Player>().CursorMode == 1 && Input.GetKeyDown(KeyCode.K))
        {
           
            GameObject[] objects;

            objects = GameObject.FindGameObjectsWithTag("Object");

            Count = objects.Length;

            bool TranLeft = Player.transform.position.y <= Cursor.transform.position.y ? false : true;


            // TranLeft = Player.GetComponent<SpriteRenderer>().flipX;
            if (BlockDirection.RotationState == BlockDirection.ROTATION_STATE_NAME.Rotated)
            {

                for (int i = 0; i < Count; i++)
                {
                    float scaley = TranLeft ? 25.0f + Cursor.transform.position.y : 14.0f - Cursor.transform.position.y;
                    float posy = TranLeft ? Cursor.transform.position.y - 0.5f * (14.0f + Cursor.transform.position.y) : Cursor.transform.position.y + 0.5f * (14.0f - Cursor.transform.position.y);
                    GameObject RBoard = Instantiate(RotateBoard, new Vector3(0, posy,  0), Quaternion.identity);
                    RBoard.transform.localScale = new Vector3(1 , scaley , 1);
                    RotateBoardBehavior2.IsInverse = false;
                    //切り取り線を参照しプレイヤーと異なる側のブロックを反転
                    if (objects[i].transform.position.y <= Cursor.transform.position.y && TranLeft || objects[i].transform.position.y > Cursor.transform.position.y && !TranLeft)
                    {
                        // objects[i].transform.position = new Vector3(objects[i].transform.position.x * -1.0f, objects[i].transform.position.y , objects[i].transform.position.z * -1.0f);
                        //左右反転だから左か右に向いてるブロックの向きだけを反転するようにする
                        //  objects[i].GetComponent<BlockDirection>().blkDirection = (objects[i].GetComponent<BlockDirection>().blkDirection % 2) == 1 ? (objects[i].GetComponent<BlockDirection>().blkDirection + 2) % 4 : objects[i].GetComponent<BlockDirection>().blkDirection;

                        CursorController.rotatecount++;

                        BlockDirection blk = objects[i].GetComponent<BlockDirection>();
                        blk.StartPosition = objects[i].transform.position;
                        blk.EndPosition = new Vector3(objects[i].transform.position.x * -1.0f, objects[i].transform.position.y, objects[i].transform.position.z);
                        blk.StartRotation *= Quaternion.Euler(0,180f, 0);
                        //blk.StartRotation = objects[i].transform.rotation;
                        //blk.EndRotation = new Quaternion(objects[i].transform.rotation.x, objects[i].transform.rotation.y - 180.0f , objects[i].transform.rotation.z, objects[i].transform.rotation.w);
                        // blk.RotateSpeed = 2.0f * Mathf.Abs(objects[i].transform.position.x) / BlockDirection.RotateTime;
                        // blk.MaxRotateScale = 2.0f * objects[i].transform.position.x / 28.0f * 2.0f;
                        blk.RotateType = blk.StartPosition.x <= 0 ? BlockDirection.ROTATION_TYPE_NAME.Outside : BlockDirection.ROTATION_TYPE_NAME.Inside;
                        //blk.StartRotation = objects[i].transform.rotation;
                        if (objects[i].name == "GoalSheep")
                        {
                            objects[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                            
                            objects[i].GetComponent<BlockDirection>().enabled = true;
                        }
                        else if(objects[i].name == "alarm_clock")
                        {
                            objects[i].GetComponent<BlockDirection>().enabled = true;
                            objects[i].GetComponent<Alarm_Clock>().enabled = false;
                        }

                        BlockSelectedEffect bse = objects[i].GetComponent<BlockSelectedEffect>();
                        if (bse)
                        {
                            bse.ColorReset();
                        }
                    }

                }

               

                if (CursorController.rotatecount != 0)
                {
                    BlockDirection.RotationState = BlockDirection.ROTATION_STATE_NAME.Rotating;
                    CursorController.rotatecount = 0;
                }
            }
            else
            {
                BlockDirection.PassedTime = BlockDirection.RotateTime - BlockDirection.PassedTime;
                RotateBoardBehavior2.IsInverse = true;
                for (int i = 0; i < Count; i++)
                {
                    if (objects[i].transform.position.y <= Cursor.transform.position.y && TranLeft || objects[i].transform.position.y > Cursor.transform.position.y && !TranLeft)
                    {
                        BlockDirection blk = objects[i].GetComponent<BlockDirection>();
                        Vector3 startPos = blk.StartPosition;
                        blk.StartPosition = blk.EndPosition;
                        blk.EndPosition = startPos;
                        blk.StartRotation *= Quaternion.Euler(0, 180f, 0);
                    }
                    //Quaternion startRotate = blk.StartRotation;
                    //blk.StartRotation = blk.EndRotation;
                    // blk.EndRotation = startRotate;
                }

            }
        }

        //DebugImage2.color = color;
    }
}
