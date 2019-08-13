using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Character : MonoBehaviour
{
	public float		Speed;
	public float		OffsetY;

	private Track		mTrack;
	private bool		mIsMoving;
	private float		mDistanceTravelled;
	private Vector3		mOffset;

	private void Update()
	{
		if (mIsMoving && mTrack != null)
		{
			// mDistanceTravelled += Speed * Time.deltaTime;
			// transform.position = mTrack.path.GetPointAtDistance(mDistanceTravelled, EndOfPathInstruction.Stop);
			// transform.rotation = mTrack.path.GetRotationAtDistance(mDistanceTravelled, EndOfPathInstruction.Stop);

			transform.position = mTrack.GetNextPosition(transform.position, Speed);
			transform.rotation = mTrack.GetRotation(transform.position);
		}
	}

	public void Init(Track track)
	{
		mTrack = track;
		mOffset = new Vector3(0, OffsetY, 0);
		// transform.position = mTrack.path.GetPoint(0);
		// transform.rotation = mTrack.path.GetRotation(0f);
		transform.position = mTrack.GetStartPosition() + mOffset;
		transform.rotation = mTrack.GetRotation(transform.position);
	}

	public void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Traps"))
		{
			Debug.LogWarning("YOU LOOSE !");
		}
	}

	public void SetMove(bool move)
	{
		mIsMoving = move;
	}
}
