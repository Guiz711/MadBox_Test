using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Character : MonoBehaviour
{
	public float		Speed;

	private PathCreator	mTrack;
	private bool		mIsMoving;
	private float		mDistanceTravelled;

	private void FixedUpdate()
	{
		if (mIsMoving && mTrack != null)
		{
			mDistanceTravelled += Speed * Time.deltaTime;
			transform.position = mTrack.path.GetPointAtDistance(mDistanceTravelled, EndOfPathInstruction.Stop);
			transform.rotation = mTrack.path.GetRotationAtDistance(mDistanceTravelled, EndOfPathInstruction.Stop);
		}
	}

	public void Init(PathCreator track)
	{
		mTrack = track;
		transform.position = mTrack.path.GetPoint(0);
		transform.rotation = mTrack.path.GetRotation(0f);
	}

	public void SetMove(bool move)
	{
		mIsMoving = move;
	}
}
