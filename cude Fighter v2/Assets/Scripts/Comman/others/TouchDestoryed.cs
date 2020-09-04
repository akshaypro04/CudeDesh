using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TouchDestoryed : MonoBehaviour
{
    [SerializeField] PlatformType platform;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(platform == PlatformType.lava)
        {
            if (col.gameObject.GetComponent<Destruable>() != null)
            {
                col.gameObject.GetComponent<Destruable>().DamageTake(100);
            }
        }

        if (platform == PlatformType.deadEnd)
        {
            if (col.gameObject.GetComponent<Destruable>() != null)
            {
                col.gameObject.GetComponent<Destruable>().DamageTake(1000);
            }
        }


        if (col.gameObject.GetComponent<platformMovement>() != null)
        {
            col.gameObject.GetComponent<platformMovement>().destory();
        }
    }



}
