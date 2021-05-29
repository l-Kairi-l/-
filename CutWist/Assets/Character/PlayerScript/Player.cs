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
    [SerializeField]
    private GameObject gameover;

    // Start is called before the first frame update

    //ジャンプの状態
    public JumpState jumpState = JumpState.Grounded;
    //移動スピード
    public const float maxSpeed = 10;
    //移動の加算スピード
    public Vector2 move;
    //操作できるかの有無
    public bool controlEnabled = true;
    // 消滅判定
    public bool destroy = false;

    public AudioClip sound_needle;
    public AudioClip sound_clock;
    public AudioClip sound_sheep;
    public AudioClip sound_jump;
    AudioSource audioSource;
    // private bool stopJump;
    //座標変換
    // Rigidbody2D rb;

    //スプライトの向き
    //  SpriteRenderer spriteRenderer;

    private bool stopJump;

    readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

    //ジャンプ関係
    bool jump;
    public const float jumpTakeOffSpeed = 3.9f;

    //カーソル
    GameObject Camera;

    public int CursorMode;

    //プレイヤーのフラグ
    public bool clock;
    public GameObject cleareffect;

    //アニメーション
    private Animator animator;

    private GameObject cleargauge;
    private GameObject Cursor1;
    private GameObject Cursor2;

    void Awake()
    {
        //  rb = GetComponent<Rigidbody2D>();
      //  spriteRenderer = GetComponent<SpriteRenderer>();
        Camera = GameObject.Find("PlayCamera");//.GetComponent<CursorManeger>();

        CursorMode = -1;
        clock = false;
        cleargauge = GameObject.Find("GameUI_" + GameObject.Find("GameManager").GetComponent<EditManager>().WorldNumber);
        Cursor1 = GameObject.Find("cursor1_star");
        Cursor2 = GameObject.Find("cursor2_star");
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    //キー入力など、オブジェクトのメンバ関数
    protected override void Update()
    {
        if (CursorMode == -2) return;

        if (controlEnabled)
        {
            animator.SetBool("Move", false);

            if (CursorMode == -1)
            {

                move.x = Input.GetAxis("Horizontal");

                //アニメーション

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {

                    if (move.x > 0.01f)
                    {
                        animator.SetBool("Move", true);

                        animator.SetBool("Vector", true);

                        transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);

                    }
                    if (move.x < -0.01f)
                    {
                        animator.SetBool("Move", true);

                        animator.SetBool("Vector", false);

                        transform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);

                    }
                }

                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                {
                    jumpState = JumpState.PrepareToJump;
                    animator.SetBool("Jump", true);

                }
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;

                }
            }
            else 
            {
                if(CursorMode != -3)
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                    {
                        CursorMode = 1;
                        //CursorMode = CursorMode == -1 ? -1 : CursorMode == 0 ? 1 : 0;
                        BlockDirection.RotateMode = CursorMode == -1 ? BlockDirection.RotateMode : CursorMode == 0 ? 0 : 1;
                        Cursor1.GetComponent<Transform>().position = new Vector3(-30.0f, Cursor1.GetComponent<Transform>().position.y, Cursor1.GetComponent<Transform>().position.z);

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
                    else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                    {
                        CursorMode = 0;
                        //CursorMode = CursorMode == -1 ? -1 : CursorMode == 0 ? 1 : 0;
                        BlockDirection.RotateMode = CursorMode == -1 ? BlockDirection.RotateMode : CursorMode == 0 ? 0 : 1;
                        Cursor2.GetComponent<Transform>().position = new Vector3(Cursor2.GetComponent<Transform>().position.x, -20.0f, Cursor2.GetComponent<Transform>().position.z);
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
                }
               
                move.x = 0;
            }
        }
        else
        {
            move.x = 0;
        }

        if ((Input.GetKeyDown(KeyCode.RightShift)|| Input.GetKeyDown(KeyCode.LeftShift) )&& cleargauge.GetComponent<ClearGauge>().GetGaugeLife() > 0 && CursorMode != -3)
        {
            //モード変更時

            //ポジションを正規化する
            float vecx = (int)(gameObject.transform.position.x + 0.5f) + (int)(gameObject.transform.position.x + 0.5f)%2;

            CursorMode = CursorMode == -1 ? 0 : -1;
            Cursor1.GetComponent<Transform>().position = CursorMode == -1 ? new Vector3(-30.0f, Cursor1.GetComponent<Transform>().position.y, Cursor1.GetComponent<Transform>().position.z) :
                new Vector3(vecx, Cursor1.GetComponent<Transform>().position.y, Cursor1.GetComponent<Transform>().position.z);
            Cursor2.GetComponent<Transform>().position = new Vector3(Cursor2.GetComponent<Transform>().position.x, -20.0f, Cursor2.GetComponent<Transform>().position.z);
            BlockDirection.RotateMode = CursorMode == -1 ? BlockDirection.RotateMode : 0;

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
                animator.SetBool("Jump", false);

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

    public void SetJump ()
    {
        switch (jumpState)
        {
            case JumpState.PrepareToJump:
                break;
            case JumpState.Jumping:
                break;
            case JumpState.InFlight:
                break;
            case JumpState.Landed:

                break;
        }
        move.x = 0;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CursorMode == -2) return;
        if (CursorMode == -3) return;

        // トゲにあたった場合
        if (other.gameObject.tag == "Needle")
        {
            // プレイヤーが消える
            destroy = true;
            // 動かせなくなる
            controlEnabled = false;

            audioSource.PlayOneShot(sound_needle);

            GameObject gov = Instantiate(gameover, new Vector3(0, 0, 0), Quaternion.identity);

            CursorMode = -2;

            GetComponent<Animator>().SetBool("Die", true);

            //string s_name = "World";
            //string s_number = "" + 1;

            //// プレハブをGameObject型で取得
            //GameObject obj = (GameObject)Resources.Load("Transition_1");
            //obj.GetComponent<Transition>().SetNextScene(s_name + s_number);

            //// プレハブを元に、インスタンスを生成、
            //Instantiate(obj, new Vector3(0.0f, 0.0f, -90.0f), Quaternion.identity);


        }
        else if (other.gameObject.name == "alarm_clock")
        {
            clock = true;
            other.GetComponent<Alarm_Clock>().Set(true);
            audioSource.PlayOneShot(sound_clock);
        }
        else if (other.gameObject.name == "GoalSheep")
        {
            if (clock)
            {
                CursorMode = -2;
                audioSource.PlayOneShot(sound_sheep);
                cleareffect.GetComponent<ClearEffect>().Set(other.gameObject);
                other.gameObject.GetComponent<Animator>().SetBool("Clear", true);
                GetComponent<Animator>().SetBool("Goal", true);
                transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                move = new Vector2(0.0f, 0.0f);
                targetVelocity = move * maxSpeed;

                other.gameObject.transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }
            else
            {
                // プレハブをGameObject型で取得
                GameObject obj = (GameObject)Resources.Load("GoalUI");

                // プレハブを元に、インスタンスを生成、
                Instantiate(obj, new Vector3(other.gameObject.transform.position.x + 2.0f,
                    other.gameObject.transform.position.y + 3.0f,
                    other.gameObject.transform.position.z - 2.0f), Quaternion.identity);

            }

        }
        else if (other.gameObject.name == "Bound")
        {
            if (other.gameObject.transform.position.y < transform.position.y)
            {

                audioSource.PlayOneShot(sound_jump);
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                animator.SetBool("Jump", true);
            }

        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "GoalSheep")
        {
            if (!clock)
            {

                Destroy(GameObject.Find("GoalUI(Clone)"));
            }

        }


    }


}
