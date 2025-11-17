using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem 
{
    private static SaveData _saveData = new SaveData();

    [System.Serializable]
    public struct SaveData
    {
        public BestScoreSaveData BestScoreData;
        public AudioSettingSaveData AudioSettingsData;
    }

    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/save" + ".save";
        Debug.Log(saveFile);
        return saveFile;
    }

    public static void Save()
    {
        HandelSaveData();

        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));
    }

    public static void HandelSaveData()
    {
        if (ScoreManager.instance != null)
            ScoreManager.instance.Save(ref _saveData.BestScoreData);

        if (SoundSettings.instance != null)
            SoundSettings.instance.Save(ref _saveData.AudioSettingsData);

    }

    public static void Load()
    {
        string saveData = File.ReadAllText(SaveFileName());

        _saveData = JsonUtility.FromJson<SaveData>(saveData);
        HandelLoadData();
    }

    public static void HandelLoadData()
    {
        if(ScoreManager.instance != null)
            ScoreManager.instance.Load(_saveData.BestScoreData);

        if (SoundSettings.instance != null)
            SoundSettings.instance.Load(_saveData.AudioSettingsData);
    }
    public static BestScoreSaveData GetBestScore()
    {
        Debug.Log("File" + SaveFileName());
        if (!File.Exists(SaveFileName()))
            return new BestScoreSaveData(); // default 0

        string json = File.ReadAllText(SaveFileName());
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        return data.BestScoreData;
    }
}
