using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class bomb : MonoBehaviour
{
    public float fieldOfImpact = 2;
    public LayerMask layerToHit;
    public float force = 10f;
    [SerializeField] GameObject BombBlastEffect;

    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);

        foreach( Collider2D obj in objects)
        {
            Vector2 dir = obj.transform.position - transform.position;
            if(obj.GetComponent<Destruable>() != null)
            {
                obj.GetComponent<Rigidbody2D>().AddForce(dir * force);
                obj.GetComponent<Destruable>().DamageTake(40);
            }
        }
        GameManager.instances.PlaySfx("blast");
        CameraShaker.Instance.ShakeOnce(8f, 6f, 0.2f, 0.8f);
        Instantiate(BombBlastEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "bullet")
        {
            Explode();
        }
    }

}
