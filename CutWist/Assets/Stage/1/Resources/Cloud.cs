using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=new Vector3(0.002f,0,0);

        if (transform.position.x > 55)
        {
            Destroy(gameObject);//衝突したオブジェクトを削除
        }
    }
}
