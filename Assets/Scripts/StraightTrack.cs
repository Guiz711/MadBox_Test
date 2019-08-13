using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightTrack : Track
{
	public MeshFilter	AttachedMeshFilter;
	public Transform	Start;
	public Transform	End;

	private float		mSqrDistance;
	private Vector3		mDir;
	private Quaternion	mRotation;

	private void Awake()
	{
		var segment = End.position - Start.position;
		mSqrDistance = segment.sqrMagnitude;
		mDir = segment.normalized;
		mRotation = Quaternion.LookRotation(mDir, AttachedMeshFilter.mesh.normals[0]);
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
			if (OnTrackFinished != null)
			{
				OnTrackFinished();
			}
			return End.position;
		}
		return currentPosition + mDir * speed * Time.deltaTime;
	}

	public override Quaternion GetRotation(Vector3 position)
	{
		return mRotation;
	}
}
