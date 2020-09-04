using UnityEngine;
using System;

public class Destruable : MonoBehaviour
{   
    protected float HitPoint;
    [HideInInspector]
    public float DamageTaken;

    public float HealthReaming
    {
        get
        {
            return HitPoint - DamageTaken;
        }
    }

    public bool IsAlive
    {
        get
        {
            return HealthReaming > 0;
        }
    }

    public virtual void DamageTake(int amount)
    {

        DamageTaken += amount;
        GameManager.instances.PlaySfx("damage");
        if (HealthReaming <= 0)
            die();
    }

    public virtual void die()
    {

    }

    public void Reset()
    {
        DamageTaken = 0;
    }
}
