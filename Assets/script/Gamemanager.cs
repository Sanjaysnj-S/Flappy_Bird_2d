using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Gamemanager : MonoBehaviour
{
    public float delay;
    public Text scoreText;        // UI text element
    public Player player;
    public GameObject Button;
    // game+over
    public RectTransform GameImage;
    public RectTransform OverImage;
    private Vector3 initialGameImagepos;
    private Vector3 initialOverImagepos;
    public bool animate = false;
    public float moveSpeed = 800f;
    private Vector3 gameTarget = new Vector3(-100f, 250f);
    private Vector3 overTarget = new Vector3(100f, 250f);
    private Vector2 initialGameImagePos;
    private Vector2 initialOverImagePos;
//gmae+over
    public float Speed = 500f;
    private int score = 0;        // actual score variable
    public void Replay()
    {
        Play();
    }
    private void Update()
    {
        if (animate)
        {
            GameImage.anchoredPosition = Vector3.MoveTowards(GameImage.anchoredPosition, gameTarget, moveSpeed * Time.unscaledDeltaTime);
            OverImage.anchoredPosition = Vector3.MoveTowards(OverImage.anchoredPosition, overTarget, moveSpeed * Time.unscaledDeltaTime);

            if (GameImage.anchoredPosition == (Vector2)gameTarget && OverImage.anchoredPosition == (Vector2)overTarget)
            {
                animate = false;
            }
        }
    }

    public void Start()
    {
        initialGameImagePos = new Vector3(-1000f, -10f);
        initialOverImagePos = new Vector3(1000f, 10f);

        GameImage.anchoredPosition = new Vector3(-1200f, -10f);
        OverImage.anchoredPosition = new Vector3(1200f, 10f);

        GameImage.gameObject.SetActive(false);
        OverImage.gameObject.SetActive(false);        


    }
   
    public void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        GameImage.gameObject.SetActive(false);
        OverImage.gameObject.SetActive(false);
        Button.SetActive(false);

        Time.timeScale = 1f;
        player.transform.position = new Vector3(0, 0);
        player.enabled = true;

        Pipes[] pipes = Object.FindObjectsByType<Pipes>(FindObjectsSortMode.None);


        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void IncreaseScoring()
    {
        score++;
        scoreText.text = score.ToString();

        SoundManager.instance.PlayCoin();

        
    }
    private IEnumerator ShowButtonAfterDelay(float delay)
    {
        Button.SetActive(false);
        yield return new WaitForSecondsRealtime(delay);
        Button.SetActive(true);
    }

    public void GameOver()
    {
        GameImage.anchoredPosition = initialGameImagePos;
        OverImage.anchoredPosition = initialOverImagePos;

        GameImage.gameObject.SetActive(true);
        OverImage.gameObject.SetActive(true);
        animate = true;
        
        
        StartCoroutine(ShowButtonAfterDelay(delay));
        

        Time.timeScale = 0f;

        SoundManager.instance.PlayGameOver();

    }
}
