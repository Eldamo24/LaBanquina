using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float duration = 1f;

    private void Update()
    {
        transform.position += -transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("MarineWolf"))
        {
            if(speed > 0f)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject); //Aqui iria lo que pase con el lobo
            }
        }
        else if (collision.CompareTag("TrashZone"))
        {
            StartCoroutine(SmoothTransition(speed, 0f, duration));
        }
    }

    IEnumerator SmoothTransition(float startValue, float endValue, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            speed = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        speed = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

}
