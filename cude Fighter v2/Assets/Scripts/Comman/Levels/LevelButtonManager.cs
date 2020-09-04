using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour
{
    public Color newColor;
    [SerializeField] GameObject Buttons;
    [SerializeField] Transform ButtonsHolder;
    int playerLevel;

                            //   L E V L S     B U T T O N S      M A N A G E R
                                            // called from uimanager
        

    public void InstantiateButton()
    {
        for(int i = 0; i < GameManager.instances.GetLevelCount(); i++)
        {
            GameObject btn= Instantiate(Buttons, transform.position, Quaternion.identity);
            btn.transform.parent = ButtonsHolder.transform;
            btn.transform.localScale = Vector3.one;
            btn.name = i.ToString();
            btn.GetComponentInChildren<TextMeshProUGUI>().text = "Level " + (i + 1);      
        }

        EnableButtons();
    }




    public void EnableButtons()
    {
        print(" level count " + GameManager.instances.GetLevelCount());   

        playerLevel = GameManager.instances.getLevel();     
        print("number of levels unlocks " + playerLevel);

        for (int level = 0; level < GameManager.instances.GetLevelCount(); level++)
        {
            if (playerLevel == level)
            {
                ColorBlock cb = ButtonsHolder.GetChild(level).GetComponent<Button>().colors;
                cb.normalColor = newColor;
                ButtonsHolder.GetChild(level).GetComponent<Button>().colors = cb;
            }

            if (playerLevel < level)
            {
                ButtonsHolder.GetChild(level).GetComponent<Button>().interactable = false;
            }
        }
    }

}
