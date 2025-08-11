using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashScript : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float scaleVariation;

    // Start is called before the first frame update
    void OnEnable()
    {
        transform.Rotate (Vector3.forward * Random.Range(45,300));
        transform.localScale = Vector3.one * Random.Range(1, scaleVariation);
        Invoke(nameof(Deactivate),time);
    }


    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
