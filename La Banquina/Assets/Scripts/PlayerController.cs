using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player references")]
    private Rigidbody2D rb;

    [Header("Movement variables")]
    private float horizontalInput;
    [SerializeField] private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = transform.right * horizontalInput * speed * Time.deltaTime;
        movement = rb.position + movement;
        movement.x = Mathf.Clamp(movement.x, -8.3f, 8.3f);
        rb.MovePosition(movement);
    }
}
