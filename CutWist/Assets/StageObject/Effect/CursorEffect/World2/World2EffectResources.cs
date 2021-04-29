using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Effect.Particle;
public class World2EffectResources : MonoBehaviour
{
    List<ParticleList> EffectLists = new List<ParticleList>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < EffectLists.Count; i++)
        {
            ParticleList list = EffectLists[i];

            if (list.nowframe == list.frame)
            {
                InstanceParticle(list);

                EffectLists.Remove(EffectLists[i]);
                //要素数が減った時に、詰められるので同じ場所をまた参照する
                i--;
            }
            else
            {
                list.nowframe++;
            }
        }
    }

    public void SetParticle(int type, Vector3 pos, int frame, Vector3 vector, Vector3 size, Color color)
    {
        ParticleList particle = new ParticleList();
        particle.type = type;
        particle.pos = pos;
        particle.frame = frame;
        particle.nowframe = 0;
        particle.addvector = vector;
        particle.addsize = size;
        particle.addcolor = color;
        EffectLists.Add(particle);
    }

    void InstanceParticle(ParticleList particle)
    {
        //名前を検索してプレハブを参照する
        GameObject obj = (GameObject)Resources.Load("World2Cursor1Particle");

        //参照したプレハブを直接書き換える
        obj.GetComponent<World2CursorParticle>().SetType(particle.type, particle.addvector, particle.addsize, particle.addcolor);

        //書き換え終わったプレハブのクローンをインスタンス化する
        Instantiate(obj, new Vector3(particle.pos.x, particle.pos.y, particle.pos.z), Quaternion.identity);

    }
}
