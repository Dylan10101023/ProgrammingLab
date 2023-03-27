using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    private string saveFileName = "savedata.dat";

    //Key for encryption or decryption
    private byte[] encryptionKey = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF };

    public void SaveGame(GameData gameData)
    {
        string json = JsonUtility.ToJson(gameData);
        byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(json);

        // Encrypt the data
        for (int i = 0; i < dataBytes.Length; i++)
        {
            dataBytes[i] ^= encryptionKey[i % encryptionKey.Length];
        }

        string encryptedData = System.Convert.ToBase64String(dataBytes);
        File.WriteAllText(GetSaveFilePath(), encryptedData);
    }

    public GameData LoadGame()
    {
        string filePath = GetSaveFilePath();
        if (File.Exists(filePath))
        {
            string encryptedData = File.ReadAllText(filePath);
            byte[] dataBytes = System.Convert.FromBase64String(encryptedData);

            // Decrypt the data
            for (int i = 0; i < dataBytes.Length; i++)
            {
                dataBytes[i] ^= encryptionKey[i % encryptionKey.Length];
            }

            string json = System.Text.Encoding.UTF8.GetString(dataBytes);
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