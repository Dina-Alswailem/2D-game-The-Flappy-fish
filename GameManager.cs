using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private string selectedLevel;

    public GameObject gameOverCanvas;
    public GameObject winCanvas;
    public Text timerText;
    public Text coins;
    public Text pipeText;
    public int pipe;

    public AudioClip gameOverSound;
    public AudioClip winSound;

    public float winTime = 60f;
    private float elapsedTime = 0f;
    private bool gameWon = false;
    private bool gameOver = false;
    private int currentLevelIndex;


    private AudioSource audioSource;

    

    void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        audioSource = GetComponent<AudioSource>();


        selectedLevel = "LevelOne";

        elapsedTime = 0f;
        gameWon = false;
        gameOver = false;

        if (timerText != null)
        {
            timerText.text = FormatTime(winTime);
        }
    }

    void Update()
    {
        if (!gameOver && !gameWon)
        {
            elapsedTime += Time.deltaTime;

            float remainingTime = Mathf.Max(winTime - elapsedTime, 0);
            timerText.text = FormatTime(remainingTime);
            if (remainingTime <= 0)
            {
                Win();
            }

            if(coins != null)
            {
                coins.text = $"Coins : {DataManager.Instance.coins}";
            }

            if(pipeText != null)
            {
                pipeText.text = pipe.ToString();
            }
        }
        else
        {
            coins.text = "";
            pipeText.text = "";
        }
    }


    public void LoadNextLevel()
    {
        int nextLevelIndex = currentLevelIndex + 1;

        Time.timeScale = 1;
        SceneManager.LoadScene(nextLevelIndex);

    }
    public void SelectLevelOne()
    {
        selectedLevel = "LevelOne";
    }

    public void SelectLevelTwo()
    {
        selectedLevel = "LevelTwo";
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(selectedLevel);

    }

    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;

            PlaySound(gameOverSound);
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
        }
    }

    public void Win()
    {
        if (!gameWon)
        {
            gameWon = true;

            winCanvas.SetActive(true);
            PlaySound(winSound);
            Time.timeScale = 0;
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    private string FormatTime(float time)
    {
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}", seconds);
    }
}
