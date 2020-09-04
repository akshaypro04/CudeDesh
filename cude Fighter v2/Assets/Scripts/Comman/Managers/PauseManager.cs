using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameUIManager gameUI;

    public void Pause()
    {
        Time.timeScale = 0f;
        GameManager.instances.SetGamePaused(true);
    }

    public void resume()
    {
        Time.timeScale = 1f;
        GameManager.instances.SetGamePaused(false);
        gameUI.GetComponent<GameUIManager>().ActivatePanel("Controller panel"); 
    }

    public void levelSelector()
    {
        Time.timeScale = 1f;
        GameManager.instances.SetGamePaused(false);
        GameManager.instances.SetLevelSelectorPanel(true);
        GameManager.instances.SetMainMenuPanel(false);
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameManager.instances.SetGamePaused(false);
        GameManager.instances.SetLevelSelectorPanel(false);
        GameManager.instances.SetMainMenuPanel(true);
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
