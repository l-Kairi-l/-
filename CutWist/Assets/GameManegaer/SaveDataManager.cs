using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using PlayData;

public class SaveDataManager : MonoBehaviour
{
    List<string> filepath = new List<string>();
    List<SaveData> save = new List<SaveData>();

    void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            filepath.Add(Application.persistentDataPath + "/" + ".savedata" + i + ".json");

            save.Add(new SaveData());
            save[i].Init(i);

            //セーブデータのロード
           if (Load(i))
            {
                Save(i);

            }
         //   Debug.Log(save[i].ClearStar.Count);
          //  Debug.Log(save[i].WorldNumber);
        }

    }

    public SaveData GetData(int i)
    {
        return save[i];
    }

    public void SetData(int i, SaveData data)
    {
        save[i]= data;
    }

    public void Save(int i)
    {

        string json = JsonUtility.ToJson(save);

        StreamWriter streamWriter = new StreamWriter(filepath[i]);
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }


    public bool Load(int i)
    {
        if (File.Exists(filepath[i]))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filepath[i]);
            string data = streamReader.ReadToEnd();
            streamReader.Close();

            save[i] = JsonUtility.FromJson<SaveData>(data);
            return true;
        }
        return false;
    }

    //public void InitData()
    //{
    //   // List<SaveData> save = new List<SaveData>();
    //    SaveData setdata=new SaveData();
    //    setdata.ClearStar = new List<int>();
    //    //ステージのクリアデータの初期化
    //    for (int i = 0; i < 9; i++)
    //    {
    //        setdata.ClearStar.Add(0);
    //    }

    //    //ワールド番号の設定
    //    for (int i = 0; i < 3; i++)
    //    {
    //        setdata.WorldNumber = i+1;
    //        save[i] = setdata;
    //    }

    //}
}


