using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject LevelManager;
    [SerializeField] GameObject volumeController;
    [SerializeField] GameObject MainSetting;
    [SerializeField] GameObject UpgradePanel;
    [SerializeField] GameObject postProcessing;
    [SerializeField] Text Coin;

    void Start()
    {
        SetPP();
        Coin.text = "$ " + GameManager.instances.GetCoins().ToString();
        UpgradePanel.GetComponent<UpgradeManager>().upgradeItemsList();
        GameManager.instances.levelScoreManager.SelectPlayerLevel();                // unlocks level 
        GameManager.instances.SetPlayerAlive(false);
        GameManager.instances.ResetEnemyDamage();
        GameManager.instances.SetCoinsTemp(0);

        LevelManager.GetComponent<LevelButtonManager>().InstantiateButton();        // Instantiate button

        if (GameManager.instances.GetMainMenuPanel())
        {
            ActivatePanel(MainMenu.name);
        }
        else if (GameManager.instances.GetLevelSelectorPanel())
        {
            ActivatePanel(LevelManager.name);
        }
        else
        {
            ActivatePanel(MainSetting.name);
        }
    }

    public void ActivateMainMenu()
    {
        ActivatePanel(MainMenu.name);
    }

    public void ActivateUpgradePanel()
    {
        ActivatePanel(UpgradePanel.name);
    }

    public void ActivateLevelManager()
    {
        ActivatePanel(LevelManager.name);
    }

    public void Setting()
    {
        ActivatePanel(volumeController.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    void ActivatePanel(string name)
    {
        MainMenu.SetActive(MainMenu.name.Equals(name));
        LevelManager.SetActive(LevelManager.name.Equals(name));
        volumeController.SetActive(volumeController.name.Equals(name));
        MainSetting.SetActive(MainSetting.name.Equals(name));
        UpgradePanel.SetActive(UpgradePanel.name.Equals(name));
        Coin.text = "$ " + GameManager.instances.GetCoins().ToString();
    }

    public void SelectedLevel(int levelname)                                   // SELECTEED LEVEL NUM IN LEVEL PANEL
    {
        GameManager.instances.SetActivateLevel(levelname);                 // give level data according to arry
        try
        {
            GameManager.instances.SetWiningTarget(GameManager.instances.levelScoreManager.Value[levelname + 1]);
        }
        catch
        {
            GameManager.instances.SetWiningTarget(1000);
        }
        SceneManager.LoadScene(1);
    }

    public void SetPostProcess(bool pp)                         // pp button
    {
        postProcessing.SetActive(pp);
        GameManager.instances.SetPPStatus(pp);
    }

    public void SetPP()
    {
        postProcessing.SetActive(GameManager.instances.GetPPStatus());
    }


    [ContextMenu("Reset Player Damages")]
    void Reset()
    {
        PlayerPrefs.SetInt("EnemyTotalDamage", 0);
        PlayerPrefs.SetInt(GameManager.instances.GetItemName(), 0);
        PlayerPrefs.SetInt("coin", 500);
    }
}
