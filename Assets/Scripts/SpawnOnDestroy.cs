using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
    public GameObject prefabToSpawn; // The object to spawn when this object is destroyed
    public Vector3 spawnOffset; // Offset for spawning the new object

    private void OnDestroy()
    {
        if (prefabToSpawn != null)
        {
            // Spawn the object at the position of this object plus the offset
            Instantiate(prefabToSpawn, transform.position + spawnOffset, Quaternion.identity);
        }
    }
}
