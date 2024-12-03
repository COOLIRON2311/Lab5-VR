using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float transitionDelay = 1.0f;

    public void LoadLevel(int index)
    {
        StartCoroutine(DelayLoadLevel(index));
    }

    IEnumerator DelayLoadLevel(int index)
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelay);
        SceneManager.LoadScene(index);
    }
}
