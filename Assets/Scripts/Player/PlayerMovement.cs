using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;

    Vector2 _velocity;

    Rigidbody2D _rigidbody2D;

    GameInput gameInput;
    InputAction move;
    InputAction skillcheck;

    [SerializeField] GameObject pauseCanvas;

    private bool gamePaused = false;

    private void Awake()
    {
        gameInput = new GameInput();
        move = gameInput.Player.Move;
        skillcheck = gameInput.Player.Skillcheck;
    }

    void OnEnable()
    {
        gameInput.Player.Enable();
    }

    void OnDisable()
    {
        gameInput.Player.Disable();
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Movement();
        GamePause();
    }

    private void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            Time.timeScale = 0f;
            pauseCanvas.SetActive(true);
            gamePaused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            Time.timeScale = 1f;
            pauseCanvas.SetActive(false);            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gamePaused = false;
        }
    }

    void Movement()
    {
        _velocity.x = move.ReadValue<float>() * moveSpeed;

        if (move.WasPerformedThisFrame())
        {
            _velocity.y = _rigidbody2D.linearVelocity.y;
        }
        if (skillcheck.WasCompletedThisFrame())
        {
            // Skillcheck Methode
            Debug.Log("Skillcheck");
        }

        _rigidbody2D.linearVelocity = _velocity;
    }

}