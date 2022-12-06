using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePrompt : MonoBehaviour
{
    [SerializeField]
    string currentDialogue;

    public GameObject DialogueBox;

    public bool dialogueRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        DialogueBox = GameObject.Find("/Dialogue").transform.Find("DialogueBox").gameObject;
        currentDialogue = ""; 
        SetDialogue("JT-CEO1");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDialogue != "")
            if (!DialogueBox.activeSelf)
            {
                DialogueBox.SetActive(true);
                dialogueRunning = true;
            }


    }

    public string GetDialogue()
    {
        return currentDialogue;
    }

    public void SetDialogue(string fileName)
    {
        currentDialogue = fileName;
    }

    //GameObject.Find("/Dialogue").GetComponent<DialoguePrompt>().SetDialogue("Insert File Name Here(without .txt)");
}
