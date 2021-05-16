using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class Sheep : KinematicObject
{
    // Start is called before the first frame update
    bool GaolFlag;
    void Awake()
    {
        GaolFlag = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // キャラクターがあたった場合
        if (other.gameObject.tag == "Player")
        {
            //目覚まし時計を持っているとき
            if (GaolFlag)
            {
                Debug.Log("ゴール");

            }
        }
    }

}


/*
 public class Sheep : MonoBehaviour
{
    // Start is called before the first frame update
    bool GaolFlag;
    void Start()
    {
        GaolFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // キャラクターがあたった場合
        if (other.gameObject.tag == "Player")
        {
            //目覚まし時計を持っているとき
            if (GaolFlag)
            {
                Debug.Log("ゴール");

            }
        }
    }

}
*/
