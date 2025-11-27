using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerGold;
    public int maxHP;
    public int maxMP;
    public int maxStamina;
    public int PlayerDamage;
}

public static class GameDataManager
{
    private static string savePath = Application.persistentDataPath + "/save.json";

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
