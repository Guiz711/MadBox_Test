using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationTrap : MonoBehaviour
{
	public Transform[]	MovingParts;
	[Range(0, 200)]
	public float		Speed;
    public Vector3      TranslationDirection;
    public float        TranslationMagnitude;
    public float        Delay;

    private float[]     mCurrentMagnitudes;
    private float[]     mSpeedSigns;
    private int         mPartsToMove;
    private float       mLastMoveTime;

    private void Awake()
    {
        mCurrentMagnitudes = new float[MovingParts.Length];
        mSpeedSigns = new float[MovingParts.Length];
        mPartsToMove = 0;
        for (int i = 0; i < mSpeedSigns.Length; ++i)
        {
            mSpeedSigns[i] = 1;
        }
    }

    private void Start()
    {
        mLastMoveTime = Time.realtimeSinceStartup;
    }

	private void Update()
	{
        if (mPartsToMove < MovingParts.Length && Time.realtimeSinceStartup - mLastMoveTime >= Delay)
        {
            mLastMoveTime = Time.realtimeSinceStartup;
            ++mPartsToMove;
        }

        for (int i = 0; i < mPartsToMove; ++i)
        {
            var magnitude = Speed * mSpeedSigns[i] * Time.deltaTime;

            mCurrentMagnitudes[i] += magnitude;
            MovingParts[i].position += TranslationDirection * magnitude;
            if (mCurrentMagnitudes[i] >= TranslationMagnitude)
                mSpeedSigns[i] = -1;
            else if (mCurrentMagnitudes[i] <= 0)
                mSpeedSigns[i] = 1;
        }
	}
}
