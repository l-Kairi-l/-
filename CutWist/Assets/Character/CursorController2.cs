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

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                Cursor.transform.position += new Vector3(0, 0.1f, 0);
                if (Cursor.transform.position.y >= 11.9f)
                {
                    Cursor.transform.position = new Vector3(
                        Cursor.transform.position.x, 11.9f, Cursor.transform.position.z);
                }

                GetComponent<World1CursorEffect>().SetType(true,false,1);
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

            }
            Cursor.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            Cursor.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }

        if (Player.GetComponent<Player>().CursorMode == 1 && Input.GetKeyDown(KeyCode.K))
        {
            //Goal_false2.transform.position = new Vector3(
            //   Goal_false2.transform.position.x * -1.0f, Goal_false2.transform.position.y, Goal_false2.transform.position.z);

            //Goal_true2.transform.position = new Vector3(
            //   Goal_true2.transform.position.x * -1.0f, Goal_true2.transform.position.y, Goal_true2.transform.position.z);

            //Needle_0.transform.position = new Vector3(
            //   Needle_0.transform.position.x * -1.0f, Needle_0.transform.position.y, Needle_0.transform.position.z);

            //Needle_1.transform.position = new Vector3(
            //   Needle_1.transform.position.x * -1.0f, Needle_1.transform.position.y, Needle_1.transform.position.z);

            //Needle_2.transform.position = new Vector3(
            //   Needle_2.transform.position.x * -1.0f, Needle_2.transform.position.y, Needle_2.transform.position.z);

            //Needle_3.transform.position = new Vector3(
            //   Needle_3.transform.position.x * -1.0f, Needle_3.transform.position.y, Needle_3.transform.position.z);

            //Needle_4.transform.position = new Vector3(
            //   Needle_4.transform.position.x * -1.0f, Needle_4.transform.position.y, Needle_4.transform.position.z);
            GameObject[] objects;

            objects = GameObject.FindGameObjectsWithTag("Object");

            Count = objects.Length;

            bool TranLeft = Player.transform.position.y <= Cursor.transform.position.y ? false : true;


            // TranLeft = Player.GetComponent<SpriteRenderer>().flipX;
            if (BlockDirection.RotationState == BlockDirection.ROTATION_STATE_NAME.Rotated)
            {

                for (int i = 0; i < Count; i++)
                {

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
                        //blk.StartRotation = objects[i].transform.rotation;
                        //blk.EndRotation = new Quaternion(objects[i].transform.rotation.x, objects[i].transform.rotation.y - 180.0f , objects[i].transform.rotation.z, objects[i].transform.rotation.w);
                        // blk.RotateSpeed = 2.0f * Mathf.Abs(objects[i].transform.position.x) / BlockDirection.RotateTime;
                        // blk.MaxRotateScale = 2.0f * objects[i].transform.position.x / 28.0f * 2.0f;
                        blk.RotateType = blk.StartPosition.x <= 0 ? BlockDirection.ROTATION_TYPE_NAME.Outside : BlockDirection.ROTATION_TYPE_NAME.Inside;




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
                for (int i = 0; i < Count; i++)
                {

                    BlockDirection blk = objects[i].GetComponent<BlockDirection>();
                    Vector3 startPos = blk.StartPosition;
                    blk.StartPosition = blk.EndPosition;
                    blk.EndPosition = startPos;
                    //Quaternion startRotate = blk.StartRotation;
                    //blk.StartRotation = blk.EndRotation;
                    // blk.EndRotation = startRotate;
                }

            }
        }

        //DebugImage2.color = color;
    }
}
