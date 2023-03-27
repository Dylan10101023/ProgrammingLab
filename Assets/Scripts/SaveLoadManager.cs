using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string saveFileName = "savedata.json";

    public void SaveGame(GameData gameData)
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(GetSaveFilePath(), json);
    }

    public GameData LoadGame()
    {
        string filePath = GetSaveFilePath();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            Debug.LogWarning("Save file not found!");
            return null;
        }
    }

    private string GetSaveFilePath()
    {
        return Path.Combine(Application.persistentDataPath, saveFileName);
    }
}
