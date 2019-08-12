using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Character : MonoBehaviour
{
	public PathCreator	Track;
	public float		Speed;

	private bool		mIsMoving;
	private float		mDistanceTravelled;

	private void Awake()
	{
		transform.position = Track.path.GetPoint(0);
		transform.rotation = Track.path.GetRotation(0f);
	}

	private void Update()
	{
		if (mIsMoving)
		{
			mDistanceTravelled += Speed * Time.deltaTime;
			transform.position = Track.path.GetPointAtDistance(mDistanceTravelled, EndOfPathInstruction.Stop);
			transform.rotation = Track.path.GetRotationAtDistance(mDistanceTravelled, EndOfPathInstruction.Stop);
		}
	}

	public void SetMove(bool move)
	{
		mIsMoving = move;
	}
}
