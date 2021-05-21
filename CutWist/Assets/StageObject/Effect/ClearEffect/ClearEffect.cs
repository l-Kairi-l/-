using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearEffect : MonoBehaviour
{
    //clearの絵
    //  public GameObject ClearTexture;
    //横になっている牛のオブジェクト
    //  public GameObject sheep;

    public GameObject Camera;

    [SerializeField]
    private GameObject gameclear;
    bool flag;
    // Start is called before the first frame update

    Vector3 AddPosition;
    private float frame;

    void Start()
    {
        flag = false;
        frame = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            Camera.transform.position += AddPosition;

            frame += 0.01f;

            if (frame >= 1.0f)
            {
                GameObject gov = Instantiate(gameclear, new Vector3(0, 0, 0), Quaternion.identity);
                flag = false;
            }
        }
    }

    public void Set(GameObject goal)
    {
        flag = true;



        AddPosition.x = (goal.transform.position.x - Camera.transform.position.x) * 0.01f;
        AddPosition.y = (goal.transform.position.y - Camera.transform.position.y) * 0.01f;
        AddPosition.z = 20 * 0.01f;
    }
}
