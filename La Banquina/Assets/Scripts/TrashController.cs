using System.Collections;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Sprite[] images;
    private SpriteRenderer spriteRenderer;
    private float duration = 1f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(gameObject.name != "Flash(Clone)")
            spriteRenderer.sprite = images[Random.Range(0, images.Length)];
    }

    private void Update()
    {
        transform.position += -transform.up * speed * Time.deltaTime;
        if(transform.position.x > 8.3f || transform.position.x < -8.3f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().anim.SetTrigger("Covering");
            Destroy(gameObject);
            
        }
        else if (collision.CompareTag("MarineWolf"))
        {
            if(speed > 0f)
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<MarineWolfController>().chasing = true;
                collision.gameObject.GetComponent<MarineWolfController>().target = GameObject.Find("WolfExit").GetComponent<Transform>();
            }
            else
            {
                if (collision.gameObject.GetComponent<MarineWolfController>().target.gameObject == this.gameObject)
                {
                    Destroy(gameObject);
                    collision.gameObject.GetComponent<MarineWolfController>().target = GameObject.Find("WolfExit").GetComponent<Transform>();
                }
            }
        }
        else if (collision.CompareTag("TrashZone"))
        {
            if(gameObject.name != "Flash(Clone)")
                StartCoroutine(SmoothTransition(speed, 0f, duration));
            else
            {
                Destroy(gameObject);
                GetMarineWolfs();
            }
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
        GetMarineWolfs();
    }

    private void GetMarineWolfs()
    {
        MarineWolfController[] marineWolfs = FindObjectsOfType<MarineWolfController>();
        if(marineWolfs != null)
        {
            foreach (MarineWolfController marineWolf in marineWolfs)
            {
                if (marineWolf.chasing == false)
                {
                    marineWolf.chasing = true;
                    if(gameObject.name != "Flash(Clone)")
                        marineWolf.target = gameObject.transform;
                    else
                    {
                        marineWolf.target = GameObject.Find("WolfExit").GetComponent<Transform>();
                    }
                    break;
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

}
