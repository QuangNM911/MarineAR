using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMoveController : MonoBehaviour {

	// PUBLIC
	public Animator turtleAnimator;
	public SimpleTouchController leftController;
	public SimpleTouchController rightController;
	public Transform headTrans;
	public float speedMovements = 5f;
	public float speedContinuousLook = 100f;
	public float speedProgressiveLook = 3000f;

	// PRIVATE
	private Rigidbody _rigidbody;
	[SerializeField] bool continuousRightController = true;

	void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
		rightController.TouchEvent += RightController_TouchEvent;
	}

	public bool ContinuousRightController
	{
		set{continuousRightController = value;}
	}

	void RightController_TouchEvent (Vector2 value)
	{
		if(!continuousRightController)
		{
			UpdateAim(value);
		}
	}

	void Update()
	{
		// move
		_rigidbody.MovePosition(transform.position + (transform.forward * Mathf.Abs(leftController.GetTouchPosition.y) * Time.deltaTime * speedMovements) + (transform.forward * Mathf.Abs(leftController.GetTouchPosition.x) * Time.deltaTime * speedMovements));

		if(continuousRightController)
		{
			UpdateAim(rightController.GetTouchPosition);
		}
	}

	void UpdateAim(Vector2 value)
	{
        if(value.x == 0 && value.y == 0)
        {	
			turtleAnimator.SetBool("idle", true);
			turtleAnimator.SetBool("crawl", false);
            return;
        }

		if(headTrans != null)
		{
			Quaternion rot = Quaternion.Euler(0f,
				transform.localEulerAngles.y - value.x * Time.deltaTime * -speedProgressiveLook,
				0f);

			_rigidbody.MoveRotation(rot);

			rot = Quaternion.Euler(headTrans.localEulerAngles.x - value.y * Time.deltaTime * speedProgressiveLook,
				0f,
				0f);
			headTrans.localRotation = rot;

		}
		else
		{
			turtleAnimator.SetBool("crawl", true);
			turtleAnimator.SetBool("idle", false);
            transform.forward = new Vector3(value.x, 0f, value.y);
		}
	}

	void OnDestroy()
	{
		rightController.TouchEvent -= RightController_TouchEvent;
	}

}
