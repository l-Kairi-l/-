﻿using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using Platformer.Model;
using static Platformer.Core.Simulation;
using Platformer.Core;
using Platformer.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : KinematicObject
{


    // Start is called before the first frame update

    //ジャンプの状態
    public JumpState jumpState = JumpState.Grounded;
    //移動スピード
    public const float maxSpeed = 30;
    //移動の加算スピード
    Vector2 move;
    //操作できるかの有無
    public bool controlEnabled = true;
    // 消滅判定
    public bool destroy = false;

   // private bool stopJump;
    //座標変換
   // Rigidbody2D rb;

    //スプライトの向き
    SpriteRenderer spriteRenderer;

    private bool stopJump;

    readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

    //ジャンプ関係
    bool jump;
    public const float jumpTakeOffSpeed = 5;

    //カーソル
    GameObject Camera;

    public int CursorMode;

    //プレイヤーのフラグ
    public bool clock;
    public GameObject cleareffect;


    void Awake()
    {
      //  rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Camera = GameObject.Find("PlayCamera");//.GetComponent<CursorManeger>();

        CursorMode = -1;
        clock = false;
    }

    // Update is called once per frame

    //キー入力など、オブジェクトのメンバ関数
    protected override void Update()
    {

       
            if (controlEnabled)
            {
                if (CursorMode == -1)
                {
                    move.x = Input.GetAxis("Horizontal");
                    if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                        jumpState = JumpState.PrepareToJump;
                    else if (Input.GetButtonUp("Jump"))
                    {
                      stopJump = true;
                        Schedule<PlayerStopJump>().player = this;
                        
                    }
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        move.x *= 1.5f;
                        //  SceneManager.LoadScene("Scene2");
    
                    }


                }
            else
            {
                move.x = 0;
            }

        }
        else
            {
                move.x = 0;
            }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            //モード変更時
          GameObject  manager= GameObject.Find("GameManager");
            //true==EditCameraモード false==PlayCameraモード
            manager.GetComponent<EditManager>().SetEditMode(CursorMode == -1 ? true : false);

            CursorMode = CursorMode == -1 ? 0 : -1;

            GameObject[] objects;

            objects = GameObject.FindGameObjectsWithTag("Object");

            foreach(GameObject obj in objects)
            {
                BlockSelectedEffect bse = obj.GetComponent<BlockSelectedEffect>();
                if (bse)
                {
                    bse.ColorReset();
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            CursorMode = CursorMode == -1 ? -1 : CursorMode == 0 ? 1 : 0;

            GameObject[] objects;

            objects = GameObject.FindGameObjectsWithTag("Object");

            foreach (GameObject obj in objects)
            {
                BlockSelectedEffect bse = obj.GetComponent<BlockSelectedEffect>();
                if (bse)
                {
                    bse.ColorReset();
                }
            }
        }

        UpdateJumpState();
        base.Update();

        // 消滅判定がtrueになったら
        if (destroy == true)
        {
            gameObject.GetComponent<Renderer>().material.color += new Color(0.0f, 0.0f, 0.0f, -0.01f);
        }

        //  Camera.GetComponent<PlayCamera>().AddPosition(new Vector3(targetVelocity.x, targetVelocity.y, 0.0f));
       // Camera.GetComponent<PlayCamera>().SetPosition(new Vector3(GetPos().x, GetPos().y+2.0f, -150.0f));

    }


    //ジャンプ判定
    void UpdateJumpState()
    {
        jump = false;
        switch (jumpState)
        {
            case JumpState.PrepareToJump:
                jumpState = JumpState.Jumping;
                jump = true;
                stopJump = false;
                break;
            case JumpState.Jumping:
                if (!IsGrounded)
                {
                    Schedule<PlayerJumped>().player = this;
                    jumpState = JumpState.InFlight;
                }
                break;
            case JumpState.InFlight:
                if (IsGrounded)
                {
                    Schedule<PlayerLanded>().player = this;
                    jumpState = JumpState.Landed;
                }
                break;
            case JumpState.Landed:
                jumpState = JumpState.Grounded;
                break;
        }


    }

    //ジャンプの関数

    protected override void ComputeVelocity()
    {
        if (jump && IsGrounded)
        {
            velocity.y = jumpTakeOffSpeed * model.jumpModifier;
            jump = false;
        }
        else if (stopJump)
        {
            stopJump = false;
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * model.jumpDeceleration;
            }
        }

        if (move.x > 0.01f)
        {
            spriteRenderer.flipX = false;

       //     rb.AddForce(transform.right * (move.x * 5));
        }
        else if (move.x < -0.01f)
        {
            spriteRenderer.flipX = true;

        //    rb.AddForce(transform.right * (move.x * 5));
        }

        targetVelocity = move * maxSpeed;
    }



    public enum JumpState
    {
        Grounded,
        PrepareToJump,
        Jumping,
        InFlight,
        Landed
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "Needle")
        {
            // プレイヤーが消える
            destroy = true;
            // 動かせなくなる
            controlEnabled = false;


            string s_name = "World";
            string s_number = "" + 1;

            // プレハブをGameObject型で取得
            GameObject obj = (GameObject)Resources.Load("Transition_1");
            obj.GetComponent<Transition>().SetNextScene(s_name + s_number);

            // プレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);


        }
        else if (other.gameObject.name == "alarm_clock")
        {
            clock = true;
            other.GetComponent<Alarm_Clock>().Set(true);
        }
        else if(other.gameObject.name == "GoalSheep")
        {
            if (clock)
            {

                cleareffect.GetComponent<ClearEffect>().Set(other.transform.position);
                 Destroy(other.gameObject);

            }
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {


    }



}
