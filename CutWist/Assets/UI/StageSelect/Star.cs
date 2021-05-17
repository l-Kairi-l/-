using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite True;
    public Sprite False;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetTexture(bool clear)
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = (clear) ? True : False;
    }
}
