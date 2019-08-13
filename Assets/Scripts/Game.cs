using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Game : MonoBehaviour
{
	[System.Serializable]
	public class Race
	{
		public GameObject	RootObject;
		public Track[]		Tracks;
	}

	public GameObject	CharacterPrefab;
	public FollowPlayer	MainCamera;
	public Race[]		Races;
	public GameObject	EndLevelPanel;

	private Character	mPlayer;
	private int			mCurrentRaceIndex;
	private int			mCurrentTrackIndex;
	private Track		mCurrentTrack;

	private void Start()
	{
		var playerObject = Instantiate(CharacterPrefab);
		mPlayer = playerObject.GetComponent<Character>();
		MainCamera.Target = playerObject.transform;
		InitRace();
	}

	public void InitRace()
	{
		EndLevelPanel.SetActive(false);
		mCurrentTrackIndex = 0;
		InitTrack();
	}

	public void InitTrack()
	{
		mCurrentTrack = Races[mCurrentRaceIndex].Tracks[mCurrentTrackIndex];
		mPlayer.Init(mCurrentTrack);
		mCurrentTrack.OnTrackFinished += TrackFinished;
		MainCamera.DistFromTarget = mCurrentTrack.CameraOffset;
	}

	public void TrackFinished()
	{
		mCurrentTrack.OnTrackFinished -= TrackFinished;
		++mCurrentTrackIndex;
		if (mCurrentTrackIndex >= Races[mCurrentRaceIndex].Tracks.Length)
			RaceFinished();
		else
			InitTrack();
	}

	private void RaceFinished()
	{
		EndLevelPanel.SetActive(true);
	}
}
