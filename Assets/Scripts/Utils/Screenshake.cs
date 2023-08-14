using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Screenshake : MonoBehaviour
{
    public float rotationSpeed = 6;
    public float returnSpeed = 25;

    public Vector3 recoilRotation = new Vector3(2f, 2f, 2f);
    private Vector3 currentRotation;
    private Vector3 rot;
    private Transform cam;

    //Should be public
    private static Screenshake _instance;
    public static Screenshake instance
    {
        get
        {
            return _instance;
        }
    }

    private float mod;

	private void Awake()
	{
		_instance = this;
        mod = 1;
        cam = transform.parent;
	}


    private void FixedUpdate()
    {
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        rot = Vector3.Slerp(rot, currentRotation, rotationSpeed * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(rot);
    }

    public void Fire(float multiplier, float stopMultiplier)
    {
        RotationShake(multiplier * mod);
        ScreenPause(stopMultiplier);
    }

    public void RotationShake(float multiplier)
    {
        currentRotation += new Vector3(Random.Range(-recoilRotation.x, recoilRotation.x), Random.Range(-recoilRotation.y, recoilRotation.y), Random.Range(-recoilRotation.z, recoilRotation.z)) * multiplier;
    }

    public void ScreenPause(float stopMultiplier)
    {
        if (Math.Abs(Time.timeScale - 1) > Mathf.Epsilon) return;
        StartCoroutine(ScreenPauseCoroutine(stopMultiplier));
    }

    public IEnumerator ScreenPauseCoroutine(float stopMultiplier)
    {
        yield return new WaitForSeconds(Time.deltaTime);
         if(Time.timeScale != 0) Time.timeScale = 0.25f;
        yield return new WaitForSecondsRealtime(0.02f*stopMultiplier);
        if(Time.timeScale != 0) Time.timeScale = 1;
    }

    public static Screenshake GetInstance()
    {
        return _instance;
    }
}

