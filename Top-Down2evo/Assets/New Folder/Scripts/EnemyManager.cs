using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public string Ganar;
    private int enemyCount;

    void Start()
    {
        enemyCount = FindObjectsOfType().Length;
    }
    void Update()
    {
        if (enemyCount <= 0)
        {
            SceneManager.LoadScene(Ganar);
        }
    }

    public void EnemyDefeated()
    {
        enemyCount--;
    }
}
