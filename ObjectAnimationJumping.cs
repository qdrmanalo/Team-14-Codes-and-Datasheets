using UnityEngine;

public class ObjectAnimationJumping : MonoBehaviour
{
    public float jumpHeight = 2.0f; // Adjust the height of the jump
    public float jumpSpeed = 2.0f; // Adjust the speed of the jump

    void Update()
    {
        // Make the object jump along the Y-axis
        float jump = Mathf.Sin(Time.time * jumpSpeed) * jumpHeight; // You can adjust the jumpHeight and jumpSpeed
        transform.position = new Vector3(transform.position.x, jump, transform.position.z);
    }
}
