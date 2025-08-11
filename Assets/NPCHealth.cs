using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCHealth : MonoBehaviour
{
    public float healthPoints;
    public NavMeshAgent agent;
    public Animator anim;
    public Rigidbody rb;
    public Transform target;
    public float destroyTime;
    public bool destroyOnDeath;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = FindObjectOfType<CharacterController>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        if (healthPoints<=0)
        {
            Death();
        }
    }

    private void Death()
    {
       // agent.GetComponent<Collider>().enabled = false;
        agent.GetComponent<AgentScript>().enabled = false;
        agent.enabled = false;
        //NavMeshObstacle obstacle = agent.gameObject.AddComponent<NavMeshObstacle>();
        //obstacle.carving = true;
        //obstacle.carveOnlyStationary = true;
        anim.SetBool("Death", true);
       // rb.isKinematic = true;
        Vector3 relativePos = target.position - transform.position;
        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
        this.enabled = false;

        if (destroyOnDeath)
        {
            Destroy(gameObject,destroyTime);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        DamageOnCollision damage = collision.gameObject.GetComponent<DamageOnCollision>();
        if (damage)
        {

            //target = collision.transform;
            TakeDamage(damage.damagePoints);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageOnCollision damage = other.gameObject.GetComponent<DamageOnCollision>();
        if (damage)
        {

            //target = collision.transform;
            TakeDamage(damage.damagePoints);
        }
    }

}
