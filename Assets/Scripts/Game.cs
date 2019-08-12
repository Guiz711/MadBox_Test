using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Game : MonoBehaviour
{
	public GameObject	CharacterPrefab;
	public FollowPlayer	MainCamera;
	public PathCreator	Track;

	private void Start()
	{
		var playerObject = Instantiate(CharacterPrefab);
		playerObject.GetComponent<Character>().Init(Track);
		MainCamera.SetTarget(playerObject.transform);
	}
}
