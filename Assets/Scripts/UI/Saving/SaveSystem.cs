using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem 
{
    public static void SaveAllData(PlayerStats stats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveddata.ethan";
        FileStream stream = new FileStream(path, FileMode.Create);
        Save data = new Save(stats);

        formatter.Serialize(stream, data);
        stream.Close();
    }



    public static Save LoadAllData()
    {
        string path = Application.persistentDataPath + "/saveddata.ethan";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Save data = formatter.Deserialize(stream) as Save;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file does not exist");
            return null;
        }
    }
}
