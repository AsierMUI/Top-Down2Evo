using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float detectionRange = 5f;
    public float moveSpeed = 2f;

 


    private void OnDestroy()
    {
        FindObjectOfType().EnemyDefeated();
    }
}
