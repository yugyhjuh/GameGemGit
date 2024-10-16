using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public GameObject continueButton;

    public float wordSpeed;
    public bool playerIsClose;

    private Animator animator;
    public float rotationSpeed = 6.0f * 360f;
    public bool runSpin = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsClose)
        {
            if (Input.GetKeyDown(KeyCode.E) && runSpin == false)
            {
                if (dialoguePanel.activeInHierarchy)
                {
                    zeroText();
                }
                else
                {
                    dialoguePanel.SetActive(true);
                    StartCoroutine(Typing());
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) && runSpin == true)
            {
                //runSpin = false;
                SceneManager.LoadSceneAsync(6);
            }
            
        }

        if (dialogueText.text == dialogue[index])
        {
            if (dialogueText.text == dialogue[5])
            {
                continueButton.GetComponentInChildren<Text>().text = "Scissors!";
            }
            else if (dialogueText.text == dialogue[6])
            {
                continueButton.GetComponentInChildren<Text>().text = "...";
                runSpin = true;
            }
            continueButton.SetActive(true);
        }

        if (runSpin == true)
        {
            transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
        }

        // Apply glow effect when player is close
        if (playerIsClose)
        {
            animator.enabled = true;
        }
        else
        {
            ResetAnimation();
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        continueButton.SetActive(false);

        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
    private void ResetAnimation()
    {
        // Disable the animator
        animator.enabled = false;

        // Reset the animation to the initial frame (time 0 of the current state)
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, -1, 0f);

        // Force the animator to update, so the reset takes effect immediately
        animator.Update(0f);
    }
}
