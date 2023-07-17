using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //бибилиотека для того, чтобы диалог видел текст 



public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; //текст диалога  

    public Dialogue dialogue; //указываем наш диалог 

    public Animator boxAnim;

    private Queue<string> sentences; //создаем очередь наших предложений

    private void Start()
    {
        sentences = new Queue<string>(); //присваиваем преложениям новую очередь
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }

    public void StartDialogue(Dialogue dialogue) //функция, которая будет начинать наш диалог
    {
        if (boxAnim != null) // проверка, что boxAnim существует
            boxAnim.SetBool("boxOpen", true); //аниматор открывает диалог 

        sentences.Clear(); 

        foreach(string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence); //ставим в очередь каждое наше предложение
        }
         
        DisplayNextsentence();
    }

    public void DisplayNextsentence() 
    { 
        if (sentences.Count == 0) //если предложений в очереди осталось 0 
        {
            EndDialogue(); //заканчиваем диалог
            return;
        }
        string sentence = sentences.Dequeue(); //строку удаляем из очереди 
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence) //анимирует буквы в диалоге
    {
        dialogueText.text = ""; // указываем текст диалога, который находится между ковычек
        foreach(char letter in sentence.ToCharArray()) //цикл для каждой буквы в предложении
        {
            dialogueText.text += letter;
            yield return null;
        }  
    }

    public void EndDialogue() 
    {
        boxAnim.SetBool("boxOpen", false); // закрываем диалоговое окно, обращаясь к аниматору
    }



}
