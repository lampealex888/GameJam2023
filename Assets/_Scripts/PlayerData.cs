using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add me!!

public class PlayerData : MonoBehaviour
{
    public DialogueDisplayer dialogue;
    // Opener variables
    private bool openerStart = false;
    private bool openerEnd = false;
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
    private bool end = false;
    // L3 variables
    private bool L3start = false;
    private bool L3end = false;
    private bool leverOff = false;
    private bool L3DoorAClosed = false;
    private bool L3DoorAOpen = false;
    // L4 variables
    private bool L4start = false;
    private bool L4end = false;
    // L5 variables
    private bool L5start = false;
    private bool L5end = false;


    public GameObject box1;
    public GameObject box2;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Opener collisions
        if (collider.CompareTag("OpenerEnd"))
        {
            if (openerEnd == false)
            {
                GameObject OpenerEndObject = collider.gameObject;
                dialogue.currentDialogue = OpenerEndObject.GetComponent<OpenerEnd>().dialogue;
                dialogue.DisplayDialogue(dialogue.currentDialogue);
                openerEnd = true;
                SceneManager.LoadScene(2);
            }
        }
        // L1 collisions
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
        // L2 collisions
        if (collider.CompareTag("L2End"))
        {
            if (end == false)
            {
                // GameObject L2EndObject = collider.gameObject;
                // dialogue.currentDialogue = L2EndObject.GetComponent<L2End>().dialogue;
                // dialogue.DisplayDialogue(dialogue.currentDialogue);
                end = true;
                SceneManager.LoadScene(4);
            }
        }
        // else if (collider.CompareTag("WhiteScreen") && desk == true)
        // {
        //     GameObject WhiteScreenObject = collider.gameObject;
        //     WhiteScreenObject.SetActive(true);
        //     SceneManager.LoadScene(2);
        // }
        // L3 collisions
        else if (collider.CompareTag("L3End"))
        {
            if (L3end == false)
            {
                // GameObject L2EndObject = collider.gameObject;
                // dialogue.currentDialogue = L2EndObject.GetComponent<L2End>().dialogue;
                // dialogue.DisplayDialogue(dialogue.currentDialogue);
                L3end = true;
                SceneManager.LoadScene(5);
            }
        }
        // L4 collisions
        else if (collider.CompareTag("L4End"))
        {
            if (L4end == false)
            {
                // GameObject L2EndObject = collider.gameObject;
                // dialogue.currentDialogue = L2EndObject.GetComponent<L2End>().dialogue;
                // dialogue.DisplayDialogue(dialogue.currentDialogue);
                L4end = true;
                SceneManager.LoadScene(6);
            }
        }
        // L5 collisions
        else if (collider.CompareTag("L5End"))
        {
            if (L5end == false)
            {
                // GameObject L2EndObject = collider.gameObject;
                // dialogue.currentDialogue = L2EndObject.GetComponent<L2End>().dialogue;
                // dialogue.DisplayDialogue(dialogue.currentDialogue);
                L5end = true;
                SceneManager.LoadScene(7);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        // Opener collisions
        if (collider.CompareTag("OpenerStart"))
        {
            if (openerStart == false)
            {
                GameObject OpenerStartObject = collider.gameObject;
                dialogue.currentDialogue = OpenerStartObject.GetComponent<OpenerStart>().dialogue;
                dialogue.DisplayDialogue(dialogue.currentDialogue);
                openerStart = true;
            }
        }
        // L1 collisions
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
                SceneManager.LoadScene(3);
            }
        }
        // L2 collisions
        if (collider.CompareTag("L2Start"))
        {
            if (start == false)
            {
                GameObject L2StartObject = collider.gameObject;
                dialogue.currentDialogue = L2StartObject.GetComponent<L2StartScript>().dialogue;
                dialogue.DisplayDialogue(dialogue.currentDialogue);
                start = true;
                ability_unlocked = true;
                this.GetComponent<MovementController>().IsOldMan = true;
            }
        }
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
        // L3 collisions
        if (collider.CompareTag("L3Start"))
        {
            if (L3start == false)
            {
                // GameObject L2StartObject = collider.gameObject;
                // dialogue.currentDialogue = L2StartObject.GetComponent<L2StartScript>().dialogue;
                // dialogue.DisplayDialogue(dialogue.currentDialogue);
                L3start = true;
                ability_unlocked = true;
            }
        }
        else if (collider.CompareTag("LeverOff") && Input.GetKeyDown(KeyCode.E) && this.GetComponent<MovementController>().IsOldMan == true)
        {
            if (leverOff == false)
            {
                // GameObject L2StartObject = collider.gameObject;
                // dialogue.currentDialogue = L2StartObject.GetComponent<L2StartScript>().dialogue;
                // dialogue.DisplayDialogue(dialogue.currentDialogue);
                GameObject leverOffObject = collider.gameObject;
                leverOffObject.GetComponent<SpriteRenderer>().enabled = false;
                leverOff = true;

            }
            if (leverOff == true){
                box1.SetActive(false);
                box2.SetActive(false);
            }
        }
        else if (collider.CompareTag("LeverOn"))
        {
            if (leverOff == true)
            {
                // GameObject L2StartObject = collider.gameObject;
                // dialogue.currentDialogue = L2StartObject.GetComponent<L2StartScript>().dialogue;
                // dialogue.DisplayDialogue(dialogue.currentDialogue);
                GameObject leverOffObject = collider.gameObject;
                leverOffObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (collider.CompareTag("L3DoorAClosed") && leverOff == true && L3DoorAClosed == false && Input.GetKeyDown(KeyCode.E))
        {
            if (L3DoorAClosed == false)
            {
                GameObject L3DoorAClosedObject = collider.gameObject;
                L3DoorAClosedObject.GetComponent<SpriteRenderer>().enabled = false;
                L3DoorAClosed = true;
            }
        }
        else if (collider.CompareTag("L3DoorAOpen") && L3DoorAClosed == true)
        {
            if (L3DoorAOpen == false)
            {
                GameObject L3DoorAOpenObject = collider.gameObject;
                L3DoorAOpenObject.GetComponent<SpriteRenderer>().enabled = true;
                L3DoorAOpen = true;
            }
            else if (L3DoorAOpen == true && Input.GetKeyDown(KeyCode.E))
            {
                this.transform.position = new Vector3(5.514f, -4.176f, 0);
            }
            
        }
        else if (collider.CompareTag("CorrectPlate") && this.GetComponent<MovementController>().IsOldMan == false){
            this.transform.position = new Vector3(39.99f, -12.09f, 0);
        }
        // L4 collisions
        if (collider.CompareTag("L4Start"))
        {
            if (L4start == false)
            {
                // GameObject L2StartObject = collider.gameObject;
                // dialogue.currentDialogue = L2StartObject.GetComponent<L2StartScript>().dialogue;
                // dialogue.DisplayDialogue(dialogue.currentDialogue);
                L4start = true;
                ability_unlocked = true;
            }
        }
        // L5 collisions
        if (collider.CompareTag("L5Start"))
        {
            if (L5start == false)
            {
                // GameObject L2StartObject = collider.gameObject;
                // dialogue.currentDialogue = L2StartObject.GetComponent<L2StartScript>().dialogue;
                // dialogue.DisplayDialogue(dialogue.currentDialogue);
                L5start = true;
                ability_unlocked = true;
            }
        }
    }
}