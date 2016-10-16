using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class changeText : MonoBehaviour {
    public GameObject display;

    TextMesh instruction;
    int i = 0;
    string[] instructions = { "Hi! Welcome to EasyChef.\nToday we'll help you make some\nzucchini linguine. Touch the\n'green box to get your next instructions\nand the red box to go back",
                              "First, touch the\nzucchini to peel it",
                              "Touch \npepper to slice it!",
                              "Touch & grip the lime \nto juice it",
                              "Toss it all in the tray",
                              "Pop it on into the oven",
                              "Tada~ Enjoy your healthy meal~"};

    // Use this for initialization
    void Start () {
        instruction = display.GetComponent(typeof(TextMesh)) as TextMesh;
        Debug.Log("starting instruction: " + instruction.text);
        instruction.text = instructions[i];
        Debug.Log("0: " + instruction.text);
    }

    void OnTriggerEnter(Collider col)
    {
        instruction = display.GetComponent(typeof(TextMesh)) as TextMesh;
        i += 1;
        Debug.Log("prev instruction: " + instruction.text);
        Debug.Log("triggered, i = " + i);
        instruction.text = instructions[i];
        Debug.Log(i + ": " + instruction.text);
    }
}
