using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.1f, 0.0f, 0.0f);
        transform.Rotate(new Vector3(2.0f, 2.0f, 0.0f));

        if (transform.position.x > 28) Destroy(gameObject);
    }
}
