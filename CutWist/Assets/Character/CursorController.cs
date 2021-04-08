using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Mechanics;

public class CursorController : MonoBehaviour
{
    public GameObject Cursor;
    public GameObject Player;
    public int Count;
    //public GameObject Block;
    //public GameObject Goal_false;
    //public GameObject Goal_true;
    //public GameObject Tile;
    //public GameObject Diamond;
    //public GameObject Frame;
    

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
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Cursor.transform.position += new Vector3(0.1f, 0, 0);
                if (Cursor.transform.position.x >= 19.5f)
                {
                    Cursor.transform.position = new Vector3(
                        19.5f, Cursor.transform.position.y, Cursor.transform.position.z);
                }

            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Cursor.transform.position += new Vector3(-0.1f, 0, 0);
                if (Cursor.transform.position.x <= -19.5f)
                {
                    Cursor.transform.position = new Vector3(
                        -19.5f, Cursor.transform.position.y, Cursor.transform.position.z);
                }
            }

            Cursor.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        }
        else
        {
            Cursor.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        }


        if (Player.GetComponent<Player>().CursorMode == 0 && Input.GetKeyDown(KeyCode.K))
        {
            //if(Block.transform.position.x <= Cursor.transform.position.x)
            //{
            //    Block.transform.position = new Vector3(
            //    Block.transform.position.x, Block.transform.position.y * -1.0f, Block.transform.position.z);
            //}
            //if(Goal_false.transform.position.x<=Cursor.transform.position.x)
            //{
            //    Goal_false.transform.position = new Vector3(
            //   Goal_false.transform.position.x, Goal_false.transform.position.y * -1.0f, Goal_false.transform.position.z);
            //    Goal_false.transform.Rotate(new Vector3(0.0f, 0.0f, 180.0f));
            //}

            //if (Goal_true.transform.position.x <= Cursor.transform.position.x)
            //{
            //    Goal_true.transform.position = new Vector3(
            //   Goal_true.transform.position.x, Goal_true.transform.position.y * -1.0f, Goal_true.transform.position.z);
            //    Goal_true.transform.Rotate(new Vector3(0.0f, 0.0f, 180.0f));
            //}

            //if (Tile.transform.position.x <= Cursor.transform.position.x)
            //{
            //    Tile.transform.position = new Vector3(
            //   Tile.transform.position.x, Tile.transform.position.y * -1.0f, Tile.transform.position.z);
            //}

            //if (Diamond.transform.position.x <= Cursor.transform.position.x)
            //{
            //    Diamond.transform.position = new Vector3(
            //   Diamond.transform.position.x, Diamond.transform.position.y * -1.0f, Diamond.transform.position.z);
            //}

            //if (Frame.transform.position.x <= Cursor.transform.position.x)
            //{
            //    Frame.transform.position = new Vector3(
            //   Frame.transform.position.x, Frame.transform.position.y * -1.0f, Frame.transform.position.z);
            //}

            //if (Player.transform.position.x <= Cursor.transform.position.x)
            //{
            //    Player.transform.position = new Vector3(
            //   Player.transform.position.x, Player.transform.position.y * -1.0f, Player.transform.position.z);
            //}

            GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");

            Count = objects.Length;

            bool TranLeft = Player.transform.position.x <= Cursor.transform.position.x ? false : true;

            TranLeft = Player.GetComponent<SpriteRenderer>().flipX;

            for (int i = 0;i < Count; i++)
            {
                //切り取り線を参照しプレイヤーと異なる側のブロックを反転
                if (objects[i].transform.position.x <= Cursor.transform.position.x && TranLeft || objects[i].transform.position.x > Cursor.transform.position.x && !TranLeft)
                {
                    //objects[i].transform.position = new Vector3(objects[i].transform.position.x, objects[i].transform.position.y * -1.0f, objects[i].transform.position.z);
                    //上下反転だから上か下に向いてるブロックの向きだけを反転するようにする
                    //objects[i].GetComponent<BlockDirection>().blkDirection = (objects[i].GetComponent<BlockDirection>().blkDirection % 2) == 0 ? (objects[i].GetComponent<BlockDirection>().blkDirection + 2) % 4 : objects[i].GetComponent<BlockDirection>().blkDirection;[i].GetComponent<BlockDirection>().blkDirection % 2) == 0 ? (objects[i].GetComponent<BlockDirection>().blkDirection + 2) % 4 : objects[i].GetComponent<BlockDirection>().blkDirection;

                    BlockDirection blk = objects[i].GetComponent<BlockDirection>();
                    blk.StartPosition = objects[i].transform.position;
                    blk.EndPosition = new Vector3(objects[i].transform.position.x, objects[i].transform.position.y * -1.0f, objects[i].transform.position.z);
                    blk.RotateSpeed = 2.0f * Mathf.Abs(objects[i].transform.position.y) / blk.RotateTime;
                    blk.MaxRotateScale = 2.0f * Mathf.Abs(objects[i].transform.position.y) / 28.0f * 2.0f;
                }
                
            }
        }
        
    }
}
