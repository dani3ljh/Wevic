using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string nextScene;
    
    [SerializeField] private GameObject Blue;
    [SerializeField] private GameObject Red;
    
    private bool isPlaying = true;
    private AudioManager am;
    
    private bool isBlueFinshed = false;
    private bool isRedFinshed = false;
    
    private void Start() {
        am = gameObject.GetComponent<AudioManager>();
    }
    
    public void KillPlayer(){
        if(!isPlaying) return;
        isPlaying = false;
        float soundTime = am.PlaySound("Death");
        Destroy(Blue);
        Destroy(Red);
        Invoke(nameof(RestartScene), soundTime);
    }
    
    private void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void WinGame(bool isBlue){
        if(isBlue ? isRedFinshed : isBlueFinshed) {
            SceneManager.LoadScene(nextScene);
            return;
        }
        if(isBlue){
            isBlueFinshed = true;
            Destroy(Blue);
        } else {
            isRedFinshed = true;
        }
    }
}
