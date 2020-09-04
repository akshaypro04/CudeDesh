using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInstantiate : MonoBehaviour
{
    public GameObject[] LevelsPrefabs;
    float ActivateLevel;
    GameObject LevelInstantiatedHolder;


                    //  L E V E L    I N S T A N T I A T E    M A N A G E R             
                                                                                         // this called from GameUIManager 

    public void InstantiateLevel()
    {
        ActivateLevel = GameManager.instances.getActivateLevel();
        for(int i = 0; i < LevelsPrefabs.Length; i++)
        {
            if(ActivateLevel == i)
            {
                LevelsPrefabs[i].SetActive(true);
                GameObject level = Instantiate(LevelsPrefabs[i], transform.position, Quaternion.identity);
                LevelInstantiatedHolder = new GameObject("LevelInstantiatedHolder");
                level.transform.parent = LevelInstantiatedHolder.transform;
            }
        }
    }

    public int LevelCount()
    {
        return LevelsPrefabs.Length;
    }

}
