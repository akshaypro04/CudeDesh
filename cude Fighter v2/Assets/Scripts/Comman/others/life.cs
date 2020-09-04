using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{

    [SerializeField] GameObject lifeEffect;
    float damaged;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            damaged = col.gameObject.GetComponent<Destruable>().DamageTaken;
            if(damaged > 100)
            {
                col.gameObject.GetComponent<Destruable>().DamageTake(-100);
            }
            else
            {
                col.gameObject.GetComponent<Destruable>().DamageTake(-1*(int)(damaged / 2));
            }

            GameManager.instances.PlaySfx("life");
            Instantiate(lifeEffect, transform.position, Quaternion.identity);
            destory();
        }
    }

    public void destory()
    {
        Destroy(gameObject);
    }
}
