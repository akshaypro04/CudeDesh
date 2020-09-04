using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendLevelNameUiManager : MonoBehaviour
{

    public void SendLevelName2UIManager()
    {
        print(transform.GetComponentInParent<Button>().name);

        GameObject.Find("Canvas/UIManager").GetComponent<UIManager>().SelectedLevel(int.Parse(transform.GetComponentInParent<Button>().name));
    }

}
