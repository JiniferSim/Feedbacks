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
    public GameObject sparcles;

    public float minProjectileSize = 1f; // Minimum size of the projectile
    public float maxProjectileSize = 3f; // Maximum size of the projectile
    public float maxHoldDuration = 1f; // Maximum duration for full size
    public float cameraMoveBackDistance = 2f;

    private bool isCharging = false;
    private float chargeStartTime;
    private Camera mainCamera;


    void Start()
    {
        effectToSpawn = vfx[0];
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            isCharging = true;
            chargeStartTime = Time.time;
            sparcles.gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isCharging = false;
            //StopAllCoroutines();
            float chargeDuration = Time.time - chargeStartTime;
            float projectileSize = Mathf.Lerp(minProjectileSize, maxProjectileSize, Mathf.Clamp01(chargeDuration / maxHoldDuration));
            SpawnVFX(projectileSize);
            sparcles.gameObject.SetActive(false);

            if (chargeDuration >= maxHoldDuration)
            {
                // Set the effect to spawn to the second effect in the list
                effectToSpawn = vfx[1];
            }
            else
            {
                effectToSpawn = vfx[0];
            }
        }
    }

    void SpawnVFX(float size)
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, wand.transform.rotation);
            vfx.transform.localScale = new Vector3(size, size, size);
        }
    }
}
