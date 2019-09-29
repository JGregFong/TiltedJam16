using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterScript : MonoBehaviour
{
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject enemyThree;
    bool eOneLiving = true;
    bool eTwoLiving = true;
    bool eThreeLiving = true;



    // Start is called before the first frame update
    /*
    void Awake()
    {
        if (eOneLiving)
        {
            DontDestroyOnLoad(enemyOne);
        }
        if (eTwoLiving)
        {
            DontDestroyOnLoad(enemyTwo);
        }
        if (eThreeLiving)
        {
            DontDestroyOnLoad(enemyThree);
        }
    }
    */
    // Update is called once per frame
    void Update()
    {
        if (!eOneLiving)
        {
            Destroy(enemyOne);
        }
 
        if (!eTwoLiving)
        {
            Destroy(enemyTwo);
        }

        if (!eThreeLiving)
        {
            Destroy(enemyThree);
        }

    
    }

    public void ReceiveTriggerEnter(string NPCharacter, Collider2D other)
    {
        if (NPCharacter == "Enemy One" && eOneLiving)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        if(NPCharacter == "Enemy Two" && eTwoLiving)
        {
            if(other.tag == "Player")
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        if(NPCharacter =="Enemy Three" && eThreeLiving)
        {
            if(other.tag == "Player")
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

    }

}
