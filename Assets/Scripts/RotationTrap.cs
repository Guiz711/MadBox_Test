using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTrap : MonoBehaviour
{
	public enum			Direction
	{
		Clockwise,
		Counterclockwise
	}

	public Transform	MovingPart;
	[Range(0, 200)]
	public float		Speed;
	public Vector3		RotationAxis;
	public Direction	RotationDirection;

	private void Update()
	{
		var signedSpeed = RotationDirection == Direction.Clockwise ? Speed : -Speed;
		MovingPart.rotation *= Quaternion.AngleAxis(signedSpeed * Time.deltaTime, RotationAxis);
	}
}
