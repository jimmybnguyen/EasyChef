using UnityEngine;
using VRTK;

public class Openable_Oven : VRTK_InteractableObject {

	public bool opened = false;
    public bool flipped = false;
    public bool rotated = false;

    private float speed = 100.0F;
    private float sideFlip = -1;
    private float side = -1;
    private float doorOpenAngle = -70.0F;

    private Vector3 defaultRotation;
    private Vector4 openRotation;
    private Vector3 openPosition;
    private Vector3 defaultPosition;


 //   private float maxRotationX = 70.0F;
 ////private float maxPosZ = -1.5F;
 ////private float maxPosY = -2.0F;
 //private float turnspeed = 17.5F;
 //private float movespeedy = 0.5F;
 //private float movespeedz = 0.5F;

    public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
        SetDoorRotation(usingObject.transform.position);
        SetRotation();
        SetPosition();
        opened = !opened;
	}

	// Use this for initialization
	protected override void Start () {
		base.Start();
        defaultRotation = transform.eulerAngles;
        defaultPosition = transform.position;
        SetRotation();
        SetPosition();
        sideFlip = (flipped ? 1 : -1);
    }
	
	// Update is called once per frame
	protected override void Update () {
		if(opened) {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(openRotation), Time.deltaTime * speed);
            transform.position = Vector3.MoveTowards(transform.position, openPosition, Time.deltaTime * speed);
		} else {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(defaultRotation), Time.deltaTime * speed);
            transform.position = Vector3.MoveTowards(transform.position, defaultPosition, Time.deltaTime * speed);
        }
	}

    private void SetRotation()
    {
        openRotation = new Vector3(defaultRotation.x + (doorOpenAngle * (sideFlip * side)), defaultRotation.y, defaultRotation.z);
    }

    private void SetPosition()
    {
        openPosition = new Vector3(defaultPosition.x, defaultPosition.y + -0.4F, defaultPosition.z + -0.35F);
    }

    private void SetDoorRotation(Vector3 interacterPosition)
    {
        side = ((rotated == false && interacterPosition.z > transform.position.z) || (rotated == true && interacterPosition.y > transform.position.y) ? -1 : 1);
    }
}
