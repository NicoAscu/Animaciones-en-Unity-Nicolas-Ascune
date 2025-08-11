using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn = null;
    public GameObject muzzleFlash;
    public float reloadTime;
    public float inacuracy;
    float currReloadTime;
    bool canShoot = true;
    void Start()
    {
        currReloadTime = reloadTime;
    }
    void Update()
    {
        if(currReloadTime > 0)
        {
            currReloadTime -= Time.deltaTime;
        }
        if(Input.GetMouseButton(0) && currReloadTime <= 0)
        {
            Shoot();           
        }
    }

    void Shoot()
    {
        var b = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        //b.transform.eulerAngles += new Vector3(Random.Range(-inacuracy, inacuracy), Random.Range(-inacuracy, inacuracy), Random.Range(-inacuracy, inacuracy));
        //esta linea esta por si quieren hacer que la bala tenga cierta imprecision
        //en su salida. Solo la roto en x y z al azar
        currReloadTime = reloadTime;
        if (muzzleFlash)
        {
            muzzleFlash.SetActive(true);
        }
    }
}
