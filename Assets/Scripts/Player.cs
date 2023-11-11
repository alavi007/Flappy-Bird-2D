using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private float jumpForce = 8f;
    private float gravityModifer = 2f;

    private Vector3 initialPosition;
    
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip scoreSound;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        initialPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);

        playerRb = GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityModifer;

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            playerRb.velocity = new Vector2 (playerRb.velocity.x, jumpForce);
            playerAudio.PlayOneShot(jumpSound, 0.5f);
        }
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length){
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites [spriteIndex];
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacles")
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
            FindObjectOfType<GameManager>().GameOver();
        } 
        else if (other.gameObject.tag == "Scoring")
        {
            playerAudio.PlayOneShot(scoreSound, 1.0f);
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

    public void ResetPlayerPosition()
    {
        transform.position = initialPosition; // Reset the player's position to the initial position.
        playerRb.velocity = Vector2.zero; // Reset the player's velocity.
        spriteIndex = 0; // Reset the sprite index.
        spriteRenderer.sprite = sprites[spriteIndex]; // Reset the sprite.
    }
}
