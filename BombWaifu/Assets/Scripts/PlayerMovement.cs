using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    Rigidbody2D rigidB;
    public float speed =10;
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal,vertical);
        transform.Translate(move* Time.deltaTime *speed);

        if(Input.GetKeyDown(KeyCode.P)){
            SceneManager.LoadScene("SampleScene");
        }

    }



}
