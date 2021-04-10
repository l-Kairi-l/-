using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer MainSprite;

    public Sprite Number0;
    public Sprite Number1;
    public Sprite Number2;
    public Sprite Number3;
    public Sprite Number4;
    public Sprite Number5;
    public Sprite Number6;
    public Sprite Number7;
    public Sprite Number8;
    public Sprite Number9;


    void Start()
    {
        MainSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetPos()
    { return transform.position; }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public void SetColor(Color c)
    {
        SpriteRenderer color = GetComponent<SpriteRenderer>();

        color.material.color = c;
    }

    public void SetNumber(int number)
    {
        switch (number)
        {
            case 0:
                MainSprite.sprite = Number0;
                break;
            case 1:
                MainSprite.sprite = Number1;
                break;
            case 2:
                MainSprite.sprite = Number2;
                break;
            case 3:
                MainSprite.sprite = Number3;
                break;
            case 4:
                MainSprite.sprite = Number4;
                break;
            case 5:
                MainSprite.sprite = Number5;
                break;
            case 6:
                MainSprite.sprite = Number6;
                break;
            case 7:
                MainSprite.sprite = Number7;
                break;
            case 8:
                MainSprite.sprite = Number8;
                break;
            case 9:
                MainSprite.sprite = Number9;
                break;
        }

    }
}
