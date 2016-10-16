using UnityEngine;
using System.Collections;

public class Openable_Oven : VRTK_InteractableObject {

	public bool opened = false;

	private float maxRotationX = 70.0F;
	private float maxPosZ = -1.5F;
	private float maxPosY = -2.0F;
	private float turnspeed = 17.5F;
	private float movespeedy = 0.5F;
	private float movespeedz = 0.5F;

	public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
		opened = !opened;
		//the currently closed door will open
		//once the method is called

	}

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		if(opened)
		{
			openOven();

		}else
		{
			closeOven();	
			
		}
	}
	void openOven()
	{
		if (transform.eulerAngles.x < maxRotationX) {
			//right is x, stop rotating til we are at 70 degrees
			transform.Rotate (Vector3.right, turnspeed * Time.deltaTime, Space.Self);
		}

		if (transform.localPosition.y > maxPosY) {
			//up is y
			transform.Translate (Vector3.down * Time.deltaTime * movespeedy, Space.World);
		}

		float percent = transform.eulerAngles.x / maxRotationX;
		if (percent >= 0.25 && transform.localPosition.z > maxPosZ) {
			//forward is z
			transform.Translate (Vector3.back * Time.deltaTime * movespeedz, Space.World);
			//it takes the z animation a second before execution
		}
	}

	void closeOven()
	{
		if (transform.eulerAngles.x > 0) {
			//right is x
			//transform.eulerAngles is the current angle of the door
			transform.Rotate (Vector3.left, turnspeed * Time.deltaTime, Space.Self);
		}

		if (transform.localPosition.y < 0) {
			//up is y
			transform.Translate (Vector3.up * Time.deltaTime * movespeedy, Space.World);
		}

		float percent = transform.eulerAngles.x / maxRotationX;
		//70/70 is one, it will start earlier. it finishes a minute ealrier than starts ealier
		if (percent >= 0.25 && transform.localPosition.z < 0) {
			//forward is z
			transform.Translate (Vector3.forward * Time.deltaTime * movespeedz, Space.World);
		}
	}
}
