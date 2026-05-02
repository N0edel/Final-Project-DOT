using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Structs;

private void OnTriggerEnter2D(Collider2D collision)
{
    string LightWindtag = null;
    // If it touches the bullet, it updates 
    if (collision.gameObject.tag == LightWindtag)
    {
        //Updates the Score 
        _hw2GameController.UpdateScore();
        //Destorys the bullet
        Destroy(collision.gameObject);
        //Destorys the enemy 
        Destroy(gameObject);
    }
    // If the enemy touches a bound it gets destored 
    else if (collision.gameObject.tag == boundsTag)
    {
        Destroy(gameObject);
    }
}
}
