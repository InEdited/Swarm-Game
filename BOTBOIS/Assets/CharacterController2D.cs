using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 9;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 70;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    float jumpHeight = 4;

    public Rigidbody2D rigidBody;

    private CircleCollider2D boxCollider;

    private Vector2 velocity;

    private float botSpeed;
    /// <summary>
    /// Set to true when the character intersects a collider beneath
    /// them in the previous frame.
    /// </summary>
    private bool grounded;

    private void Awake()
    {
        boxCollider = GetComponent<CircleCollider2D>();
        botSpeed = speed * Random.Range(0.75f, 1.25f);
    }

    private void Update()
    {
        // Use GetAxisRaw to ensure our input is either 0, 1 or -1.
        float moveInput = Input.GetAxis("Horizontal");




        if (moveInput != 0)
        {
            velocity.x = moveInput * Time.deltaTime;
            rigidBody.velocity = velocity * botSpeed;
            

        }
        else
        {
            //velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        
        //transform.Translate(velocity * Time.deltaTime);

        

        // Retrieve all colliders we have intersected after velocity has been applied.

    }
}