using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightTrack : Track
{
	public Transform	Start;
	public Transform	End;

	private float		mSqrDistance;
	private Vector3		mDir;

	private void Awake()
	{
		var segment = End.position - Start.position;
		mSqrDistance = segment.sqrMagnitude;
		mDir = segment.normalized;
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
			return End.position;
		}
		return currentPosition + mDir * speed * Time.deltaTime;
	}
}
