using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using PlayData;

public class SaveDataManager : MonoBehaviour
{
    public List<string> filepath = new List<string>();
    public List<SaveData> save = new List<SaveData>();
  //  C:/Users/ユーザー名/AppData/LocalLow/[DefaultCampany] (CampanyName)/[プロジェクト名] (ProductName)/
    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            filepath.Add(Application.persistentDataPath + "/" + ".savedata" + i + ".json");

            save.Add(new SaveData());
            save[i].Init(i+1);

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

        string json = JsonUtility.ToJson(save[i]);

        StreamWriter streamWriter = new StreamWriter(filepath[i]);
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();


        //        string json = JsonUtility.ToJson(save[i]);
        //#if UNITY_EDITOR
        //        string path = Directory.GetCurrentDirectory();
        //#else
        //        string path = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
        //#endif
        //        path += ("/" + SAVE_FILE_PATH);
        //        StreamWriter writer = new StreamWriter(path, false);
        //        writer.WriteLine(json);
        //        writer.Flush();
        //        writer.Close();
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


            //#if UNITY_EDITOR
            //            string path = Directory.GetCurrentDirectory();
            //#else
            //        string path = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
            //#endif
            //            FileInfo info = new FileInfo(path + "/" + SAVE_FILE_PATH);
            //            StreamReader reader = new StreamReader(info.OpenRead());
            //            string json = reader.ReadToEnd();
            //            save[i] = JsonUtility.FromJson<SaveData>(json);
            //  return true;

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


