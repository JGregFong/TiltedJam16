using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EntryCollider : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Entered collider.");
        }
       
        
    }
}
