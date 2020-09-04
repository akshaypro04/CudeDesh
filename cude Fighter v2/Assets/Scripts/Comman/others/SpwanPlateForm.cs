using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanPlateForm : MonoBehaviour
{
    [SerializeField] GameObject platform;
    float timeLeft;
    float timeLimit;

    void Start()
    {
        timeLimit = Random.Range(1, 3);
    }

    void Update()
    {
        timeLeft += Time.deltaTime;
        
        if(timeLimit < timeLeft)
        {
            Instantiate(platform, transform.position, Quaternion.identity);
            timeLeft = 0;
        }
    }
}
