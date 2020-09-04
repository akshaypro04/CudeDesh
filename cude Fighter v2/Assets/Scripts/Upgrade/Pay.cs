using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pay : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI paymentStatus;
    [SerializeField] Text ShowCoins;

    void Start()
    {
        ShowTotalCoins();
    }

    public void ShowTotalCoins()
    {
        ShowCoins.text = "$ " + GameManager.instances.GetCoins().ToString();
    }


    public void payment()
    {
        if(GameManager.instances.GetItemPrice() == 0)
        {
            paymentStatus.text = "Select any Item to Purchase";
            return;
        }


        if (GameManager.instances.GetItemPrice() <= GameManager.instances.GetCoins())
        {
            GameManager.instances.SetCoins(GameManager.instances.GetCoins() - GameManager.instances.GetItemPrice());
            PlayerPrefs.SetInt(GameManager.instances.GetItemName(), GameManager.instances.GetItemPurchase() + 1);
            paymentStatus.text = "Item Purchase Successfully";
            GameObject.Find("Canvas/UpgratePanel").GetComponent<UpgradeManager>().RemoveChild();
            GameObject.Find("Canvas/UpgratePanel").GetComponent<UpgradeManager>().upgradeItemsList();
            GameManager.instances.SetSelectedItem(0, null, 0);
            ShowTotalCoins();
        }
        else
        {
            paymentStatus.text = "Not enough Monry";
        }
    }
}
