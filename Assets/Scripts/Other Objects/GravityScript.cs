using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour
{
    Rigidbody2D r_mb;

    [SerializeField] float gravityObject = 0.2f;
    [SerializeField] float timer = 5f;

    private void Start()    {

        r_mb = GetComponent<Rigidbody2D>();
        r_mb.gravityScale = 0f;
       StartCoroutine(DisableCutBar());

        IEnumerator DisableCutBar()
        {
            r_mb.gravityScale = 0f;
            yield return new WaitForSeconds(timer);
            r_mb.gravityScale = gravityObject;
        }
    }
}
