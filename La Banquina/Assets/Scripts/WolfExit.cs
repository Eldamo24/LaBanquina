using UnityEngine;

public class WolfExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MarineWolf"))
        {
            GameManager.instance.SubstractMarineWolf();
            Destroy(collision.gameObject);
        }
    }
}
