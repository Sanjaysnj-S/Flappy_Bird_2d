using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{



    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public int spriteIndex;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float Strength = 5f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimationSprite), 0.10f, 0.10f);
    }

    private void Update()
    {

        if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            direction = Vector3.up * Strength;
            SoundManager.instance.PlayFlap();
        }
        if (Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began)
        {
            direction = Vector3.up * Strength;
            SoundManager.instance.PlayFlap();
        }


        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

    }
    private void AnimationSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindFirstObjectByType<Gamemanager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindFirstObjectByType<Gamemanager>().IncreaseScoring();
        }
    }    
    
}
