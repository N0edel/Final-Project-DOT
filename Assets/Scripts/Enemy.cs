using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //==================================================================================================================
    // Variables 
    //==================================================================================================================

    //Movement Controls 
    public Rigidbody2D rigidbody2D; //The rigidbody that will move the bullet 
    public float minSpeed = 1f;           //Speed at which the bullet moves 
    public float maxSpeed = 4f;           //Speed at which the bullet moves 

    //Flag and Timer 
    public float deathTime = 100f;   //How long before the bullet dies 
    public bool playerBullet = true; //Is the bullet used by player or enemy 

    // Tags and Names 
    private string boundsTag = "Bounds";
    private string bulletTag = "Bullet";
    private string gameControllerComponent = "GameController";

    // Component 
    public GameController _hw2GameController;

    //==================================================================================================================
    // Base Method  
    //==================================================================================================================

    //Checks who is shooting the bullet and set up the bullet settings 
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector3 newSpeed)
    {
        rigidbody2D.velocity = newSpeed * Random.Range(minSpeed, maxSpeed);
    }

    //==================================================================================================================
    // Bullet Set Up  
    //==================================================================================================================


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            GetComponent<Collider2D>().enabled = false; 

        }
    }
}



