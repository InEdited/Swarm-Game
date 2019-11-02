using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 9;

    public SwarmCounter counterObject;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 75;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 70;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    float jumpHeight = 4;

    public Rigidbody2D rigidBody;

    public bool isActivated;

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
        botSpeed = speed * Random.Range(0.9f, 1.1f);
  
    }

    private void Start() {
        counterObject = GameObject.Find("SwarmCounter").GetComponent<SwarmCounter>();
    }


    private void Update()
    {
        // Use GetAxisRaw to ensure our input is either 0, 1 or -1.
        float moveInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetKeyDown(KeyCode.Space);



        if (isActivated)
        {
            if (moveInput != 0)
            {
                rigidBody.velocity = new Vector2(botSpeed * moveInput * Time.deltaTime, rigidBody.velocity.y);
            }
            else
            {
                //velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            }

            if (jumpInput) {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight * counterObject.counter));
            }
        }
        
        //transform.Translate(velocity * Time.deltaTime);

        

        // Retrieve all colliders we have intersected after velocity has been applied.

    }
}