using System.Collections;
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

    static public int rotatecount = 0;

    private uint Frame;

    public GameObject Cursor2;

    // Start is called before the first frame update
    void Start()
    {
        Frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Player>().CursorMode == -2) return;


        //color.a = (DebugImage.GetComponent<CursorController>().== 1) ? 1.0f : 0.0f;

        //spriteRenderer.material.color = color;

        //imageBackItem[1].GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f);
        //GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f);

        if (Player.GetComponent<Player>().CursorMode == 0)
        {

            //α値が0==前フレームがプレイモードまたは他のキリトリ線の場合、プレイヤーの位置に行く
            //if (Cursor.GetComponent<Renderer>().material.color.a < 1.0f)
            //{
            //    Cursor.transform.position = new Vector3(Mathf.Floor(Player.transform.position.x),0, 0);
            //}

            GetComponent<World1CursorEffect>().SetType(false, true, 0);

            GetComponent<World3CursorEffect>().SetType(false, true, 0);

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Frame % 8 == 0)
                {
                    Cursor.transform.position += new Vector3(2.0f, 0, 0);
                    GetComponent<World1CursorEffect>().SetType(true, true, 1);

                    GetComponent<World3CursorEffect>().SetType(true, true, 1);
                }
                Frame++;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (Frame % 8 == 0)
                {

                    Cursor.transform.position += new Vector3(-2.0f, 0, 0);
                    GetComponent<World1CursorEffect>().SetType(true, true, -1);

                    GetComponent<World3CursorEffect>().SetType(true, true, 1);
                }

                Frame++;
            }
            else
            {
                Frame = 0;
            }
            //--------可動域-------//
            if (Cursor.transform.position.x <= -22.0f)
            {
                Cursor.transform.position = new Vector3(
                    -22.0f, Cursor.transform.position.y, Cursor.transform.position.z);
            }
            if (Cursor.transform.position.x >= 22.0f)
            {
                Cursor.transform.position = new Vector3(
                    22.0f, Cursor.transform.position.y, Cursor.transform.position.z);
            }
            //Cursor.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

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
            //Cursor.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        }

        //if ((Player.GetComponent<Player>().CursorMode == 0 || Player.GetComponent<Player>().CursorMode == 1) && Input.GetKeyDown(KeyCode.K))
        //{
        //    if (BlockDirection.RotationState == BlockDirection.ROTATION_STATE_NAME.Rotated)
        //    {
        //        Sheep.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        //        //Sheep.GetComponent<BlockDirection>().enabled = true;
        //        //Clock.GetComponent<BlockDirection>().enabled = true;
        //        Clock.GetComponent<Alarm_Clock>().enabled = false;
        //        //Sheep.GetComponent<BlockDirection>().StartPosition = Sheep.GetComponent<Transform>().GetComponent<Transform>().position;
        //        //Sheep.GetComponent<BlockDirection>().EndPosition = Sheep.GetComponent<BlockDirection>().StartPosition;
        //        //Sheep.GetComponent<BlockDirection>().StartRotation = gameObject.GetComponent<Transform>().rotation;
        //        Player.GetComponent<Player>().GravityZero();
        //    }

        //}

        if (Player.GetComponent<Player>().CursorMode == 0 && (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)))
        {
            Player.GetComponent<Player>().CursorMode = -3;
            Player.GetComponent<Player>().GravityZero();
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
                    if (objects[i].name == "GoalSheep")
                    {
                        objects[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;


                    }
                    else if (objects[i].name == "alarm_clock")
                    {

                        objects[i].GetComponent<Alarm_Clock>().enabled = false;
                    }

                    Component rigi = objects[i].GetComponent<Rigidbody2D>();
                    if (rigi != null)
                    {
                        objects[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    }
                    //切り取り線を参照しプレイヤーと異なる側のブロックを反転
                    if (objects[i].transform.position.x <= Cursor.transform.position.x && TranLeft || objects[i].transform.position.x > Cursor.transform.position.x && !TranLeft)
                    {
                        //objects[i].transform.position = new Vector3(objects[i].transform.position.x, objects[i].transform.position.y * -1.0f, objects[i].transform.position.z);
                        //上下反転だから上か下に向いてるブロックの向きだけを反転するようにする
                        //objects[i].GetComponent<BlockDirection>().blkDirection = (objects[i].GetComponent<BlockDirection>().blkDirection % 2) == 0 ? (objects[i].GetComponent<BlockDirection>().blkDirection + 2) % 4 : objects[i].GetComponent<BlockDirection>().blkDirection;[i].GetComponent<BlockDirection>().blkDirection % 2) == 0 ? (objects[i].GetComponent<BlockDirection>().blkDirection + 2) % 4 : objects[i].GetComponent<BlockDirection>().blkDirection;

                        //if (objects[i].name == "GoalSheep")
                        //{
                        //    objects[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                        //    objects[i].GetComponent<BlockDirection>().enabled = true;
                        //}
                        //else if (objects[i].name == "alarm_clock")
                        //{
                        //    objects[i].GetComponent<BlockDirection>().enabled = true;
                        //    objects[i].GetComponent<Alarm_Clock>().enabled = false;
                        //}

                        rotatecount++;
                        BlockDirection blk = objects[i].GetComponent<BlockDirection>();
                        blk.StartPosition = objects[i].transform.position;
                        blk.EndPosition = new Vector3(objects[i].transform.position.x, objects[i].transform.position.y * -1.0f, objects[i].transform.position.z);
                        objects[i].GetComponent<Transform>().Rotate(new Vector3(180, 0, 0), Space.World);
                        blk.StartRotation = objects[i].GetComponent<Transform>().rotation;
                        objects[i].GetComponent<Transform>().Rotate(new Vector3(-180, 0, 0), Space.World);
                        //blk.StartRotation *= Quaternion.Euler(180f, 0, 0);

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
                    Player.GetComponent<Player>().CursorMode = 0;

                }
                else
                {
                    rotatecount = 0;
                    GameObject cleargauge = GameObject.Find("GameUI_" + GameObject.Find("GameManager").GetComponent<EditManager>().WorldNumber);
                    cleargauge.GetComponent<ClearGauge>().BlockRotate();
                }
            }
            //else
            //{
            //    BlockDirection.PassedTime = BlockDirection.RotateTime - BlockDirection.PassedTime;
            //    RotateBoardBehavior1.IsInverse = !RotateBoardBehavior1.IsInverse;
            //    for (int i = 0; i < Count; i++)
            //    {
            //        if (objects[i].transform.position.x <= Cursor.transform.position.x && TranLeft || objects[i].transform.position.x > Cursor.transform.position.x && !TranLeft)
            //        {
            //            BlockDirection blk = objects[i].GetComponent<BlockDirection>();
            //            Vector3 startPos = blk.StartPosition;
            //            blk.StartPosition = blk.EndPosition;
            //            blk.EndPosition = startPos;
            //            blk.StartRotation *= Quaternion.Euler(180f, 0, 0);
            //        }

            //    }
            //}
        }

        if (BlockDirection.RotationState == BlockDirection.ROTATION_STATE_NAME.Rotating)
        {


            BlockDirection.PassedTime += Time.deltaTime;
            if (BlockDirection.PassedTime >= BlockDirection.RotateTime)
            {
                BlockDirection.PassedTime = 0.0f;
                BlockDirection.RotationState = BlockDirection.ROTATION_STATE_NAME.Rotated;
                GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");

                foreach (GameObject obj in objects)
                {
                    Component rigi = obj.GetComponent<Rigidbody2D>();
                    if (rigi != null)
                    {
                        obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    }
                }

                //Sheep.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;






                Sheep.GetComponent<Transform>().rotation = Sheep.GetComponent<BlockDirection>().StartRotation;
                //Sheep.GetComponent<BlockDirection>().enabled = false;

                Clock.GetComponent<Alarm_Clock>().enabled = true;
                Clock.GetComponent<Transform>().rotation = Clock.GetComponent<BlockDirection>().StartRotation;
                //Clock.GetComponent<BlockDirection>().enabled = false;
                Player.GetComponent<Player>().GravityReset();
                Player.GetComponent<Player>().CursorMode = -1;
                Cursor.GetComponent<Transform>().position = new Vector3(-30.0f, Cursor.GetComponent<Transform>().position.y, Cursor.GetComponent<Transform>().position.z);
                Cursor2.GetComponent<Transform>().position = new Vector3(Cursor2.GetComponent<Transform>().position.x, -20.0f, Cursor2.GetComponent<Transform>().position.z);
                //GameObject cleargauge = GameObject.Find("GameUI");

                //if (cleargauge.GetComponent<ClearGauge>().GetGaugeLife() <= 0)
                //{
                //    Player.GetComponent<Player>().CursorMode = -1;
                //}

            }

        }
    }
}
