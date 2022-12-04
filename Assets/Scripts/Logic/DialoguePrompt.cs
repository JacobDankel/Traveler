using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePrompt : MonoBehaviour
{
    [SerializeField]
    string currentDialogue;

    public GameObject DialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        DialogueBox = GameObject.Find("/Dialogue").transform.Find("DialogueBox").gameObject;
        currentDialogue = "";
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P))
            SetDialogue("JT-CEO1");*/

        if (currentDialogue != "")
            if (!DialogueBox.activeSelf)
                DialogueBox.SetActive(true);

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
