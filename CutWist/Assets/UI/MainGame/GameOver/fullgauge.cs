using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fullgauge : MonoBehaviour
{
    [SerializeField]
    private Image FullGauge;
    private float DiffuseAlpha = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        DiffuseAlpha = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        DiffuseAlpha = Mathf.Sin(Time.time * 2.0f) / 2 + 0.5f;
        FullGauge.color= new Color(1.0f, 1.0f, 1.0f, DiffuseAlpha);
    }
}
