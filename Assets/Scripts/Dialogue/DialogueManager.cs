using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //����������� ��� ����, ����� ������ ����� ����� 



public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; //����� �������  

    public Dialogue dialogue; //��������� ��� ������ 

    public Animator boxAnim;

    private Queue<string> sentences; //������� ������� ����� �����������

    private void Start()
    {
        sentences = new Queue<string>(); //����������� ����������� ����� �������
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }

    public void StartDialogue(Dialogue dialogue) //�������, ������� ����� �������� ��� ������
    {
        if (boxAnim != null) // ��������, ��� boxAnim ����������
            boxAnim.SetBool("boxOpen", true); //�������� ��������� ������ 

        sentences.Clear(); 

        foreach(string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence); //������ � ������� ������ ���� �����������
        }
         
        DisplayNextsentence();
    }

    public void DisplayNextsentence() 
    { 
        if (sentences.Count == 0) //���� ����������� � ������� �������� 0 
        {
            EndDialogue(); //����������� ������
            return;
        }
        string sentence = sentences.Dequeue(); //������ ������� �� ������� 
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence) //��������� ����� � �������
    {
        dialogueText.text = ""; // ��������� ����� �������, ������� ��������� ����� �������
        foreach(char letter in sentence.ToCharArray()) //���� ��� ������ ����� � �����������
        {
            dialogueText.text += letter;
            yield return null;
        }  
    }

    public void EndDialogue() 
    {
        boxAnim.SetBool("boxOpen", false); // ��������� ���������� ����, ��������� � ���������
    }



}
