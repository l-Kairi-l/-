using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;

namespace PlayData
{
    [System.Serializable]
    public class SaveData
    {
        public bool active;
        public int WorldNumber;
        public int[] ClearStar = new int[9];

        public void Init(int world)
        {
           // ClearStar = new int[9];
            //ステージのクリアデータの初期化
            for (int i = 0; i < 9; i++)
            {
                ClearStar[i]=3;
            }
            //ワールド番号の設定
            WorldNumber = world;

            active = (world == 0) ? true : false;
        }

    }
}



