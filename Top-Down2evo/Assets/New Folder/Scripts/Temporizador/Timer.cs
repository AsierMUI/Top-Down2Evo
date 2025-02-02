using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timeElapsed;
    private bool isTimerRunning;


    void Start()
    {
        timeElapsed = 0f;
        isTimerRunning = true; //inicia el temporizador desde 0
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed += Time.deltaTime; //va sumando el tiempo
            DisplayTime(timeElapsed);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        //sirve para convertir el tiempo a minutos y segundos
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //el formato son minutos:segundos
    }

    //llamarlos para controlar el tempporizador

    public void StopTimer()
    {
        isTimerRunning = false; //Para el temporizador
    }

    public void ResetTimer()
    {
        timeElapsed = 0f; //Reinicia el temporizador a 0
        isTimerRunning = true; 
    }

}
