using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class CloudBlockController : MonoBehaviour
{
    public bool CloudDestroy = false;
    float second;// 時間計測をするための変数
    public float positionX = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        positionX = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (CloudDestroy == true)
        {
            gameObject.GetComponent<Renderer>().material.color += new Color(0.0f, 0.0f, 0.0f, -0.005f);
            if (gameObject.GetComponent<Renderer>().material.color.a <= 0.0f)// オブジェクトが完全に画面から消えたら
            {
                // 無理やり遠くへ飛ばす
                gameObject.transform.position = new Vector3(
                      gameObject.transform.position.x+500.0f, gameObject.transform.position.y, gameObject.transform.position.z);
                second += Time.deltaTime;// 時間をカウント

            }
            

        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

        if(second>=3)// この秒数を超えると雲が復活
        {
            // 無理やり元の位置へ戻す
            gameObject.transform.position = new Vector3(
                    positionX, gameObject.transform.position.y, gameObject.transform.position.z);
            second = 0;
            CloudDestroy = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーにあたった場合
        if (other.gameObject.tag == "Player")
        {
            // 雲が消える
            CloudDestroy = true;

        }
    }
}
