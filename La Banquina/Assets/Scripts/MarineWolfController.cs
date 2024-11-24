using UnityEngine;

public class MarineWolfController : MonoBehaviour
{
    public float speed = 3f;
    public bool chasing = false;
    public float waitTime = 0;
    public float waitDuration = 5f;
    public Transform target;
    public SpriteRenderer spriteRenderer;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
    }

    void Update()
    {
        if(Time.time > waitTime && !chasing)
        {
            anim.SetBool("Idle", false);
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (chasing)
        {
            if (target.name == "WolfExit")
            {
                anim.SetTrigger("Hitted");
            }
            else if(target.name == "Trash(Clone)")
            {
                anim.SetBool("Idle", false);
            }
            if (speed < 0) speed = speed * -1;
            if (target != null) 
            {
                if(target.position.x < transform.position.x)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            
        }
    }
}
