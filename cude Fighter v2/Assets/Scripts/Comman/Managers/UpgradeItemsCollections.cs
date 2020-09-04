using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

[CreateAssetMenu( menuName ="Add Upgrate Item", fileName = "Item")]
public class UpgradeItemsCollections : ScriptableObject
{
    public string itemName;
    public int[] UpgrateAmount;
    public int[] PowerLevel;
    public Sprite pic;


                                 ////////////////    P U R C H A S E      ////////////////

    public void SetPurchase(int purchase)
    {
        PlayerPrefs.SetInt(itemName, purchase);
    }

    public int GetPurchase()
    {
        return PlayerPrefs.GetInt(itemName, 0);
    }


    public int getAmount()
    {
        int PurchaseLevel = GetPurchase();
        return UpgrateAmount[PurchaseLevel];
    }

               

    public int GetPower()
    {
        int PurchaseLevel = GetPurchase();
        return PowerLevel[PurchaseLevel];
    }

}
