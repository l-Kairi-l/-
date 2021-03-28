using System.Collections;
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

   // private bool stopJump;
    //座標変換
   // Rigidbody2D rb;

    //スプライトの向き
    SpriteRenderer spriteRenderer;

    private bool stopJump;

    readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

    //ジャンプ関係
    bool jump;
    public const float jumpTakeOffSpeed = 8;

    //カーソル
    GameObject Camera;

    public int CursorMode;

    void Awake()
    {
      //  rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Camera = GameObject.Find("Main Camera");//.GetComponent<CursorManeger>();

        CursorMode = -1;
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
            CursorMode = CursorMode == -1 ? 0 : -1;
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            CursorMode = CursorMode == -1 ? -1 : CursorMode == 0 ? 1 : 0;
        }

        UpdateJumpState();
        base.Update();
        
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
        if (other.gameObject.tag == "Toge")//条件式：衝突したオブジェクトのタグが"Player"の場合
        {
            Destroy(gameObject);//衝突したオブジェクトを削除
        }
        else if(other.gameObject.tag == "Goal")
        {
            Debug.Log("ゴール");
        }
    }
      //  SceneManager.LoadScene("Clear");

    

}
