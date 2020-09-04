using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{

    [SerializeField] UpgradeItemsCollections[] upgradeItems;
    [SerializeField] GameObject upgradeBtn;
    [SerializeField] Transform UpgradeButtonParent;

    public void RemoveChild()
    {
        for (var i = 0; i < UpgradeButtonParent.transform.childCount; i++)
        {
            Destroy(UpgradeButtonParent.transform.GetChild(i).gameObject);
        }
    }

    public void upgradeItemsList()
    {
        foreach (UpgradeItemsCollections upgrade in upgradeItems)
        {

            // BUTTON SETUP

            GameObject upgradeButton = Instantiate(upgradeBtn, transform.position, Quaternion.identity);
            upgradeButton.transform.parent = UpgradeButtonParent;
            upgradeButton.GetComponent<RectTransform>().localScale = Vector3.one;
            upgradeButton.GetComponentInChildren<Image>().sprite = upgrade.pic;
            upgradeButton.GetComponentInChildren<Button>().transform.GetComponentInChildren<Text>().text = upgrade.itemName;


            // current power distributions                      // just add new item here only

            if (upgrade.itemName == "Health")
            {
                GameManager.instances.SetPlayerHealth(upgrade.GetPower());
            }

            if (upgrade.itemName == "Power Wave")
            {
                GameManager.instances.SetPlayerPowerWave(upgrade.GetPower());
            }

            if (upgrade.itemName == "Sword Charing")
            {
                GameManager.instances.SetSwordCharingTime(upgrade.GetPower());
            }

            if (upgrade.itemName == "Sword Stable")
            {
                GameManager.instances.SetSwordStableTime(upgrade.GetPower());
            }

            if (upgrade.itemName == "Sword Damage")
            {
                GameManager.instances.SetSwordDamage(upgrade.GetPower());
            }

            // CHECK IS ITEM MAXED

            if (upgrade.getAmount() == 1)
            {
                upgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX";
                upgradeButton.GetComponentInChildren<Button>().interactable = false;
            }
            else
            {
                upgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "$" + upgrade.getAmount().ToString();
                upgradeButton.GetComponentInChildren<UpgradeItemButton>().price = upgrade.getAmount();
                upgradeButton.GetComponentInChildren<UpgradeItemButton>().itemName = upgrade.itemName;
                upgradeButton.GetComponentInChildren<UpgradeItemButton>().purchase = upgrade.GetPurchase();
            }
        }
    }
}

