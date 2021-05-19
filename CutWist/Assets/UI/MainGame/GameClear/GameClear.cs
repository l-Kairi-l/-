using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameClear : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image FullGauge;
    [SerializeField]
    private Image ShiningStar1;
    [SerializeField]
    private Image ShiningStar2;
    [SerializeField]
    private Image ShiningStar3;
    GameObject cursor;

    private int bufmode;//その時のカーソルモード
    private float TargetAmount;
    private int StarCount;
    private float star2alpha = 0.0f;
    private float star3alpha = 0.0f;

    void Start()
    {

        //名前を検索してプレハブを参照する
        GameObject obj = (GameObject)Resources.Load("CoursolPoint3D");
        //書き換え終わったプレハブのクローンをインスタンス化する
        Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

        cursor = GameObject.Find("CoursolPoint3D(Clone)");

        //カーソルモードを変更する
        GameObject player = GameObject.Find("Player");
        bufmode = player.GetComponent<Player>().CursorMode;
        player.GetComponent<Player>().CursorMode = -2;

        GameObject cleargauge = GameObject.Find("GameUI_" + GameObject.Find("GameManager").GetComponent<EditManager>().WorldNumber);

        TargetAmount = cleargauge.GetComponent<ClearGauge>().GetTargetAmount();

        StarCount = cleargauge.GetComponent<ClearGauge>().GetStarCount();

        //ShiningStar1.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        ShiningStar2.color = new Color(1.0f,1.0f,1.0f,0.0f);
        ShiningStar3.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
       // ShiningStar1.rectTransform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        ShiningStar2.rectTransform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        ShiningStar3.rectTransform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        FullGauge.fillAmount = 0.0f;
        star2alpha = 0.0f;
        star3alpha = 0.0f;

        GameObject manager = GameObject.Find("GameManager");
        //GameObject cleargauge = GameObject.Find("GameUI_" + GameObject.Find("GameManager").GetComponent<EditManager>().WorldNumber);
        if (cleargauge.GetComponent<ClearGauge>().GetStarCount() > manager.GetComponent<EditManager>().GetClearNumber())
        {
            manager.GetComponent<EditManager>().SetClearNumber(cleargauge.GetComponent<ClearGauge>().GetStarCount());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(FullGauge.fillAmount < TargetAmount)
        {
            FullGauge.fillAmount += 0.2f * Time.deltaTime;
            if(FullGauge.fillAmount > TargetAmount)
            {
                FullGauge.fillAmount = TargetAmount;
            }
           
        }
        else
        {
            FullGauge.fillAmount = TargetAmount;
        }

        if (FullGauge.fillAmount > 0.3f && StarCount > 1)
        {

            star2alpha += 0.5f * Time.deltaTime;
            if (star2alpha > 1.0f)
            {
                star2alpha = 1.0f;
            }
            ShiningStar2.color = new Color(1.0f, 1.0f, 1.0f, star2alpha);
            ShiningStar2.rectTransform.localScale = new Vector3(1.0f + 2.0f * (1.0f - star2alpha), 1.0f + 2.0f * (1.0f - star2alpha), 1.0f + 2.0f * (1.0f - star2alpha));
        }

        if (FullGauge.fillAmount > 0.6f && StarCount > 2)
        {
            star3alpha += 1.0f * Time.deltaTime;
            if (star3alpha > 1.0f)
            {
                star3alpha = 1.0f;
            }
            ShiningStar3.color = new Color(1.0f, 1.0f, 1.0f, star3alpha);
            ShiningStar3.rectTransform.localScale = new Vector3(1.0f + 2.0f * (1.0f - star3alpha), 1.0f + 2.0f * (1.0f - star3alpha), 1.0f + 2.0f * (1.0f - star3alpha));
        }
    }

    public void UnInit()
    {
        //カーソルモードを変更する
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Player>().CursorMode = bufmode;

        Destroy(cursor);
        Destroy(gameObject);
    }
}
