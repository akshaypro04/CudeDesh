using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : Destruable
{
    [SerializeField] GameObject deadParticel;
    [SerializeField] int enemyDamagePoint;
    [SerializeField] EnemyType enemyName;
    [SerializeField] Slider HealthSlider;
    int reward;

    void Start()
    {
        HealthSlider = HealthSlider.GetComponent<Slider>();
        HealthSlider.minValue = 0;

        if (enemyName == EnemyType.big)
        {
            HitPoint = 120;
            HealthSlider.maxValue = HitPoint;
            HealthSlider.value = HitPoint;
            reward = 3;
        }

        if (enemyName == EnemyType.normal)
        {
            HitPoint = 60;
            HealthSlider.maxValue = HitPoint;
            HealthSlider.value = HitPoint;
            reward = 2;
        }

        if (enemyName == EnemyType.small)
        {
            HitPoint = 40;
            HealthSlider.maxValue = HitPoint;
            HealthSlider.value = HealthReaming;
            reward = 1;
        }
    }


    public override void DamageTake(int amount)
    {
        base.DamageTake(amount);
        HealthSlider.value = HealthReaming;
    }

    public override void die()
    {
        if (GameManager.instances.getPlayerAlive())
        {
            GameManager.instances.SetCoinsTemp(GameManager.instances.GetCoinsTemp() + reward);
            GameManager.instances.SetEnemyDamage(enemyDamagePoint);
            GameManager.instances.SetEnemykill(GameManager.instances.GetEnemykill() + 1);
            GameObject.Find("GameUIManager").GetComponent<GameUIManager>().UpdateLiveScore();
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>().ReSpawnEnemies();
        }

        Instantiate(deadParticel, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

}
