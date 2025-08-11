using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSplatter : MonoBehaviour
{

    [SerializeField] GameObject splatterParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 collisionPoint = collision.GetContact(0).point;
        Vector3 collisionNormal = collision.GetContact(0).normal;
        Quaternion newDirection = Quaternion.FromToRotation(Vector3.forward, collisionNormal);
        GameObject clon = Instantiate(splatterParticle, collisionPoint,newDirection);
        Destroy(clon,2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 collisionPoint = other.ClosestPointOnBounds(transform.position);
        Vector3 collisionNormal = (other.transform.position - collisionPoint).normalized;
        Quaternion newDirection = Quaternion.FromToRotation(Vector3.forward, collisionNormal);
        GameObject clon = Instantiate(splatterParticle, collisionPoint, newDirection);
        Destroy(clon, 2);
        Destroy(gameObject);
    }
}
