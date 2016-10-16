using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]

public class contactPepper : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    public GameObject pepperSlices;
    public Transform food_particles;
    public GameObject soundfx;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "bellpepper")
        {
            Instantiate(soundfx, col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            for (int i = 0; i < 4; i++)
            {
                Instantiate(pepperSlices, col.transform.position, Quaternion.identity);
            }
        }
    }

}

