using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]

public class contactZuc : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    public GameObject zucSlices;
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
        if (col.gameObject.name == "zuchinni")
        {
            Instantiate(soundfx, col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(zucSlices, col.transform.position, Quaternion.identity);
            }
        }
    }

}

