using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MarineWolf"))
        {
            Destroy(collision.gameObject);
        }
    }
}
