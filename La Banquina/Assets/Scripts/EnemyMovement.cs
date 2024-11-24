using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public Transform[] waypoints; 
    private int currentWaypointIndex = 0;
    public SpriteRenderer spriteRenderer;
    public Animator anim;

    private float minPauseTime = 1f; 
    private float maxPauseTime = 3f; 

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position; 
            StartCoroutine(MoveThroughWaypoints());
        }
    }

    IEnumerator MoveThroughWaypoints()
    {
        while (currentWaypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
            if(Random.Range(1,101) > 50)
            {
                float pauseTime = Random.Range(minPauseTime, maxPauseTime);
                yield return StartCoroutine(gameObject.GetComponent<EnemyAttack>().PerformRandomAction(pauseTime));
            }
            else
            {
                yield return null;
            }

            currentWaypointIndex++;
        }
        Destroy(gameObject);
        GameManager.instance.destroyedTourists++;
        GameManager.instance.CheckWin();
    }

    
}
