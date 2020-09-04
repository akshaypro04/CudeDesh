using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeItemButton : MonoBehaviour
{

    public int price;
    public string itemName;
    public int purchase;

    public void showSelected()
    {
        GameManager.instances.SetSelectedItem(price, itemName, purchase);       // it save tempeory data of selected item
    }

}
