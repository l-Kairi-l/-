using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDirection : MonoBehaviour
{

    public Vector3 StartPosition;
    public Vector3 EndPosition;


    public Quaternion StartRotation;
    //public float MaxRotateScale;
    static public float RotateTime = 2.0f;
    static public float PassedTime = 0.0f;
    //public float RotateSpeed;
    // private Vector3 BlockDefaultScale;
    public Vector3 DefaultPosition;


    public enum ROTATION_STATE_NAME
    {
        Rotating,
        Rotated,
    }

    public enum ROTATION_TYPE_NAME
    {
        Outside,
        Inside,
    }

    static public ROTATION_STATE_NAME RotationState = ROTATION_STATE_NAME.Rotated;
    public ROTATION_TYPE_NAME RotateType;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = gameObject.GetComponent<Transform>().position;
        EndPosition = StartPosition;
        StartRotation = gameObject.GetComponent<Transform>().rotation;
        //EndRotation = StartRotation;
        DefaultPosition = StartPosition;
        //BlockDefaultScale = gameObject.GetComponent<Transform>().localScale;
        //RotationState = ROTATION_STATE_NAME.Rotated;
        //PassedTime = 0.0f;
        RotateType = ROTATION_TYPE_NAME.Outside;
        // RotateTime = 2.0f;


    }

    // Update is called once per frame
    void Update()
    {

        int sign = (RotateType == ROTATION_TYPE_NAME.Outside ? -1 : 1);
        //if (gameObject.name != "GoalSheep" && gameObject.name != "alarm_clock")
        //gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(
        //    sign * Mathf.Rad2Deg * (DefaultPosition.y > 0 ? Mathf.Acos(gameObject.GetComponent<Transform>().position.y / DefaultPosition.y) : -Mathf.Acos(gameObject.GetComponent<Transform>().position.y / DefaultPosition.y)),
        //    sign * Mathf.Rad2Deg * (DefaultPosition.x > 0 ? -Mathf.Acos(gameObject.GetComponent<Transform>().position.x / DefaultPosition.x) : Mathf.Acos(gameObject.GetComponent<Transform>().position.x / DefaultPosition.x)),
        //    0.0f);
        //gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(
        //   -Mathf.Sign(DefaultPosition.y) * Mathf.Sign(StartPosition.y) * Mathf.Rad2Deg * Mathf.Acos(gameObject.GetComponent<Transform>().position.y / DefaultPosition.y),
        //   -Mathf.Sign(DefaultPosition.x) * Mathf.Sign(StartPosition.x) * Mathf.Rad2Deg * Mathf.Acos(gameObject.GetComponent<Transform>().position.x / DefaultPosition.x),
        //   0.0f);
        //gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(
        //    -Mathf.Sign(DefaultPosition.y / StartPosition.y) * Mathf.Sign(DefaultPosition.x / StartPosition.x) * Mathf.Rad2Deg * Mathf.Acos(gameObject.GetComponent<Transform>().position.y / DefaultPosition.y),
        //    -Mathf.Sign(DefaultPosition.x / StartPosition.x) * Mathf.Sign(DefaultPosition.y / StartPosition.y) * Mathf.Rad2Deg * Mathf.Acos(gameObject.GetComponent<Transform>().position.x / DefaultPosition.x),
        //    0.0f);


        if (Mathf.Abs(EndPosition.y - gameObject.GetComponent<Transform>().position.y) > Mathf.Abs(gameObject.GetComponent<Transform>().position.y) * Time.deltaTime)
        {

            if (RotationState == ROTATION_STATE_NAME.Rotating)
            {
                gameObject.GetComponent<Transform>().position = new Vector3(
               gameObject.GetComponent<Transform>().position.x,
               StartPosition.y * Mathf.Cos(Mathf.PI * PassedTime / RotateTime),
                sign * Mathf.Abs(StartPosition.y) * Mathf.Sin(Mathf.PI * PassedTime / RotateTime));

                //gameObject.GetComponent<Transform>().Rotate(new Vector3(Mathf.Sign(DefaultPosition.x / StartPosition.x) *sign * Mathf.Sign(StartPosition.y) * 180.0f / RotateTime * Time.deltaTime, 0.0f, 0.0f));
                gameObject.GetComponent<Transform>().Rotate(new Vector3(sign * Mathf.Sign(StartPosition.y) * 180.0f / RotateTime * Time.deltaTime, 0.0f, 0.0f), Space.World);

            }



        }
        else if (Mathf.Abs(EndPosition.x - gameObject.GetComponent<Transform>().position.x) > Mathf.Abs(gameObject.GetComponent<Transform>().position.x) * Time.deltaTime)
        {
            if (RotationState == ROTATION_STATE_NAME.Rotating)
            {
                gameObject.GetComponent<Transform>().position = new Vector3(
                StartPosition.x * Mathf.Cos(Mathf.PI * PassedTime / RotateTime),
                gameObject.GetComponent<Transform>().position.y,
                sign * Mathf.Abs(StartPosition.x) * Mathf.Sin(Mathf.PI * PassedTime / RotateTime));
                //gameObject.GetComponent<Transform>().Rotate(new Vector3(0.0f, -Mathf.Sign(DefaultPosition.y / StartPosition.y) * sign * Mathf.Sign(StartPosition.x) * 180.0f / RotateTime * Time.deltaTime, 0.0f));
                gameObject.GetComponent<Transform>().Rotate(new Vector3(0.0f, -sign * Mathf.Sign(StartPosition.x) * 180.0f / RotateTime * Time.deltaTime, 0.0f), Space.World);
            }
        }


        else
        {
            if (RotationState == ROTATION_STATE_NAME.Rotated)
            {
                gameObject.GetComponent<Transform>().position = EndPosition;

                StartPosition = EndPosition;
                if (gameObject.name != "GoalSheep" && gameObject.name != "alarm_clock")
                    gameObject.GetComponent<Transform>().rotation = StartRotation;

                //gameObject.GetComponent<Transform>().Rotate
            }




        }



    }
}
