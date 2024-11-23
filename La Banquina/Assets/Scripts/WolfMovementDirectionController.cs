using UnityEditor;
using UnityEngine;

public class WolfMovementDirectionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MarineWolf"))
        {
            MarineWolfController marineWolf = collision.gameObject.GetComponent<MarineWolfController>();
            marineWolf.waitTime = Time.time + marineWolf.waitDuration;
            if (gameObject.name == "WolfMovementTurnRight" || gameObject.name == "WolfMovementTurnLeft")
            {
                marineWolf.speed = marineWolf.speed * -1;
            }
        }
    }
}
