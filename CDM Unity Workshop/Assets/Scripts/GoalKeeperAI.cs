using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeperAI : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed at which the goalkeeper moves
    public float moveDistance = 2f;  // Distance from the center point the goalkeeper moves left and right

    private Vector3 startPosition;

    void Start()
    {
        // Store the starting position to use it as the center for movement
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position using PingPong
        float movement = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;

        // Update the position along the X-axis (swing left and right)
        transform.position = new Vector3(startPosition.x + movement, transform.position.y, transform.position.z);
    }
}
