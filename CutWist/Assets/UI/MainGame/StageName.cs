using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageName : MonoBehaviour
{

    public Sprite tex_star;
    public Sprite tex_sweet;
    public Sprite tex_forest;

    // Start is called before the first frame update
    void Start()
    {
        GameObject manager = GameObject.Find("GameManager");
        Image MainSprite = GetComponent<Image>();
        switch ( manager.GetComponent<EditManager>().WorldNumber )
        {
            case 1:
                
                MainSprite.sprite = tex_forest;
                break;
            case 2:
                MainSprite.sprite = tex_sweet;
                break;

            case 3:
                MainSprite.sprite = tex_star;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
