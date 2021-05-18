using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearGauge : MonoBehaviour
{

    [SerializeField]
    private Image FullGauge;
    [SerializeField]
    private Image ShiningStar1;
    [SerializeField]
    private Image ShiningStar2;
    [SerializeField]
    private GameObject gameover;

    private GameObject player;

    public int StarThreeCount = 1;
    public int StarTwoCount = 1;
    public int StarOneCount = 1;

    private int StarTotalCount;
    private int GaugeLife;
    private float StarDiffuseAlpha = 1.0f;
    private float TargetAmount;
    // Start is called before the first frame update
    void Start()
    {
        StarTotalCount = StarThreeCount + StarTwoCount + StarOneCount;
        GaugeLife = StarTotalCount;
        StarDiffuseAlpha = 1.0f;
        TargetAmount = 1.0f;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        StarDiffuseAlpha = Mathf.Sin(Time.time * 2.0f) / 2 + 0.5f;

        if(FullGauge.fillAmount > TargetAmount)
        {
            FullGauge.fillAmount -= 0.1f * Time.deltaTime;

        }
        else
        {
            FullGauge.fillAmount = TargetAmount;
        }

        int mode = player.GetComponent<Player>().CursorMode;
        if (mode != 0 && mode != 1) return;
        if (GaugeLife == StarOneCount + StarTwoCount + 1)
        {
            ShiningStar1.color = new Color(1.0f, 1.0f, 1.0f, StarDiffuseAlpha);

        }
        else if (GaugeLife == StarOneCount + 1)
        {
            ShiningStar2.color = new Color(1.0f, 1.0f, 1.0f, StarDiffuseAlpha);

        }
        else if (GaugeLife == 1&& FullGauge.fillAmount == TargetAmount)
        {
            FullGauge.color = new Color(1.0f, 1.0f, 1.0f, StarDiffuseAlpha);
        }

        if(FullGauge.fillAmount <= 0.0f)
        {
           
            GameObject gov = Instantiate(gameover, new Vector3(0, 0, 0), Quaternion.identity);
        }

    }

    public void BlockRotate()
    {
        GaugeLife--;
        
        if (GaugeLife >= StarOneCount + StarTwoCount)
        {
            TargetAmount = 2.0f / 3.0f + 1.0f / 3.0f * (float)(GaugeLife - StarOneCount - StarTwoCount) / StarThreeCount;
                     
            if(GaugeLife == StarOneCount + StarTwoCount)
                ShiningStar1.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        }
        else if (GaugeLife >= StarOneCount)
        {
            TargetAmount = 1.0f / 3.0f + 1.0f / 3.0f * (float)(GaugeLife - StarOneCount) / StarTwoCount;
            if(GaugeLife == StarOneCount)
            {
                ShiningStar2.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }

        }
        else if (GaugeLife >= 0)
        {
            TargetAmount = 1.0f / 3.0f * (float)GaugeLife / StarOneCount;
            if(GaugeLife == 0)
            {

            }

        }
        
    }
}
