using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPotion : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object that collided is a potion
        if (collision.gameObject.CompareTag("Potion")) 
        {
            // Destroy the object after it collides with the basket
            Destroy(collision.gameObject);
        }
    }
}
