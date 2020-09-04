using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]float speed = 50;
    [SerializeField] GameObject damageEffectParticale;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            Destroy(gameObject);
            damageEffect();
        }

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Destruable>().DamageTake(8);
            damageEffect();
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Destruable>().DamageTake(10);
            damageEffect();
            Destroy(gameObject);
        }
    }

    void damageEffect()
    {
        Instantiate(damageEffectParticale, transform.position, Quaternion.identity);
    }
}
