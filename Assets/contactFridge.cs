using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SteamVR_TrackedObject))]

public class ContactNotes : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

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

        //this is device is the wand. 
        NotesVer2 collidedNote = null;
        if (col.gameObject.name == "Indication Sphere")
        {
            collidedNote = col.GetComponent<NotesVer2>();
            Transform point = collidedNote.getScale();
            float percent = collidedNote.getPercent(point);

            if (percent >= 95)
            {
                perfect++;
                Debug.Log("perfect: " + perfect);
                Debug.Log("perfect Percent: " + percent);
                //Spawns the particles at the contact point, with the particles aiming upwards
                Instantiate(perfect_particles, col.transform.position, Quaternion.Euler(new Vector3(270, 0, 0)));

            }
            else if (percent >= 85 && percent < 95)
            {
                good++;
                Debug.Log("good: " + good);
                Debug.Log("good Percent: " + percent);
                //Spawns the particles at the contact point, with the particles aiming upwards
                Instantiate(good_particles, col.transform.position, Quaternion.Euler(new Vector3(270, 0, 0)));
            }
            else if (percent >= 65 && percent < 85)
            {
                okay++;
                Debug.Log("okay: " + okay);
                Debug.Log("okay Percent: " + percent);
                //Spawns the particles at the contact point, with the particles aiming upwards
                Instantiate(okay_particles, col.transform.position, Quaternion.Euler(new Vector3(270, 0, 0)));
            }
            else if (percent >= 0 && percent < 65)
            {
                bad++;
                Debug.Log("bad: " + bad);
                Debug.Log("Bad Percent: " + percent);
            }
            else
            {
                Debug.Log("N/A, reached else statement");
            }

            collidedNote.destroy();
        }

    }
}
