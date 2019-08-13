using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightTrack : Track
{
	public Transform	Start;
	public Transform	End;

	private float		mSqrDistance;
	private Vector3		mDir;
	private Quaternion	mRotation;
	private int			mCurrentCheckpointIndex;

	private void Awake()
	{
		var segment = End.position - Start.position;
		mSqrDistance = segment.sqrMagnitude;
		mDir = segment.normalized;
		mRotation = Quaternion.LookRotation(mDir);

		CheckpointsSqrDist = new float[Checkpoints.Length];
		for (int i = 0; i < CheckpointsSqrDist.Length; ++i)
		{
			CheckpointsSqrDist[i] = (Checkpoints[i].position - Start.position).sqrMagnitude;
		}
	}

	public override Vector3	GetStartPosition()
	{
		return Start.position;
	}

	public override Vector3	GetNextPosition(Vector3 currentPosition, float speed)
	{
		var currentSqrDistance = (Start.position - currentPosition).sqrMagnitude;

		if (currentSqrDistance >= mSqrDistance)
		{
			mCurrentCheckpointIndex = 0;
			if (OnTrackFinished != null)
				OnTrackFinished();
			return End.position;
		}
		else if (mCurrentCheckpointIndex + 1 < Checkpoints.Length &&
			currentSqrDistance >= CheckpointsSqrDist[mCurrentCheckpointIndex + 1])
		{
			++mCurrentCheckpointIndex;
		}
		return currentPosition + mDir * speed * Time.deltaTime;
	}

	public override Vector3 GetCheckpointPosition()
	{
		return Checkpoints[mCurrentCheckpointIndex].position;
	}

	public override Quaternion GetRotation(Vector3 position)
	{
		return mRotation;
	}
}
