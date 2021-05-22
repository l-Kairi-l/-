using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Debug;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Implements game physics for some in game entity.
    /// </summary>
    public class KinematicObject : MonoBehaviour
    {
        /// <summary>
        /// The minimum normal (dot product) considered suitable for the entity sit on.
        /// </summary>
        public float minGroundNormalY = .65f;

        /// <summary>
        /// A custom gravity coefficient applied to this entity.
        /// </summary>
        public float gravityModifier = 1f;

        /// <summary>
        /// The current velocity of the entity.
        /// </summary>
        public Vector2 velocity;

        /// <summary>
        /// Is the entity currently sitting on a surface?
        /// </summary>
        /// <value></value>
        public bool IsGrounded { get; private set; }

        protected Vector2 targetVelocity;
        protected Vector2 groundNormal;
        protected Rigidbody2D body;
        protected ContactFilter2D contactFilter;
        protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

        protected const float minMoveDistance = 0.001f;
        protected const float shellRadius = 0.01f;

        //カーソルに入ってるかどうか
        public int CursorTrigger;
        //リスト
        //  private int CursorListPos;
        //  private int Cursor2ListPos;

        /// <summary>
        /// Bounce the object's vertical velocity.
        /// </summary>
        /// <param name="value"></param>
        public void Bounce(float value)
        {
            velocity.y = value;
        }

        /// <summary>
        /// Bounce the objects velocity in a direction.
        /// </summary>
        /// <param name="dir"></param>
        public void Bounce(Vector2 dir)
        {
            velocity.y = dir.y;
            velocity.x = dir.x;
        }

        /// <summary>
        /// Teleport to some position.
        /// </summary>
        /// <param name="position"></param>
        public void Teleport(Vector3 position)
        {
            body.position = position;
            velocity *= 0;
            body.velocity *= 0;
        }

        protected virtual void OnEnable()
        {
            body = GetComponent<Rigidbody2D>();
            body.isKinematic = true;
        }

        protected virtual void OnDisable()
        {
            body.isKinematic = false;
        }

        protected virtual void Start()
        {
            contactFilter.useTriggers = false;
            contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
            contactFilter.useLayerMask = true;

            Physics2D.gravity = new Vector2(0, -70f);

            CursorTrigger = -1;
        }
        public virtual void GravityZero()
        {
            Physics2D.gravity = new Vector2(0, 0);
        }

        public virtual void GravityReset()
        {
            Physics2D.gravity = new Vector2(0, -70f);
        }

        protected virtual void Update()
        {
            //変数にreset
            CursorTrigger = -1;

            targetVelocity = Vector2.zero;
            ComputeVelocity();
        }

        protected virtual void ComputeVelocity()
        {

        }

        protected virtual void FixedUpdate()
        {

            //if already falling, fall faster than the jump speed, otherwise use normal gravity.
            if (velocity.y < 0)
                velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
            else
                velocity += Physics2D.gravity * Time.deltaTime;

            velocity.x = targetVelocity.x;

            IsGrounded = false;

            var deltaPosition = velocity * Time.deltaTime;

            var moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

            var move = moveAlongGround * deltaPosition.x;

            PerformMovement(move, false);

            move = Vector2.up * deltaPosition.y;

            PerformMovement(move, true);

        }

        void PerformMovement(Vector2 move, bool yMovement)
        {
            var distance = move.magnitude;

            if (distance > minMoveDistance)
            {
                //check if we hit anything in current direction of travel
                var count = body.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
                for (var i = 0; i < count; i++)
                {
                    var currentNormal = hitBuffer[i].normal;

                    //is this surface flat enough to land on?
                    if (currentNormal.y > minGroundNormalY)
                    {
                        IsGrounded = true;
                        // if moving up, change the groundNormal to new surface normal.
                        if (yMovement)
                        {
                            groundNormal = currentNormal;
                            currentNormal.x = 0;
                        }
                    }
                    if (IsGrounded)
                    {
                        //how much of our velocity aligns with surface normal?
                        var projection = Vector2.Dot(velocity, currentNormal);
                        if (projection < 0)
                        {
                            //slower velocity if moving against the normal (up a hill).
                            velocity = velocity - projection * currentNormal;
                        }
                    }
                    else
                    {
                        //We are airborne, but hit something, so cancel vertical up and horizontal velocity.
                        velocity.x *= 0;
                        //velocity.y = Mathf.Min(velocity.y, 0);
                    }
                    //remove shellDistance from actual move distance.
                    var modifiedDistance = hitBuffer[i].distance - shellRadius;
                    distance = modifiedDistance < distance ? modifiedDistance : distance;
                }
            }
            body.position = body.position + move.normalized * distance;
        }

        protected void SetPos(Vector2 pos)
        {
            body.position = pos;
        }

        protected Vector2 GetPos()
        {
            return body.position;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            //if (CursorTrigger==-1)
            //{
            //    GameObject CursorGameObject;
            //    CursorGameObject = GameObject.Find("0Center2");
            //    CursorGameObject.GetComponent<CursorManeger2>().AddOnObject(this);

            //}

        }
        private void OnTriggerEnter2D(Collider2D other)
        {

            //if (other.gameObject.tag == "Cursor")//条件式：衝突したオブジェクトのタグが"Player"の場合
            //{
            //    CursorTrigger = 0;


            //}
            //else if (other.gameObject.tag == "Cursor2")//条件式：衝突したオブジェクトのタグが"Player"の場合
            //{
            //    CursorTrigger = 2;
            //    GameObject CursorGameObject;
            //    CursorGameObject = GameObject.Find("0Center2");
            //    CursorGameObject.GetComponent<CursorManeger2>().AddOnObject(this);

            //}

        }
        private void OnTriggerExit2D(Collider2D other)
        {
            CursorTrigger = -1;

            if (other.gameObject.tag == "Cursor")//条件式：衝突したオブジェクトのタグが"Player"の場合
            {


            }
            else if (other.gameObject.tag == "Cursor2")//条件式：衝突したオブジェクトのタグが"Player"の場合
            {
                //GameObject CursorGameObject;
                //CursorGameObject = GameObject.Find("0Center2");
                //CursorGameObject.GetComponent<CursorManeger2>().RemoveOnObject(this);

            }


        }


    }
}