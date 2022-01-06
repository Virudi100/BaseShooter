using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnTargets : MonoBehaviour
{
    //private List<GameObject> targetList = new List<GameObject>();
    public GameObject targetPrefab;
    private int nbrSpawned = 0;
    public bool isTaked = true;
    private Vector3 xmin;
    private Vector3 xmax;
    private Vector3 ymin;
    private Vector3 ymax;
    private Vector3 zmin;
    private Vector3 zmax;

    private void Start()
    {
        xmin = new Vector3(-2f, 0, 0);
        xmax = new Vector3(2f, 0, 0);
        ymax = new Vector3(0,7f, 0);
        ymin = new Vector3(0, 3f, 0);
        zmax = new Vector3(0, 0, -10f);
        zmin = new Vector3(0, 0, 5f);
    }

    private void FixedUpdate()
    {
        SpawnTarget();
    }

    private void SpawnTarget()
    {
        if (isTaked == true && nbrSpawned < 7)
        {
            Instantiate(targetPrefab, PositionToSpawn(), Quaternion.identity);
            isTaked = false;
            nbrSpawned++;
        }
    }

    private Vector3 PositionToSpawn()
    {
        Vector3 result = new Vector3();

        result.x = Random.Range(xmin.x, xmax.x);
        result.y = Random.Range(ymin.y, ymax.y);
        result.z = Random.Range(zmin.z, zmax.z);
        

        return result;
    }
    

}
