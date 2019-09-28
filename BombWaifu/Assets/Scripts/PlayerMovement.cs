using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    Rigidbody2D rigidbody;
    public float speed = 5;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal,vertical);
        rigidbody.AddForce(move *speed);

    }

    void TriggerOnEnter2D(Collider2D enemy){
        //SceneManager.LoadScene(battleOne);
    }


}
