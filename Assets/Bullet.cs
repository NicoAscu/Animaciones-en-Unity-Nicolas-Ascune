using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    [SerializeField] Rigidbody rb;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        rb.velocity = transform.forward * speed;
        //transform.position += transform.forward * speed;
    }
    
    void OnCollisionEnter()
    {
    }
}
