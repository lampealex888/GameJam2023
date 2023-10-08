using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private float horizontal;
    public float speed = 0.25f;
    public float jumpVelocity = 10f;
    private bool isFacingRight = true;
    private bool _jump = false;
    private BoxCollider2D boxCol2d;

    private Rigidbody2D rb2d;

    public DialogueDisplayer dialogue;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("I have made my first script!");
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        // Debug.Log(horizontal);
        if ((IsGrounded() && (Input.GetKeyDown(KeyCode.UpArrow)) || (IsGrounded() && Input.GetKeyDown(KeyCode.W))))
        {
            _jump = true;
        }
    }

    // This is where you're going to put things related to physics!!
    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal;
        transform.position = position;
        rb2d = transform.GetComponent<Rigidbody2D>();
        boxCol2d = transform.GetComponent<BoxCollider2D>();
        Jump();
    }

    void Jump()
    {
        if (_jump == true)
        {
            rb2d.velocity = Vector2.up * jumpVelocity;
            _jump = false;
        }
    }

    private bool IsGrounded()
    {
        //(box origin=center, size=box collider size, angle of rotation=0, direction to move box=down, distance to move box=.1f)
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCol2d.bounds.center, boxCol2d.bounds.size, 0f, Vector2.down, .1f, 1 << 7);
        //logs what we hit, if anything
        //Debug.Log(raycastHit2d.collider.gameObject.name);
        //returns true if box collider hits something
        return (raycastHit2d.collider != null);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("hello");
        if (collider.CompareTag("Book"))
        {
            GameObject bookObject = collider.gameObject;
            dialogue.currentDialogue = bookObject.GetComponent<BookScript>().dialogue;
            dialogue.DisplayDialogue(dialogue.currentDialogue);
        }
    }
}