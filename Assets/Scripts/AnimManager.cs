using UnityEngine;

public class AnimManager : MonoBehaviour
{
    private Animator krakenAnim;

    void Start()
    {
        krakenAnim = GetComponent<Animator>();
        krakenAnim.Play("KrakenAnim");
    }
}
