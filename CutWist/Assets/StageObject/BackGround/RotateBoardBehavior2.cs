using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoardBehavior2 : MonoBehaviour
{

    static public bool IsInverse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        gameObject.GetComponent<Transform>().Rotate(new Vector3(0.0f, (IsInverse ? 1.0f : -1.0f ) * 180.0f / BlockDirection.RotateTime * Time.deltaTime, 0.0f));




        if (BlockDirection.RotationState == BlockDirection.ROTATION_STATE_NAME.Rotated)
        {
            Destroy(gameObject);
        }
    }
}
