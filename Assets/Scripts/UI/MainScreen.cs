using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    public GameObject selectLevelPanel;
    public GameObject mainScreenPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SelectLevel()
    {
        if (selectLevelPanel != null) selectLevelPanel.SetActive(true);
        if (mainScreenPanel != null) mainScreenPanel.SetActive(false);
    }
    public void BackToMainScreen()
    {
        if (selectLevelPanel != null) selectLevelPanel.SetActive(false);
        if (mainScreenPanel != null) mainScreenPanel.SetActive(true);
    }
    public void SelectLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void SelectLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void SelectLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
}