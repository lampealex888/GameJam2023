using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add me!!

public class PlayerData : MonoBehaviour
{
    public DialogueDisplayer dialogue;
    // L1 variables
    private bool book = false;
    private bool balloon = false;
    private bool bagels = false;
    private bool stairs = false;
    private bool attic = false;
    private bool amulet = false;
    private bool amulet2 = false;
    private bool desk = false;
    public bool ability_unlocked = false;
    // L2 variables
    private bool start = false;
    private bool keypad = false;
    private bool doorAClosed = false;
    private bool doorAOpen = false;

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
        else if (collider.CompareTag("L2Start"))
        {
            if (start == false)
            {
                GameObject L2StartObject = collider.gameObject;
                dialogue.currentDialogue = L2StartObject.GetComponent<L2StartScript>().dialogue;
                dialogue.DisplayDialogue(dialogue.currentDialogue);
                start = true;
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
                ability_unlocked = true;
                this.GetComponent<MovementController>().IsOldMan = true;
                SceneManager.LoadScene(2);
            }
        }
        // TODO: ADD CHECK IF PLAYER IS OLD
        else if (collider.CompareTag("Keypad") && Input.GetKeyDown(KeyCode.E) && this.GetComponent<MovementController>().IsOldMan == true)
        {
            if (keypad == false)
            {
                keypad = true;
            }
        }
        else if (collider.CompareTag("DoorAClosed") && keypad == true && Input.GetKeyDown(KeyCode.E))
        {
            if (doorAClosed == false)
            {
                GameObject DoorAClosedObject = collider.gameObject;
                DoorAClosedObject.GetComponent<SpriteRenderer>().enabled = false;
                doorAClosed = true;
            }
        }
        else if (collider.CompareTag("DoorAOpen") && doorAClosed == true)
        {
            if (doorAOpen == false)
            {
                GameObject DoorAOpenObject = collider.gameObject;
                DoorAOpenObject.GetComponent<SpriteRenderer>().enabled = true;
                doorAOpen = true;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                this.transform.position = new Vector3(28.23f, -2.7f, 0);
            }
        }
    }
}