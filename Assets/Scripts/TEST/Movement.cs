using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float moveDistance;
    private Vector3 initialPosition;
    private int direction = 1;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * direction * Time.deltaTime);
        if (Mathf.Abs(transform.position.x - initialPosition.x) > moveDistance)
        {
            direction *= -1;
        }
    }
}