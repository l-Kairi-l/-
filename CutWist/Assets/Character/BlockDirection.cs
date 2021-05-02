using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDirection : MonoBehaviour
{





    public Vector3 StartPosition;
    public Vector3 EndPosition;

    // public Quaternion StartRotation;
    // public Quaternion EndRotation;
    //public float MaxRotateScale;
    static public float RotateTime = 240.0f;
    static public float PassedTime;
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

    static public ROTATION_STATE_NAME RotationState;
    public ROTATION_TYPE_NAME RotateType;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = gameObject.GetComponent<Transform>().position;
        EndPosition = StartPosition;
        // StartRotation = gameObject.GetComponent<Transform>().rotation;
        //EndRotation = StartRotation;
        DefaultPosition = StartPosition;
        //BlockDefaultScale = gameObject.GetComponent<Transform>().localScale;
        RotationState = ROTATION_STATE_NAME.Rotated;
        PassedTime = 0.0f;
        RotateType = ROTATION_TYPE_NAME.Outside;
    }

    // Update is called once per frame
    void Update()
    {
        int sign = (RotateType == ROTATION_TYPE_NAME.Outside ? -1 : 1);
        if(gameObject.name != "GoalSheep" && gameObject.name != "alarm_clock")
            //gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(
            //    sign * Mathf.Rad2Deg * (DefaultPosition.y > 0 ? Mathf.Acos(gameObject.GetComponent<Transform>().position.y / DefaultPosition.y) : -Mathf.Acos(gameObject.GetComponent<Transform>().position.y / DefaultPosition.y)),
            //    sign * Mathf.Rad2Deg * (DefaultPosition.x > 0 ? -Mathf.Acos(gameObject.GetComponent<Transform>().position.x / DefaultPosition.x) : Mathf.Acos(gameObject.GetComponent<Transform>().position.x / DefaultPosition.x)),
            //    0.0f);
            //gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(
            //   -Mathf.Sign(DefaultPosition.y) * Mathf.Sign(StartPosition.y) * Mathf.Rad2Deg * Mathf.Acos(gameObject.GetComponent<Transform>().position.y / DefaultPosition.y),
            //   -Mathf.Sign(DefaultPosition.x) * Mathf.Sign(StartPosition.x) * Mathf.Rad2Deg * Mathf.Acos(gameObject.GetComponent<Transform>().position.x / DefaultPosition.x),
            //   0.0f);
              gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(
                  -Mathf.Sign(DefaultPosition.y / StartPosition.y) * Mathf.Sign(DefaultPosition.x / StartPosition.x) * Mathf.Rad2Deg * Mathf.Acos(gameObject.GetComponent<Transform>().position.y / DefaultPosition.y),
                  -Mathf.Sign(DefaultPosition.x / StartPosition.x) * Mathf.Sign(DefaultPosition.y / StartPosition.y) * Mathf.Rad2Deg * Mathf.Acos(gameObject.GetComponent<Transform>().position.x / DefaultPosition.x),
                  0.0f);
        if (Mathf.Abs(EndPosition.y - gameObject.GetComponent<Transform>().position.y) > 0.001f)
        {

            gameObject.GetComponent<Transform>().position = new Vector3(
                gameObject.GetComponent<Transform>().position.x,
                StartPosition.y * Mathf.Cos(Mathf.PI * PassedTime / RotateTime),
                 sign * Mathf.Abs(StartPosition.y) * Mathf.Sin(Mathf.PI * PassedTime / RotateTime));

        }
        else if (Mathf.Abs(EndPosition.x - gameObject.GetComponent<Transform>().position.x) > 0.001f)
        {

            gameObject.GetComponent<Transform>().position = new Vector3(
                StartPosition.x * Mathf.Cos(Mathf.PI * PassedTime / RotateTime),
                gameObject.GetComponent<Transform>().position.y,
                sign * Mathf.Abs(StartPosition.x) * Mathf.Sin(Mathf.PI * PassedTime / RotateTime));
        }
        else
        {
            gameObject.GetComponent<Transform>().position = EndPosition;

            StartPosition = EndPosition;



        }

    }
}
