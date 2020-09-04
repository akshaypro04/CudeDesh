using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePlatform : MonoBehaviour
{
    public float amplifie = 0.1f / 3;
    float pos;
    public float speed = 2f; 

    void Update()
    {
        if (GameManager.instances.getGamePaused())
            return;
        ShakePlayer(speed);
    }

    void ShakePlayer(float frequency)
    {
        pos = transform.position.y + Mathf.Sin(Time.time * frequency) * amplifie;
        transform.position = new Vector3(transform.position.x, pos, transform.position.z);
    }
}
