using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FinshPoint : MonoBehaviour
{
    [SerializeField] 
     string nextLevelName;
    [SerializeField]
     int nextLevelint;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Level Complete!");

            GameManger.instance.NextLevel();
            // Load the next level or show a level complete screen
        }
    }
}
