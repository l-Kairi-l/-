using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFrame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "CoursolPoint")
        {
            transform.localScale += new Vector3(0.035f, 0.055f, 0.0f);
            if (transform.localScale.x >= 1.05f || transform.localScale.y >= 1.65f)
            {
                transform.localScale = new Vector3(1.05f, 1.65f, 0.0f);

            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // トゲにあたった場合
        if (other.gameObject.tag == "CoursolPoint")
        {
            transform.localScale = new Vector3(0.7f, 1.1f, 0.0f);

        }
    }

}
