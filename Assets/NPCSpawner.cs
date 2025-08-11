using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCSpawner : MonoBehaviour
{
    public GameObject NPCPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject clon= Instantiate(NPCPrefab,transform.position, Quaternion.identity);
    }
}
