using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class fly_script : MonoBehaviour
{
    [SerializeField] private float velocity = 2f;
    [SerializeField] private float rotationSpeed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            rb.linearVelocity = Vector2.up * velocity;
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.linearVelocityY * rotationSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor") || collision.gameObject.CompareTag("pipes"))
        {
            game_manager_script.instance.GameOver();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cloud"))
        {
            Vector3 cloudPosition = collision.transform.position;
            trollface_script.instance.TrollfaceSpawn(cloudPosition);
            game_manager_script.instance.GameOver();
        }
    }
}
