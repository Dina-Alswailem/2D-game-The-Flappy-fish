using System.Drawing;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    private float moveSpeed = 0.08f;        
    private float verticalForce = 5f;   
    private Rigidbody2D rb;
    public GameObject gameManagerObject;  
    public AudioClip gameOverSound;
    private AudioSource audioSource;

    private GameManager gameManager;

    private string SELECTED_CHARACTER_HIXA = "HixaCharacter";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

  
        gameManager = gameManagerObject.GetComponent<GameManager>();
       
         audioSource = GetComponent<AudioSource>();

        if (ColorUtility.TryParseHtmlString(PlayerPrefs.GetString(SELECTED_CHARACTER_HIXA), out UnityEngine.Color color))
            GetComponent<SpriteRenderer>().color = color;
       
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            rb.velocity = Vector2.up * verticalForce;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
                audioSource.PlayOneShot(gameOverSound);
                gameManager.GameOver();  
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Pipe>(out _))
        {
            gameManager.pipe++;
        }
    }
}
