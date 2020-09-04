using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    
    public TextMeshProUGUI LiveScore;
    public TextMeshProUGUI TagretScore;
    public TextMeshProUGUI HealthValue;
    public TextMeshProUGUI DeadNumKillEnemies;
    public TextMeshProUGUI DeadNumCoinGet;
    public TextMeshProUGUI WinNumKillEnemies;
    public TextMeshProUGUI WinNumCoinGet;
    bool PlayerWin;

    [SerializeField] GameObject CompleteLevel;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject ControllerPanel;
    [SerializeField] GameObject DeadScreen;
    [SerializeField] GameObject volumePanel;
    [SerializeField] GameObject PostProcessing;

    int activateLevel;
    int targetDamage;
    void Start()
    {
        SetPP();
        GameManager.instances.SetPlayerAlive(true);
        GameManager.instances.SetCoinsTemp(0);
        GameManager.instances.SetEnemykill(0);
        GameManager.instances.ResetEnemyDamage();
        GameManager.instances.InstantiateLevel();

        HealthValue.text = GameManager.instances.GetPlayerHealth().ToString();
        LiveScore.text = "00";
        activateLevel = GameManager.instances.getActivateLevel();
        targetDamage = GameManager.instances.GetWiningTarget();
        print("activate level : " + activateLevel);
        ActivatePanel(ControllerPanel.name);
        TagretScore.text = "Target Score : "+ GameManager.instances.GetWiningTarget().ToString();
    }

    void Update()
    {
        if (GameManager.instances.getPlayerAlive())
        {
            if(targetDamage < GameManager.instances.GetEnemyDamage())
            {
                if (GameManager.instances.GetEnemyDamage() + 1 > GameManager.instances.GetEnemyTotalDamage())
                {
                    print("new damage data saved");
                    GameManager.instances.SetEnemyTotalDamage(targetDamage + 1);
                }

                PlayerWin = true;
                ActivatePanel(CompleteLevel.name);

                int getRewardedCoins = GameManager.instances.GetCoinsTemp();
                int SavedCoins = GameManager.instances.GetCoins();
                GameManager.instances.SetCoins(getRewardedCoins + SavedCoins);

                WinNumCoinGet.text = "You Earn " + getRewardedCoins + " Coins , So Total Value is now " + GameManager.instances.GetCoins();
                WinNumKillEnemies.text = "You killed " + GameManager.instances.GetEnemykill() + " Enemies";

                print("You killed " + GameManager.instances.GetEnemykill() + " Enemies. and " + GameManager.instances.GetCoinsTemp());

                GameManager.instances.SetCoinsTemp(0);
                GameManager.instances.SetEnemykill(0);

                GameManager.instances.SetPlayerAlive(false);
                GameManager.instances.ResetEnemyDamage();
            }
        }
        else if(GameManager.instances.getPlayerAlive() == false && PlayerWin == false)
        {

            int getRewardedCoins = GameManager.instances.GetCoinsTemp();
            int SavedCoins = GameManager.instances.GetCoins();
            GameManager.instances.SetCoins(getRewardedCoins + SavedCoins);

            ActivatePanel(DeadScreen.name);

            DeadNumCoinGet.text = "You Earn " + getRewardedCoins + " Coins , So Total Value is now " + GameManager.instances.GetCoins();
            DeadNumKillEnemies.text = "You killed " + GameManager.instances.GetEnemykill() + " Enemies";

            print("You killed " + GameManager.instances.GetEnemykill() + " Enemies. and " + GameManager.instances.GetCoinsTemp());

            GameManager.instances.SetCoinsTemp(0);
            GameManager.instances.SetEnemykill(0);
            GameManager.instances.ResetEnemyDamage();
            PlayerWin = true;
        }
    }



    public void UpdateLiveScore()
    {
        LiveScore.text = GameManager.instances.GetEnemyDamage().ToString();
        HealthValue.text = GameManager.instances.GetPlayerHealth().ToString();
    }

    public void PauseGame()
    {
        ActivatePanel(pauseMenu.name);
        pauseMenu.GetComponent<PauseManager>().Pause();
        GameManager.instances.SetGamePaused(true);
    }

    public void Setting()
    {
        ActivatePanel(volumePanel.name);
    }
    public void Back()
    {
        ActivatePanel(pauseMenu.name);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetPostProcess(bool pp)                         // pp button
    {
        PostProcessing.SetActive(pp);
        GameManager.instances.SetPPStatus(pp);
    }

    void SetPP()
    {
        PostProcessing.SetActive(GameManager.instances.GetPPStatus());
    }

    public void ActivatePanel(string name)
    {
        CompleteLevel.SetActive(CompleteLevel.name.Equals(name));
        pauseMenu.SetActive(pauseMenu.name.Equals(name));
        ControllerPanel.SetActive(ControllerPanel.name.Equals(name));
        DeadScreen.SetActive(DeadScreen.name.Equals(name));
        volumePanel.SetActive(volumePanel.name.Equals(name));
    }
}
