using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Character	MyCharacter;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			MyCharacter.SetMove(true);
		}
		else if (Input.GetMouseButtonUp(0))
		{
			MyCharacter.SetMove(false);
		}
	}
}
