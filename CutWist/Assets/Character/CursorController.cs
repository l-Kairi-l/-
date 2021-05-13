﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Mechanics;

public class CursorController : MonoBehaviour
{
    public GameObject Cursor;
    public GameObject Player;
    public GameObject Sheep;
    public GameObject Clock;
    public int Count;
    public GameObject RotateBoard;
    //public GameObject Block;
    //public GameObject Goal_false;
    //public GameObject Goal_true;
    //public GameObject Tile;
    //public GameObject Diamond;
    //public GameObject Frame;
    static public int rotatecount = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        //color.a = (DebugImage.GetComponent<CursorController>().== 1) ? 1.0f : 0.0f;

        //spriteRenderer.material.color = color;

        //imageBackItem[1].GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f);
        //GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f);


        if (Player.GetComponent<Player>().CursorMode == 0)
        {
            GetComponent<World1CursorEffect>().SetType(false, true, 0);
            
            GetComponent<World3CursorEffect>().SetType(false, true, 0);

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Cursor.transform.position += new Vector3(0.1f, 0, 0);
                if (Cursor.transform.position.x >= 19.5f)
                {
                    Cursor.transform.position = new Vector3(
                        19.5f, Cursor.transform.position.y, Cursor.transform.position.z);
                }
                GetComponent<World1CursorEffect>().SetType(true, true, 1);
                
                GetComponent<World3CursorEffect>().SetType(true, true, 1);

            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Cursor.transform.position += new Vector3(-0.1f, 0, 0);
                if (Cursor.transform.position.x <= -19.5f)
                {
                    Cursor.transform.position = new Vector3(
                        -19.5f, Cursor.transform.position.y, Cursor.transform.position.z);
                }
                GetComponent<World1CursorEffect>().SetType(true, true, -1);

                GetComponent<World3CursorEffect>().SetType(true, true, 1);

            }

            Cursor.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            if (BlockDirection.RotationState == BlockDirection.ROTATION_STATE_NAME.Rotated)
            {
                GameObject[] objects;

                objects = GameObject.FindGameObjectsWithTag("Object");

                Count = objects.Length;

                bool TranLeft = Player.transform.position.x <= Cursor.transform.position.x ? false : true;

                for (int i = 0; i < Count; i++)
                {
                    //if (objects[i].name == "GoalSheep" || objects[i].name == "alarm_clock") continue;

                    //切り取り線を参照しプレイヤーと異なる側のブロックを反転
                    if (objects[i].transform.position.x <= Cursor.transform.position.x && TranLeft || objects[i].transform.position.x > Cursor.transform.position.x && !TranLeft)
                    {
                        BlockSelectedEffect bse = objects[i].GetComponent<BlockSelectedEffect>();
                        if(bse)
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



        if (Player.GetComponent<Player>().CursorMode == 0 && Input.GetKeyDown(KeyCode.K))
        {
 

            GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");

            Count = objects.Length;

            bool TranLeft = Player.transform.position.x <= Cursor.transform.position.x ? false : true;

            //TranLeft = Player.GetComponent<SpriteRenderer>().flipX;
            if (BlockDirection.RotationState == BlockDirection.ROTATION_STATE_NAME.Rotated)
            {
                BlockDirection.RotationState = BlockDirection.ROTATION_STATE_NAME.Rotating;
                BlockDirection.PassedTime = 0;

                float scalex = TranLeft ? 25.0f + Cursor.transform.position.x : 25.0f - Cursor.transform.position.x;
                float posx = TranLeft ? Cursor.transform.position.x - 0.5f * (25.0f + Cursor.transform.position.x) : Cursor.transform.position.x + 0.5f * (25.0f - Cursor.transform.position.x);
                GameObject RBoard = Instantiate(RotateBoard, new Vector3(posx, 0, 0), Quaternion.identity);
                RBoard.transform.localScale = new Vector3(scalex, 1, 1);
                RotateBoardBehavior1.IsInverse = false;
                for (int i = 0; i < Count; i++)
                {
                    //切り取り線を参照しプレイヤーと異なる側のブロックを反転
                    if (objects[i].transform.position.x <= Cursor.transform.position.x && TranLeft || objects[i].transform.position.x > Cursor.transform.position.x && !TranLeft)
                    {
                        //objects[i].transform.position = new Vector3(objects[i].transform.position.x, objects[i].transform.position.y * -1.0f, objects[i].transform.position.z);
                        //上下反転だから上か下に向いてるブロックの向きだけを反転するようにする
                        //objects[i].GetComponent<BlockDirection>().blkDirection = (objects[i].GetComponent<BlockDirection>().blkDirection % 2) == 0 ? (objects[i].GetComponent<BlockDirection>().blkDirection + 2) % 4 : objects[i].GetComponent<BlockDirection>().blkDirection;[i].GetComponent<BlockDirection>().blkDirection % 2) == 0 ? (objects[i].GetComponent<BlockDirection>().blkDirection + 2) % 4 : objects[i].GetComponent<BlockDirection>().blkDirection;

                        if (objects[i].name == "GoalSheep")
                        {
                            objects[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                            objects[i].GetComponent<BlockDirection>().enabled = true;
                        }
                        else if (objects[i].name == "alarm_clock")
                        {
                            objects[i].GetComponent<BlockDirection>().enabled = true;
                            objects[i].GetComponent<Alarm_Clock>().enabled = false;
                        }

                        rotatecount++;
                        BlockDirection blk = objects[i].GetComponent<BlockDirection>();
                        blk.StartPosition = objects[i].transform.position;
                        blk.EndPosition = new Vector3(objects[i].transform.position.x, objects[i].transform.position.y * -1.0f, objects[i].transform.position.z);
                        blk.StartRotation *= Quaternion.Euler(180f, 0, 0);
                        
                        blk.RotateType = blk.StartPosition.y >= 0 ? BlockDirection.ROTATION_TYPE_NAME.Outside : BlockDirection.ROTATION_TYPE_NAME.Inside;
                        //blk.StartRotation = objects[i].transform.rotation;

                        BlockSelectedEffect bse = objects[i].GetComponent<BlockSelectedEffect>();
                        if (bse)
                        {
                            bse.ColorReset();
                        }
                    }

                }

                if (rotatecount == 0)
                {
                    BlockDirection.RotationState = BlockDirection.ROTATION_STATE_NAME.Rotated;

                }
                else
                {
                    rotatecount = 0;
                }
            }
            else
            {
                BlockDirection.PassedTime = BlockDirection.RotateTime - BlockDirection.PassedTime;
                RotateBoardBehavior1.IsInverse = !RotateBoardBehavior1.IsInverse;
                for (int i = 0; i < Count; i++)
                {
                    if (objects[i].transform.position.x <= Cursor.transform.position.x && TranLeft || objects[i].transform.position.x > Cursor.transform.position.x && !TranLeft)
                    {
                        BlockDirection blk = objects[i].GetComponent<BlockDirection>();
                        Vector3 startPos = blk.StartPosition;
                        blk.StartPosition = blk.EndPosition;
                        blk.EndPosition = startPos;
                        blk.StartRotation *= Quaternion.Euler(180f, 0, 0);
                    }
                    
                }
            }
        }

        if (BlockDirection.RotationState == BlockDirection.ROTATION_STATE_NAME.Rotating)
        {


            BlockDirection.PassedTime += Time.deltaTime;
            if (BlockDirection.PassedTime >= BlockDirection.RotateTime)
            {
                BlockDirection.PassedTime = 0.0f;
                BlockDirection.RotationState = BlockDirection.ROTATION_STATE_NAME.Rotated;

                Sheep.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                Sheep.GetComponent<BlockDirection>().enabled = false;

                Clock.GetComponent<Alarm_Clock>().enabled = true;
                Clock.GetComponent<BlockDirection>().enabled = false;
               
            }

        }
    }
}
