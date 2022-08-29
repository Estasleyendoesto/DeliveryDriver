using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed  = 1f;  // Velocidad de rotación
    [SerializeField] float moveSpeed   = 20f; // Velocidad de movimiento
    [SerializeField] float slowSpeed   = 10f; // Velocidad lenta
    [SerializeField] float boostSpeed  = 30f; // Impulso de velocidad
    [SerializeField] float normalSpeed = 20f; // Velocidad normal
    [SerializeField] float speedChangeDuration = 2.5f;

    float time;
    bool  counterOn;

    void Update()
    {
        if (counterOn)
            WaitForSeconds();

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount  = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
        ChangeSpeedActivation();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            ChangeSpeedActivation();
        }
    }

    void ChangeSpeedActivation()
    {
        counterOn = true;
        time = 0;
    }

    void WaitForSeconds()
    {
        if (time <= speedChangeDuration)
            time += Time.deltaTime;
        else
        {
            time = 0;
            counterOn = false;
            moveSpeed = normalSpeed;
        }
    }
}
