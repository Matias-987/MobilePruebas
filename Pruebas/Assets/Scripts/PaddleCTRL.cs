using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCTRL : MonoBehaviour
{
    public float speed = 10f;
    private float screenHalfWidth;

    void Start()
    {
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
            float targetX = touchPosition.x;

            // Limita el movimiento dentro de los bordes de la pantalla
            targetX = Mathf.Clamp(targetX, -screenHalfWidth, screenHalfWidth);

            // Mueve suavemente la barra
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }
}
