using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAnimator : MonoBehaviour
{
    public Animator startAnimator;
    public DialogManager dialogManager;

    private void Start()
    {
        startAnimator.SetBool("startOpen", false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        startAnimator.SetBool("startOpen", true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        startAnimator.SetBool("startOpen", false);
        dialogManager.EndDialog();
    }
}
