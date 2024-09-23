using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    public Rigidbody ballRb;         // Rigidbody of the ball
    public float kickForce = 500f;   // Strength of the kick
    public float kickRange = 2f;     // How close the player needs to be to the ball to kick
    public KeyCode kickKey = KeyCode.Space; // Key to press for the kick

    private void Update()
    {
        // Check the distance between the player and the ball
        float distanceToBall = Vector3.Distance(transform.position, ballRb.transform.position);

        // If the player is within kicking range and presses the kick key
        if (distanceToBall <= kickRange && Input.GetKeyDown(kickKey))
        {
            KickBall();
        }
    }

    private void KickBall()
    {
        // Calculate the direction from the player to the ball
        Vector3 directionToBall = (ballRb.transform.position - transform.position).normalized;

        // Apply force to the ball in the direction of the kick
        ballRb.AddForce(directionToBall * kickForce);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, kickRange);
    }
}
