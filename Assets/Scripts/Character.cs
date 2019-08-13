using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Character : MonoBehaviour
{
	private static float sCollisionCooldown = 1f;

	public float			Speed;
	public float			OffsetY;

	public bool				BlockInput { get; set; }

	private Track			mTrack;
	private bool			mIsMoving;
	private float			mDistanceTravelled;
	private Vector3			mOffset;
	private Rigidbody		mRigidBody;
	private float			mLastCollisionTime;
	private FollowPlayer	mCamera;

	private void Awake()
	{
		mRigidBody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (mIsMoving && mTrack != null)
		{
			transform.position = mTrack.GetNextPosition(transform.position, Speed);
			transform.rotation = mTrack.GetRotation(transform.position);
		}
	}

	public void Init(Track track)
	{
		mTrack = track;
		mOffset = new Vector3(0, OffsetY, 0);
		transform.position = mTrack.GetStartPosition() + mOffset;
		transform.rotation = mTrack.GetRotation(transform.position);
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Traps")
			&& Time.realtimeSinceStartup - mLastCollisionTime >= sCollisionCooldown)
		{
			mLastCollisionTime = Time.realtimeSinceStartup;
			mIsMoving = false;
			BlockInput = true;
			Invoke("Respawn", sCollisionCooldown);
		}
	}

	public void SetMove(bool move)
	{
		if (!BlockInput)
			mIsMoving = move;
	}

	private void Respawn()
	{
			BlockInput = false;
			mRigidBody.velocity = Vector3.zero;
			mRigidBody.angularVelocity = Vector3.zero;
			transform.position = mTrack.GetCheckpointPosition() + mOffset;
			transform.rotation = mTrack.GetRotation(transform.position);
	}

}
