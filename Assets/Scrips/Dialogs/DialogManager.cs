using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public Text nameText;

    public Animator boxAnimator;
    public Animator startAnimator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        startAnimator.SetBool("startOpen", false);
    }

    public void StartDialog(Dialog dialog)
    {
        boxAnimator.SetBool("boxOpen", true);
        startAnimator.SetBool("startOpen", false);

        nameText.text = dialog.name;
        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSenrence();
    }

    public void DisplayNextSenrence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentece(sentence));
    }

    IEnumerator TypeSentece(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    public void EndDialog()
    {
        boxAnimator.SetBool("boxOpen", false);
    }
}
