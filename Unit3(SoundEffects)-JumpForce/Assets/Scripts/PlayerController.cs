using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public bool doubleJump = false;
    public bool doubleSpeed = false;
    public float gravityModifier;
    public bool isOnGround = true;
    
    // Variables for the game over
    public bool gameOver = false;
    public GameObject GameOverPanel;

    // Variable for the animation
    private Animator playerAnim;

    // Variables for the particles
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    // Variables for the sound effects
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        // Rigid body of our player
        playerRb = GetComponent<Rigidbody>();
        // Animation of our player
        playerAnim = GetComponent<Animator>();
        //Change the gravity of our physics
        Physics.gravity *= gravityModifier;
        // Sfx of our player's moves.
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // The player is on the ground, and it will jump everytime the user presses the space bar
        // However when the player is on the gound but already dead, it will not jump even the player presses the space bar
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !doubleJump && !gameOver)
        {
            // Apply an immediate force to our player
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            // When the player jumps, trigger the jump
            playerAnim.SetTrigger("Jump_trig");
            // Stop the dirt particle animation when the player is jumping
            dirtParticle.Stop();
            // Play the jump sfx every time the player jumps
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        // The player is not on the ground, and it will cause a double jump if the user presses the space bar
        // However when the player is on the gound but already dead, it will not jump even the player presses the space bar twice
        else if (Input.GetKeyDown(KeyCode.Space) && isOnGround == false && !doubleJump && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            doubleJump = true;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }

        // if the user press the left shift, the player will dash or will set the doubleSpeed boolean into true
        if (Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = true;
            playerAnim.SetFloat("Speed_Multiplier", 2.0f);
        }

        else if (doubleSpeed)
        {
            doubleSpeed = false;
            playerAnim.SetFloat("Speed_Multiplier", 1.0f);
        }
    }
    // Detect collisions from the ground
    private void OnCollisionEnter(Collision collision)
    {
        // Trigger a game over
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            doubleJump = false;
            // Play the dirt particle animation when the player is running
            dirtParticle.Play();
        }
        // Detect collisions from the object
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            // Set the animation when the player dies
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            // Explosion animates when the player dies
            explosionParticle.Play();
            // Stop the dirt particle animation when the player dies
            dirtParticle.Stop();
            // Play the crash sound when the player dies
            playerAudio.PlayOneShot(crashSound, 1.0f);
            // Display a "Game Over" when the player dies
            GameOverPanel.SetActive(true);

        }
    }
}
