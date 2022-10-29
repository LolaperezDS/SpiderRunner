using UnityEngine;
using System.IO;

public static class SaveManager
{
    private static string filepath = Application.persistentDataPath + "/saves/";
    // Start is called before the first frame update
    public static void Save(DataStruct data)
    {
        string jsonData = JsonUtility.ToJson(data, true);
        using (var writer = new StreamWriter(filepath + "save.json"))
        {
            writer.WriteLine(jsonData);
        }
    }

    public static DataStruct Load()
    {
        string loadedData = "";
        using (var reader = new StreamReader(filepath + "save.json"))
        {
            loadedData = reader.ReadToEnd();
        }
        if (string.IsNullOrEmpty(loadedData))
        {
            return Defaults();
        }
        return JsonUtility.FromJson<DataStruct>(loadedData);
    }

    public static DataStruct Defaults()
    {
        return new DataStruct();
    }
}


public static class FirstRunApp
{
    public static void SetUp()
    {
        string filepath = Application.persistentDataPath + "/saves/";
        if (!Directory.Exists(filepath))
        {
            DirectoryInfo savedir = Directory.CreateDirectory(filepath);
            FileStream tmp = File.Create(filepath + "save.json");
            tmp.Close();
            SaveManager.Save(SaveManager.Defaults());
        }
        return;
    }
}

