using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform m_transform;
    void awake() => m_transform = transform;
    private void FixedUpdate() => m_transform.position += m_transform.TransformDirection(Vector3.left) * speed;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            m_transform.Rotate(0, 180, 0);
        }
    }


}
