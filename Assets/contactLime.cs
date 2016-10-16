﻿using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]

public class contactLime : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    public GameObject limeSlices;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "lime")
        {
            Destroy(col.gameObject);
            for (int i = 0; i < 3; i++)
            {
                Instantiate(limeSlices, col.transform.position, Quaternion.identity);
            }
        }
    }

}

