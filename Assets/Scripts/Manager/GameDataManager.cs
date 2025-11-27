using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerGold = 100;
    public int maxHP = 100;
    public int maxMP = 100;
    public int maxStamina = 100;
    public int PlayerDamage = 20;
}

public static class GameDataManager
{
    //윈도우 저장 파일 경로 이름
    private static string savePath = Application.persistentDataPath + "/savedata.json";

    public static void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
    }

    public static GameData Load()
    {
        if (!File.Exists(savePath))
        {
            return new GameData();
        }

        string json = File.ReadAllText(savePath);
        return JsonUtility.FromJson<GameData>(json);
    }
}
