using UnityEngine;

public class WinArea : MonoBehaviour
{
    public bool winCon{ get; private set; }

    private void Awake()
    {
        winCon = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            winCon = true;
        }
    }
}
