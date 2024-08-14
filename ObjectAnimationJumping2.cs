using UnityEngine;

public class ObjectAnimationJumping2 : MonoBehaviour
{
    public float jumpHeight = 2.0f; // Adjust the height of the jump
    public float jumpSpeed = 2.0f; // Adjust the speed of the jump

    void Update()
    {
        // Make the object jump along the X-axis
        float jump = Mathf.Sin(Time.time * jumpSpeed) * jumpHeight; // You can adjust the jumpHeight and jumpSpeed
        transform.position = new Vector3(jump, transform.position.y, transform.position.z);
    }
}
