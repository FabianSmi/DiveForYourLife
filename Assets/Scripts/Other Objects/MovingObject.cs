using UnityEngine;

public class MovingObject : MonoBehaviour
{
    Transform _transform;
    [SerializeField] float moveSpeed = -1f;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _transform.position += new Vector3(_transform.position.x, moveSpeed * Time.deltaTime);
    }
}
