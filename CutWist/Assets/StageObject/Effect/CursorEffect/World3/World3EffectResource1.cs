using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Effect.Particle;


//public class ParticleList
//{
//    public int frame;
//    public Vector3 pos;
//    public int type;
//    public int nowframe;

//    public Vector3 addvector;
//    public Vector3 addsize;
//    public Color addcolor;
//}


public class World3EffectResource1 : MonoBehaviour
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
                i--;
                }
                else
                {
                    list.nowframe++;
                }
            }
    }

    public void SetParticle(int type,Vector3 pos,int frame,Vector3 vector,Vector3 scaling,Color color)
    {
        ParticleList particle = new ParticleList();
        particle.type= type;
        particle.pos = pos;
        particle.frame = frame;
        particle.nowframe = 0;

        particle.addvector = vector;
        particle.addsize = scaling;
        particle.addcolor = color;

        EffectLists.Add(particle);
    }

    void InstanceParticle(ParticleList particle)
    {
        GameObject obj = (GameObject)Resources.Load("World3Cursor1Particle");

        obj.GetComponent<World3CursorParticle1>().SetType(particle.type, particle.addvector, particle.addsize, particle.addcolor);

        Instantiate(obj, new Vector3(particle.pos.x, particle.pos.y, particle.pos.z), Quaternion.identity);
    }
}
