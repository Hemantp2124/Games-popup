using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox; // Corrected the type name

    Message[] currentMeassages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;


     public void openDialogue(Message[] messages, Actor[] actors)
    {
        currentMeassages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started conversation! Loaded messages:" + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f);
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMeassages [activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.Sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMeassages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation ended!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInExpo();
            isActive = false;
        }

    }

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }
}
