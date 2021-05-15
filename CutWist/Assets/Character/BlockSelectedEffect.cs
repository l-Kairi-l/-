using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSelectedEffect : MonoBehaviour
{
    public float change;
    public MeshRenderer mrenderer;
    public Dictionary<Material, Color> _materialAndInitialColors;
    public bool EffectEnable;
    // Start is called before the first frame update
    void Start()
    {
        mrenderer = gameObject.GetComponent<MeshRenderer>();
        _materialAndInitialColors = new Dictionary<Material, Color>();
        EffectEnable = false;

        foreach (Material material in mrenderer.materials)//マテリアルすべてを調査
        {
            
            _materialAndInitialColors.Add(material, material.color);
           
        }
    }
    // Update is called once per frame
    void Update()
    {

        change = (Mathf.Sin(Time.time * 2.0f) / 2 + 0.5f) * 0.5f;
        if (!EffectEnable) return;
        foreach (Material mat in mrenderer.materials)
        {
            mat.color = new Color(0.5f + change, 0.5f + change, 0.5f + change);
        }
    }
    public void ColorReset()
    {
        foreach (Material material in mrenderer.materials)//マテリアルすべてを調査
        {

            material.color = _materialAndInitialColors[material];
           

        }
        EffectEnable = false;
    }


}
