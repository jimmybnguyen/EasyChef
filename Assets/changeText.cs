using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class changeText : MonoBehaviour {
    public GameObject display;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    TextMesh instruction;
    int i = 0;
    string[] instructions = { "Hi! Welcome to EasyChef.\nToday we'll help you make some\nzucchini linguine. Touch the\n'pink box to get your instructions.",
                              "First, touch & grip the\nzucchini to peel it",
                              "Touch & grip the bell \npepper to slice it!",
                              "Touch & grip the lime \nto juice it",
                              "In a large bowl, mix the \nzucchini strips, shrimp, bell \npepper sliced, lime juice, \nsalt, pepper, garlic powder, and\n olive oil until the mixture is evenly coated.\n",
                              "On a roasting tray, spread the mixture\ninto one even layer and bake for 8 minutes",
                              "Enjoy your healthy meal~"};

	// Use this for initialization
	void Start () {
        instruction = display.GetComponent(typeof(TextMesh)) as TextMesh;
        trackedObject = GetComponent<SteamVR_TrackedObject>();

        Debug.Log("starting instruction: " + instruction.text);
        instruction.text = instructions[i];
        Debug.Log("0: " + instruction.text);
    }

    void Update()
    {
        instruction = display.GetComponent(typeof(TextMesh)) as TextMesh;
        device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetPressDown(triggerButton))
        {
            i += 1;
            Debug.Log("prev instruction: " + instruction.text);
            Debug.Log("triggered, i = " + i);
            instruction.text = instructions[i];
            Debug.Log(i + ": " + instruction.text);
        }
    }
}
