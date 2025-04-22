using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float launchForce = 10f;
    private Rigidbody rb;
    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        LaunchBall(); // Lanza la pelota al inicio
    }

    public void LaunchBall()
    {
        // Aplica una fuerza diagonal hacia arriba
        Vector3 direction = new Vector3(Random.Range(-0.5f, 0.5f), 1f, 0).normalized;
        rb.AddForce(direction * launchForce, ForceMode.Impulse);
    }
    void Update()
    {
        if (transform.position.y < -5f)
        {
            transform.position = initialPosition;
            rb.velocity = Vector3.zero;
            LaunchBall();
        }
    }
}
