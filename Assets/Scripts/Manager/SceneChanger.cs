using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Main,
    Village,
    Map
}

public static class SceneChanger
{
    public static void SceneLoad(SceneType sceneType)
    {
        SceneManager.LoadScene((int)sceneType);
    }
}
