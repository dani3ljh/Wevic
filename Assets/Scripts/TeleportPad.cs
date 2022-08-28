using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPad : MonoBehaviour
{
    [SerializeField] private Transform teleportPadB;
    private AudioManager am;
    // y offset
    [SerializeField] private float yOffset = 1.0f;
    
    private void Start() {
        // find game manager and get audio manager
        am = GameObject.FindObjectOfType<AudioManager>();
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            am.PlaySound("Teleport");
            other.gameObject.transform.position = teleportPadB.position + new Vector3(0, yOffset, 0);
        }
    }
}
