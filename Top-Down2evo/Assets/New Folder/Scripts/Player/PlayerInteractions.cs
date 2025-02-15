using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    public TMP_Text pointsText;
    public int points;
    public int winPoints;
    public SceneChanger sceneManagerScript;
    public int sceneToLoad;
    public GameObject goal;

    private bool isCanvasActive = false;
    public Canvas canvas;



    private void Start()
    {
        UpdateScoreText();
        canvas = GameObject.Find("CanvasSalida").GetComponent<Canvas>();
        canvas.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (points < 0) { points = 0; }
        if (points >= winPoints)
        {
            goal.SetActive(true);
            ActivateCanvas();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp"))
        {
            points += 1;
            UpdateScoreText();
            collision.gameObject.SetActive(false);
        }

        if (collision.CompareTag("Finish"))
        {
            WinCall();
        }


        if (collision.CompareTag("Trap"))
        {
            sceneManagerScript.SceneLoader(3);
        }
    }

    private void UpdateScoreText()
    {
        pointsText.text = "Tesoros: " + points.ToString() + "/" + winPoints.ToString();
    }

    private void WinCall()
    {
        sceneManagerScript.SceneLoader(sceneToLoad);
    }

    private void ActivateCanvas()
    {
        if (!isCanvasActive)
        {
            isCanvasActive = true;
            canvas.gameObject.SetActive(true);
            StartCoroutine(DestroyCanvasAfterTime(5f));
        }
    }
        private IEnumerator DestroyCanvasAfterTime(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        Destroy(canvas.gameObject);
            isCanvasActive = false;
        }

  
}
