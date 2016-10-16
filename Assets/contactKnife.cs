using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]

public class contactKnife : MonoBehaviour
{
    public GameObject pepperSlices;
    public GameObject knife;
    public Transform food_particles;

    void Awake()
    {

    }


    void Update()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("collided object: " + col.gameObject.name);
        if (col.gameObject.name == knife.name)
        {
            //Debug.Log("yay");
            //Debug.Log("Inside if statement");
            Destroy(this.gameObject);
            Instantiate(food_particles, col.transform.position, Quaternion.Euler(new Vector3(270, 0, 0)));
            Instantiate(pepperSlices, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    void OnTriggerStay(Collider col)
    {
        Debug.Log(col.name == knife.name);
        if (col.gameObject.name == knife.name)
        {
            Debug.Log("stay yay");
            Destroy(this.gameObject);
            Instantiate(food_particles, col.transform.position, Quaternion.Euler(new Vector3(270, 0, 0)));
            Instantiate(pepperSlices, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

}

