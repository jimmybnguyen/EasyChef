using UnityEngine;
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
        Debug.Log("you have collided with " + col.gameObject.name);
        Destroy(col.gameObject);
        Instantiate(food_particles, col.transform.position, Quaternion.Euler(new Vector3(270, 0, 0)));
        Instantiate(pepperSlices, new Vector3(0, 0, 0), Quaternion.identity);
    }

}

