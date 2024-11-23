using UnityEngine;

public class MarineWolfController : MonoBehaviour
{
    public float speed = 3f;
    public bool chasing = false;
    public float waitTime = 0;
    public float waitDuration = 5f;
    public Transform target;
    
    void Update()
    {
        if(Time.time > waitTime && !chasing)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (chasing)
        {
            if (speed < 0) speed = speed * -1;
            if (target != null) 
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }
}
