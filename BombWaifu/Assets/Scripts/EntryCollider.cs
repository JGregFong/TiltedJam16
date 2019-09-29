using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EntryCollider : MonoBehaviour
{

    public string enemyEncounter;
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col){

        SceneManager.LoadScene(enemyEncounter);
        
    }
}
