using UnityEngine;

public class TankScript : MonoBehaviour
{
    Rigidbody2D m_rg;
    [SerializeField] GameObject player;

    ParticleSystem p_bubble;

    private bool destroyed = false;
    [SerializeField] float _offset;



    private void Start()
    {
        m_rg = GetComponent<Rigidbody2D>();
        Transform transform = GetComponent<Transform>();
        p_bubble = GetComponentInChildren<ParticleSystem>();
    }
    private void Update()
    {
        if (!destroyed)
            transform.position = new Vector3(player.transform.position.x + _offset, player.transform.position.y);
    }


    public void LoseTank()
    {
        p_bubble.Play();
        destroyed = true;
        m_rg.gravityScale = .2f;
        Debug.Log("Lose Tank");
        Invoke(nameof(DestroyObj), 8f);

    }
    private void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
