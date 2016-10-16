using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class changeText : MonoBehaviour {
    Text instruction;
    int i;
    string[] instructions = { "Hi! Welcome to EasyChef. Today we'll help you make some zucchini linguine. Click the 'next instruction' button to get started.",
                              "First, touch & grip the zucchini to peel it",
                              "Touch & grip the bell pepper to slice it!",
                              "Touch & grip the lime to juice it",
                              "In a large bowl, mix the zucchini strips, shrimp, bell pepper sliced, lime juice, salt, pepper, garlic powder, and olive oil until the mixture is evenly coated.",
                              "On a roasting tray, spread the mixture into one even layer and bake for 8 minutes",
                              "Enjoy your healthy meal~"};

	// Use this for initialization
	void Start () {
        instruction = GetComponent<Text>();
        i = 0;
        instruction.text = instructions[0];
	}

    public void getNextInstruction()
    {
        i++;
        if (i < instructions.Length)
        {
            instruction.text = instructions[i];
        }
    }
}
