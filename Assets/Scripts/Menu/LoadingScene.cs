using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public CanvasGroup menuCanvasGroup;
    public CanvasGroup loadCanvasGroup;
    [Range(0.001f, 0.01f)] public float alphaFactor = 0.01f;
    public Image loadingBarImg;
    public GameObject ship;
    private bool _splashEnded;
    
    [SerializeField] private float range = 0.25f;
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float duration = 10f;

    private float _startZ;
    private float _endZ;

    private void Start()
    {
        _startZ = ship.transform.position.z;
        _endZ = 0f;
    }

    private void Update()
    {
        if (SplashScreen.isFinished && !_splashEnded)
        {
            _splashEnded = true;
            StartCoroutine(ShipGoFly());
        }
        else
        {
            Floater();
        }
        
    }

    public void Floater()
    {
        var localPos = ship.transform.localPosition;
        ship.transform.localPosition = new Vector3(localPos.x,  Mathf.Sin(Time.time * speed) * range, localPos.z);
    }

    public void LoadScene(int sceneId)
    {
        _startZ = ship.transform.position.z;
        _endZ = _startZ + 20f;
        menuCanvasGroup.interactable = false;
        StartCoroutine(ShipGoFly());
        StartCoroutine(ShowLoading(sceneId));
    }
    
    IEnumerator ShipGoFly()
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            ship.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, Mathf.SmoothStep(_startZ, _endZ, timeElapsed / duration));
            timeElapsed += Time.deltaTime;
            Floater();
            yield return null;
        }

        ship.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, 0f);
    }

    IEnumerator ShowLoading(int sceneId)
    {
        while (loadCanvasGroup.alpha < 1)
        {
            if (menuCanvasGroup.alpha > 0)
            {
                menuCanvasGroup.alpha -= alphaFactor;
            }
            else
            {
                loadCanvasGroup.alpha += alphaFactor;
            }
            yield return null;
        }
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneID)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneID);

        while (!op.isDone)
        {
            float progressVal = Mathf.Clamp01(op.progress / 0.9f);
            loadingBarImg.fillAmount = progressVal;
            yield return null;
        }
    }
}
