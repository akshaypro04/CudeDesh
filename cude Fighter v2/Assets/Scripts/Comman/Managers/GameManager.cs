using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instances { get; private set; }
    Transform playerPos;
    int level;
    int ActivateLevel;
    int enemyDamage;
    bool playerIsAlive = false;
    int target;
    bool gameWasPaused;
    bool  pp;
    bool MainMenu;
    bool levelSelector;
    int coins;
    int itemPrice;
    string itemName;
    int itemPurchase;
    int KillEnemies;


    int SwordStabletime;
    int SwordChargingtime;
    int WavePower;
    int playerHealth;
    int SwordDamage;

    void Awake()
    {
        if(instances == null)
        {
            instances = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        playerPos = transform;
    }

    PlayerInput m_playerInput;
    public PlayerInput playerInput
    {
        get
        {
            if (m_playerInput == null)
                m_playerInput = gameObject.GetComponent<PlayerInput>();
            return m_playerInput;
        }
    }

    AudioManager m_audioManager;
    public AudioManager audioManager
    {
        get
        {
            if (m_audioManager == null)
                m_audioManager = gameObject.GetComponent<AudioManager>();
            return m_audioManager;
        }
    }


    Destruable m_destruable;
    public Destruable destruable
    {
        get
        {
            if (m_destruable == null)
                m_destruable = gameObject.GetComponent<Destruable>();
            return m_destruable;
        }
    }

    LevelScoreManager m_LevelScoreManager;
    public LevelScoreManager levelScoreManager
    {
        get
        {
            if (m_LevelScoreManager == null)
                m_LevelScoreManager = gameObject.GetComponent<LevelScoreManager>();
            return m_LevelScoreManager;
        }
    }

    LevelInstantiate m_levelInstantiate;
    public LevelInstantiate levelInstantiate
    {
        get
        {
            if (m_levelInstantiate == null)
                m_levelInstantiate = gameObject.GetComponent<LevelInstantiate>();
            return m_levelInstantiate;
        }
    }

    public int GetLevelCount()
    {
        return levelInstantiate.LevelCount();
    }

    public void InstantiateLevel()
    {
        levelInstantiate.InstantiateLevel();
    }


    public bool getPlayerAlive()
    {
        return playerIsAlive;
    }

    public void SetPlayerAlive(bool dead)
    {
        this.playerIsAlive = dead;
    }

    public Transform getPlayerPos()
    {
        return playerPos;
    }

    public void SetPlayerPos(Transform Pos)
    {
        this.playerPos = Pos;
    }

    public void PlaySfx(string name)
    {
        audioManager.PlaySfx(name);
    }

    public void PlayMusic(string name)
    {
        audioManager.PlayMusic(name);
    }

    public int getLevel()
    {
        return level;
    }

    public void Setlevel(int level)
    {
        this.level = level;
    }

    public int getActivateLevel()
    {
        return ActivateLevel;
    }

    public void SetActivateLevel(int ActivateLel)
    {
        this.ActivateLevel = ActivateLel;
    }

    public void SetEnemyTotalDamage(int i)
    {
        PlayerPrefs.SetInt("EnemyTotalDamage", i);
    }

    public int GetEnemyTotalDamage()
    {
        return PlayerPrefs.GetInt("EnemyTotalDamage", 0);
    }
    public void SetWiningTarget(int j)
    {
        target = j;
    }

    public int GetWiningTarget()
    {
        return target;
    }

    public void SetEnemyDamage(int i)
    {
        enemyDamage += i;
    }

    public void ResetEnemyDamage()
    {
        enemyDamage = 0;
    }

    public int GetEnemyDamage()
    {
        return enemyDamage;
    }


    public void SetSfxVol(float i)
    {
        PlayerPrefs.SetFloat("sfxVols", i);
    }

    public float getSfxVol()
    {
        return PlayerPrefs.GetFloat("sfxVols", 0.001f);
    }

    public void SetMusicVol(float i)
    {
        PlayerPrefs.SetFloat("musicVols", i);
    }

    public float getMusicVol()
    {
        return PlayerPrefs.GetFloat("musicVols", 0.001f);
    }

    public void SetGamePaused(bool i)
    {
        gameWasPaused = i;
    }

    public bool getGamePaused()
    {
        return gameWasPaused;
    }

    public void SetPPStatus(bool status)
    {
        pp = status;
    }

    public bool GetPPStatus()
    {
        return pp;
    }
    public void SetMainMenuPanel(bool status)
    {
        MainMenu = status;
    }

    public bool GetMainMenuPanel()
    {
        return MainMenu;
    }

    public void SetLevelSelectorPanel(bool status)
    {
        levelSelector = status;
    }

    public bool GetLevelSelectorPanel()
    {
        return levelSelector;
    }

    public void SetLifeBonus(float bonus)
    {
        PlayerPrefs.SetFloat("lifebonus", bonus);
    }

    public float GetLifeBonus()
    {
        return PlayerPrefs.GetFloat("lifebonus", 0);
    }

    public void SetLifeBonusLimit(float limit)
    {
        PlayerPrefs.SetFloat("lifebonusLimit", limit);
    }

    public float GetLifeBonusLimit()
    {
        return PlayerPrefs.GetFloat("lifebonusLimit", 1);
    }

    public void SetCoins(int coin)
    {
        PlayerPrefs.SetInt("coin", coin);
    }

    public int GetCoins()
    {
        return PlayerPrefs.GetInt("coin", 00);
    }

    public void SetCoinsTemp(int coin)
    {
        coins = coin;
    }

    public int GetCoinsTemp()
    {
        return coins;
    }

    public void SetEnemykill(int kill)
    {
        KillEnemies = kill;
    }

    public int GetEnemykill()
    {
        return KillEnemies;
    }

    ///////////////      U P G R A D E      ///////////////

    public void SetSelectedItem(int price, string Name, int purchase)
    {
        itemPrice = price;
        itemName = Name;
        itemPurchase = purchase;
    }

    public int GetItemPrice()
    {
        return itemPrice;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public int GetItemPurchase()
    {
        return itemPurchase;
    }

    ///////////////      U P G R A D E      ///////////////


    ///////////////      U P G R A D E    I T E M S      ///////////////

    public void SetPlayerPowerWave(int power)
    {
        WavePower = power;
    }

    public int GetPlayerPowerWave()
    {
        return WavePower;
    }

    public void SetSwordCharingTime(int time)
    {
        SwordChargingtime = time;
    }

    public int GetSwordCharingTime()
    {
        return SwordChargingtime;
    }

    public void SetSwordStableTime(int stable)
    {
        SwordStabletime = stable;
    }

    public int GetSwordStableTime()
    {
        return SwordStabletime;
    }

    public void SetPlayerHealth(int health)
    {
        playerHealth = health;
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public void SetSwordDamage(int damage)
    {
        SwordDamage = damage;
    }

    public int GetSwordDamage()
    {
        return SwordDamage;
    }

    ///////////////      U P G R A D E    I T E M S      ///////////////

}
