using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
	public float		FollowSpeed;
	public float		RotationSpeed;
	public Vector3		Offset;
	public bool			UseDebugDist;
	public Vector3		DebugDistFromTarget;

	public Transform	Target { get; set; }
	public Vector3		DistFromTarget { get; set; }

	private	void LateUpdate()
	{
		if(Target == null)
			return;

		var newPos = Target.position + DistFromTarget;
		if (UseDebugDist)
			newPos = Target.position + DebugDistFromTarget;

		var dirToTarget = (Target.position - newPos).normalized;

		transform.rotation = Quaternion.LookRotation(dirToTarget);
		transform.position = Vector3.Lerp(transform.position, newPos + Offset, FollowSpeed * Time.deltaTime);
	}

	public void JumpToTarget()
	{
		if(Target == null)
			return;

		var newPos = Target.position + DistFromTarget;
		if (UseDebugDist)
			newPos = Target.position + DebugDistFromTarget;

		var dirToTarget = (Target.position - newPos).normalized;

		transform.rotation = Quaternion.LookRotation(dirToTarget);
		transform.position = newPos + Offset;
	}
}
