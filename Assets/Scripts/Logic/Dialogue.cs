using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI Speaker;
    public TextMeshProUGUI Speaking;
    public GameObject dialogueObject;
    AudioSource src;
    public List<string> lines;
    [SerializeField]
    float textSpeed;

    private int index;
    [SerializeField]
    private float textTimeout;

    [SerializeField]
    string currentDialogue;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        textTimeout = 0;
        dialogueObject = GameObject.Find("/Dialogue");
        Speaker.text = string.Empty;
        Speaking.text = string.Empty;
        currentDialogue = dialogueObject.GetComponent<DialoguePrompt>().GetDialogue();
        src = GetComponent<AudioSource>();

        FileInfo dialogueFile = new FileInfo("Assets\\Dialogue\\" + currentDialogue + ".txt");
        StreamReader reader = dialogueFile.OpenText();

        lines = new List<string>();

        for (string text = reader.ReadLine(); text != null; text = reader.ReadLine())
            lines.Add(text);

        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        textTimeout += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || textTimeout > 2.5)
        {
            if (Speaking.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                Speaking.text = lines[index];
            }
            textTimeout = 0;
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        Speaker.text += lines[index];
        index++;

        foreach (char c in lines[index].ToCharArray())
        {
            Speaking.text += c;
            src.Play();
            yield return new WaitForSeconds(textSpeed);
            textTimeout = 0;
        }
    }

    void NextLine()
    {
        if (index < lines.Count - 1)
        {
            index++;
            Speaker.text = string.Empty;
            Speaking.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Speaker.text = string.Empty;
            Speaking.text = string.Empty;
            lines.Clear();
            dialogueObject.GetComponent<DialoguePrompt>().SetDialogue("");
            gameObject.SetActive(false);
        }
    }
}