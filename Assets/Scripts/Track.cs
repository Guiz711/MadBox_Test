using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Track : MonoBehaviour
{
	public Vector3			CameraOffset;

	public delegate void	TrackEvent();
	public TrackEvent		OnTrackFinished;

	public abstract Vector3 GetStartPosition();
	public abstract Vector3 GetNextPosition(Vector3 currentPosition, float speed);
	public abstract Quaternion GetRotation(Vector3 position);
}
