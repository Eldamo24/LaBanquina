using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarineWolfController : MonoBehaviour
{
    public float speed = 3f;
    public bool chasing = false;
    public float waitTime = 0;
    public float waitDuration = 5f;
    
    void Update()
    {
        if(Time.time > waitTime)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }
}
