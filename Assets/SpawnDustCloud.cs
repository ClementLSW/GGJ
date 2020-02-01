using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDustCloud : MonoBehaviour
{
    // Load dust cloud prefab from resources folder
    [SerializeField] private GameObject cloud;
    private GameObject newcloud;

    // Spawn dustCloud at position passed in parameters
    public void SpawnCloud(Transform tr)
    {
        newcloud = Instantiate(cloud, tr) as GameObject;
        Invoke("Despawn", .5f);
    }

    private void Despawn()
    {
        Destroy(newcloud);
    }

}
