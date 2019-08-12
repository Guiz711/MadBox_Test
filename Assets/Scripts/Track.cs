using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Track : MonoBehaviour
{
	public abstract Vector3 GetStartPosition();
	public abstract Vector3 GetNextPosition(Vector3 currentPosition, float speed);
}
