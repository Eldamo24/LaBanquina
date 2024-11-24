using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject food;
    public IEnumerator PerformRandomAction(float pauseDuration)
    {
        gameObject.GetComponent<EnemyMovement>().anim.SetBool("Idle", true);
        yield return new WaitForSeconds(2f);
        Instantiate(food, transform.position, Quaternion.identity);
        gameObject.GetComponent<EnemyMovement>().anim.SetBool("Idle", false);
        yield return new WaitForSeconds(pauseDuration);
    }
}
