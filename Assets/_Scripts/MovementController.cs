using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add me!!

public class MovementController : MonoBehaviour
{
    private float horizontal;
    public float speed = 0.1f;
    public float jumpVelocity = 10f;
    private bool isFacingRight = false;
    private bool _jump = false;
    private BoxCollider2D boxCol2d;

    private Rigidbody2D rb2d;

    public DialogueDisplayer dialogue;
    public bool book = false;
    public bool balloon = false;
    public bool bagels = false;
    public bool stairs = false;
    public bool attic = false;
    public bool amulet = false;
    public bool amulet2 = false;
    public bool desk = false;
    
    public Animator animator;

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
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Flip();
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
            animator.SetBool("isJumping", true);
        }
        else if (IsGrounded()==true) {
            animator.SetBool("isJumping", false);
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

    void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Book"))
        {
            if (book == false)
            {
                GameObject BookObject = collider.gameObject;
                dialogue.currentDialogue = BookObject.GetComponent<BookScript>().dialogue;
                dialogue.DisplayDialogue(dialogue.currentDialogue);
                book = true;
            }
        }
        else if (collider.CompareTag("Balloon"))
        {
            if (balloon == false)
            {
                GameObject BalloonObject = collider.gameObject;
                dialogue.currentDialogue = BalloonObject.GetComponent<BalloonScript>().dialogue;
                dialogue.DisplayDialogue(dialogue.currentDialogue);
                balloon = true;
            }
        }
        else if (collider.CompareTag("Bagel"))
        {
            if (bagels == false)
            {
                GameObject BagelObject = collider.gameObject;
                dialogue.currentDialogue = BagelObject.GetComponent<BagelsScript>().dialogue;
                dialogue.DisplayDialogue(dialogue.currentDialogue);
                bagels = true;
            }
        }
        else if (collider.CompareTag("Stairs"))
        {
            if (stairs == false)
            {
                GameObject StairsObject = collider.gameObject;
                dialogue.currentDialogue = StairsObject.GetComponent<StairsScript>().dialogue;
                dialogue.DisplayDialogue(dialogue.currentDialogue);
                stairs = true;
            }
        }
        else if (collider.CompareTag("Attic"))
        {
            if (attic == false)
            {
                GameObject AtticObject = collider.gameObject;
                dialogue.currentDialogue = AtticObject.GetComponent<AtticScript>().dialogue;
                dialogue.DisplayDialogue(dialogue.currentDialogue);
                attic = true;
            }
        }
        else if (collider.CompareTag("Amulet"))
        {
            if (amulet == false)
            {
                GameObject AmuletObject = collider.gameObject;
                dialogue.currentDialogue = AmuletObject.GetComponent<AmuletScript>().dialogue;
                dialogue.DisplayDialogue(dialogue.currentDialogue);
                amulet = true;
            }
        }
        // else if (collider.CompareTag("WhiteScreen") && desk == true)
        // {
        //     GameObject WhiteScreenObject = collider.gameObject;
        //     WhiteScreenObject.SetActive(true);
        //     SceneManager.LoadScene(2);
        // }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Amulet") && Input.GetKeyDown(KeyCode.E))
        {
            if (amulet2 == false)
            {
                GameObject AmuletObject = collider.gameObject;
                dialogue.currentDialogue = AmuletObject.GetComponent<AmuletScript>().dialogue2;
                dialogue.DisplayDialogue(dialogue.currentDialogue);
                amulet2 = true;
                AmuletObject.SetActive(false);
            }
        }
        else if (collider.CompareTag("Desk") && amulet2 == true)
        {
            if (desk == false)
            {
                GameObject DeskObject = collider.gameObject;
                DeskObject.GetComponent<SpriteRenderer>().enabled = true;
                desk = true;
                // PickUpAmulet(DeskObject);
                SceneManager.LoadScene(2);
            }
        }
    }
    private IEnumerable PickUpAmulet(GameObject Desk)
    {
        Debug.Log("Testing");
        yield return new WaitForSeconds(3);
        dialogue.currentDialogue = Desk.GetComponent<DeskScript>().dialogue;
        dialogue.DisplayDialogue(dialogue.currentDialogue);
        
    }
}