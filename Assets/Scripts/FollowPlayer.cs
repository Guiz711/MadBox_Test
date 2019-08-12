using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public float			FollowSpeed;
	public float			OffsetY;

	private Transform		mTarget;
	private Vector3			mOffset;

    private void FixedUpdate()
    {
		if (mTarget != null)
		{
			transform.position = Vector3.Lerp(transform.position, mTarget.position + OffsetY * Vector3.up, FollowSpeed * Time.deltaTime);
		}
    }

	public void SetTarget(Transform target)
	{
		mTarget = target;
		transform.position = target.position + OffsetY * Vector3.up;
	}
}
