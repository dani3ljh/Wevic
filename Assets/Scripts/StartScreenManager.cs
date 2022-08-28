using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private string firstScene;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private Button creditButton;
    [SerializeField] private Button backButton;
    
    private Animator anim;
    
    private void Start()
    {
        anim = creditsPanel.GetComponent<Animator>();
        backButton.interactable = false;
        creditButton.interactable = true;
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(firstScene);
    }
    
    public void OpenCredits()
    {
        creditButton.interactable = false;
        anim.SetTrigger("Rise");
        backButton.interactable = true;
    }
    
    public void CloseCredits()
    {
        backButton.interactable = false;
        anim.SetTrigger("Fall");
        creditButton.interactable = true;
    }
}
