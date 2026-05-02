using UnityEngine;

public class RandomPush : MonoBehaviour
{
    public float forceStrength = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component from the object
        rb = GetComponent<Rigidbody2D>();

        // Create a random direction using a unit circle
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        // Apply the force
        rb.AddForce(randomDirection * forceStrength, ForceMode2D.Impulse);
    }
}
