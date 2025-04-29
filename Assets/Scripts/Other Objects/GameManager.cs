using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    OxygenHandler _oxygenHandler;
    WinArea _winArea;

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject winGame;
    [SerializeField] private GameObject deathGame;


    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _oxygenHandler = FindAnyObjectByType<OxygenHandler>();
        _winArea = FindAnyObjectByType<WinArea>();

        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (gameOver != null && winGame != null)
        {
            if (_oxygenHandler.currentOxygen <= 0)
            {
                GameOver();
            }
            else if (_winArea.winCon == true)
            {
                WonGame();
            }
        }
    }

    public void WonGame()
    {
        winGame.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        gameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
