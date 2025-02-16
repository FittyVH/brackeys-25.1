using UnityEngine;

public class MovingHazard : MonoBehaviour
{
    [SerializeField] private Transform posA, posB;
    [SerializeField] private float speed;
    private Vector2 targetPos;
    private Vector3 playerPos = new Vector3(-63.2999992f, -33.5999985f, 0f);

    void Start()
    {
        targetPos = posB.position;
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(posA.position, posB.position);
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            targetPos = (targetPos == (Vector2)posA.position) ? posB.position : posA.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = playerPos;
        }
    }
}
