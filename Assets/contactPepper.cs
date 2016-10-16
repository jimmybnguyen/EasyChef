﻿using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]

public class contactPepper : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    public GameObject pepperSlices;
    public Transform food_particles;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("collided object: " + col.gameObject.name);
        if (col.gameObject.name == "bellpepper")
        {
            Destroy(col.gameObject);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(pepperSlices, col.transform.position, Quaternion.identity);
            }
        }
    }

}

