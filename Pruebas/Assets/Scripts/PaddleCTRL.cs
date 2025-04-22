using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCTRL : MonoBehaviour
{
    public float speed = 10f;
    private float screenHalfWidth;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Calcula el ancho de la pantalla
        float halfScreenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        screenHalfWidth = halfScreenWidth - (transform.localScale.x / 2f);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
            float targetX = Mathf.Clamp(touchPosition.x, -screenHalfWidth, screenHalfWidth);

            // Mueve el Rigidbody
            Vector3 newPosition = Vector3.Lerp(rb.position, new Vector3(targetX, rb.position.y, rb.position.z), speed * Time.deltaTime);
            rb.MovePosition(newPosition);
        }
    }
}
