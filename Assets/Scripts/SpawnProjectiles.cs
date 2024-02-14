using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectToSpawn;
    public GameObject wand;

    void Start()
    {
        effectToSpawn = vfx[0];
    }

    void Update()
    {
        if(Input.GetMouseButton(0)) 
        {
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if(firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, wand.transform.rotation);
        }
        
    }
}
