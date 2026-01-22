using UnityEngine;

public class movmentFortest : MonoBehaviour
{
    float horizontal;
    [SerializeField] float speed = 8f;

    [SerializeField] private Rigidbody2D rb;


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

}
