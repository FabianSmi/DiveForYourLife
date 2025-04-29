using UnityEngine;

public class DeathArea : MonoBehaviour
{
    public bool playerHit { get; private set; }
    [SerializeField] private GameObject gameOver;

    private void Start()
    {
        playerHit = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            Time.timeScale = 0f;

            gameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
