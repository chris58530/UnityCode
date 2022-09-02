using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] string[] lines;
    [SerializeField] float textSpeed;
    private int index;
    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                nextLine();
            }else
            {
                StopAllCoroutines();
                textComponent.text = lines[index]; 
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypLine());
    }
    IEnumerator TypLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void nextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
