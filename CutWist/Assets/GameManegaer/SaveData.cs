using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO;

namespace PlayData
{
    [System.Serializable]
    public class SaveData
    {
        //そのワールドに到達したかどうか
        public bool active;
        public int WorldNumber;
        public int[] ClearStar = new int[9];

        public bool EX_Stage;
        public void Init(int world)
        {
            
            //ワールド番号の設定
            WorldNumber = world;

            active = (world == 0) ? true : false;

            EX_Stage = false;

            if (world == 3)
            {
                //ステージのクリアデータの初期化
                for (int i = 0; i < 9; i++) ClearStar[i] = 0;
            }
            else
            {
                //ステージのクリアデータの初期化
                for (int i = 0; i < 9; i++) ClearStar[i] = 3;
            }

        }

    }
}



