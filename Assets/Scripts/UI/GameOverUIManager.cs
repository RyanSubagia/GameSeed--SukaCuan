using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu";

    public void NextLevelButton()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Ini adalah level terakhir!");
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }



    public void MainMenuButton()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}