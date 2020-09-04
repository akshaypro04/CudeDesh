using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemysmall;
    [SerializeField] GameObject enemymedium;
    [SerializeField] GameObject enemybig;
    [SerializeField] GameObject bomb;
    [SerializeField] GameObject life;

    float randomEnemy;
    float ranXPos;
    float Enemytime;
    float timeBomb;
    float lifetime;
    float lifeSpwanTimeLimit;

    void Start()
    {
        lifeSpwanTimeLimit = 10;
        SpawnEnemies();
    }

    public void ReSpawnEnemies()            // called in every enemy dead
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        SpawnEnemy10Sec();
        SpawnBomb10Sec();
        life10Sec();
    }

    void SpawnEnemy10Sec()
    {
        Enemytime += Time.deltaTime;             // spawn enemies in every 10 sec       
        if (8 < Enemytime)
        {
            SpawnEnemies();
            Enemytime = 0;
        }
    }

    void SpawnBomb10Sec()
    {
        timeBomb += Time.deltaTime;             // spawn enemies in every 10 sec
        if (12 < timeBomb)
        {
            Instantiate(bomb, new Vector3(Random.Range(20, -20), 10, 0), Quaternion.identity);
            timeBomb = 0;
        }
    }

    void life10Sec()
    {
        lifetime += Time.deltaTime;             // spawn enemies in every 10 sec
        if (lifeSpwanTimeLimit < lifetime)
        {
            Instantiate(life, new Vector3(Random.Range(20, -20), 10, 0), Quaternion.identity);
            lifeSpwanTimeLimit = Random.Range(15, 20);
            lifetime = 0;
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);

        if ((Random.Range(0, 2) == 0))
        {
            SpawnEnemies();
        }
        
    }

    void SpawnEnemies()
    {
        randomEnemy = Random.Range(0, 3);

        switch (randomEnemy)
        {
            case 0:
                ranXPos = Random.Range(-20, 20);
                Instantiate(enemysmall, new Vector2(ranXPos, 10), Quaternion.identity);
                break;

            case 1:
                ranXPos = Random.Range(-20, 20);
                Instantiate(enemymedium, new Vector2(ranXPos, 10), Quaternion.identity);
                break;

            case 2:
                ranXPos = Random.Range(-20, 20);
                Instantiate(enemybig, new Vector2(ranXPos, 10), Quaternion.identity);
                break;
        }
    }
}
