using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Return : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite tex_return;
    public Sprite tex_return2;
    AudioSource audioSource;

    private bool select;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (select)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.Play();
                GameObject root = transform.root.gameObject;
                //transform.parent.gameObject 一個上
                root.GetComponent<Option>().UnInit();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {

            Image MainSprite = GetComponent<Image>();
            MainSprite.sprite = tex_return2;
            select = true;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CoursolPoint")
        {

            Image MainSprite = GetComponent<Image>();
            MainSprite.sprite = tex_return;
            select = false;
        }
    }

}
