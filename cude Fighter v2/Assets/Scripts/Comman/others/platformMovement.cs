using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{

    float speed;

    void Start()
    {
        speed = Random.Range(5, 10);
        Destroy(gameObject, 15);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }

    public void destory()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            col.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            col.transform.parent = null;
        }
    }

}
