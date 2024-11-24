using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject food;
    public IEnumerator PerformRandomAction(float pauseDuration)
    {
        gameObject.GetComponent<EnemyMovement>().anim.SetBool("Idle", true);
        yield return new WaitForSeconds(2f);
        Instanciar();
        yield return new WaitForSeconds(pauseDuration);
        gameObject.GetComponent<EnemyMovement>().anim.SetBool("Idle", false);
        StopCoroutine("PerformRandomAction");
    }

    private void Instanciar()
    {
        Instantiate(food, transform.position, Quaternion.identity);
    }
}
