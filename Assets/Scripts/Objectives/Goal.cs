using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Goal : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector2[] targetPosition = {
        new Vector2(-58.336998f, 17.1000004f),
        new Vector2(-48.9099998f,14.1000004f),
        new Vector2(-68.0100021f,22.7000008f)
    };

    public TextMeshProUGUI text;
    private bool isDetected = false;
    private int currentTargetIndex = -1;


    private void FixedUpdate()
    {
        if (isDetected && currentTargetIndex < targetPosition.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition[currentTargetIndex], speed * Time.deltaTime);

            if ((Vector2)transform.position == targetPosition[currentTargetIndex])
            {
                isDetected = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Capsule"))
        {
            isDetected = true;
            currentTargetIndex++;

            if (currentTargetIndex >= targetPosition.Length)
            {
                text.text = "Finished";
            }
        }
    }
}
