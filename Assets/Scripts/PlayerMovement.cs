using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform[] feet;
    
    [SerializeField] private AudioManager am;
    
    private Rigidbody2D rb;
    private GameManager gm;
    private Animator anim;
    
    private bool isInAir = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        Debug.Log($"IsInAir: {anim.GetBool("isInAir")}\n IsWalk: {anim.GetBool("IsWalking")}");
        
        if(isInAir){
            if(IsGrounded()){
                isInAir = false;
                anim.SetBool("IsInAir", false);
            }
        }
        
        float x = Input.GetAxisRaw("Horizontal");
        
        anim.SetBool("IsWalking", x != 0);
        
        if(x != 0){
            transform.localScale = new Vector3(x > 0 ? 1 : -1, 1, 1);
        }
        
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump"))
        {
            bool isGrounded = IsGrounded();
            if (isGrounded)
            {
                //add jump force to the rigidbody
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isInAir = true;
                anim.SetBool("IsJumping", true);
                am.PlaySound("Jump");
            }
        }
    }
    
    private bool IsGrounded()
    {
        // Check if the player is on the ground
        bool isGrounded = false;
        foreach(Transform foot in feet)
        {
            isGrounded = Physics2D.Raycast(foot.position, Vector2.down, 0.1f, groundLayer).collider != null;
        }
        return isGrounded;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Kill Player"))
        {
            //gm.KillPlayer();
            gm.KillPlayer();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            GameObject[] objects = other.gameObject.GetComponent<ToggleButton>().objectsToToggle;
            bool toggleOn = other.gameObject.GetComponent<ToggleButton>().toggleOn;
            
            foreach (GameObject obj in objects)
            {
                obj.SetActive(toggleOn);
            }
        }
    }
}
