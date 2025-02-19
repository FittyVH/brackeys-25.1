using UnityEngine;

public class GoalReducesSize : MonoBehaviour
{
    private Vector3 targetScale = new Vector3(1.09290886f, 1.09290886f, 1.09290886f);
    private float shrinkSpeed = 3f;
    private bool isShrinking = false; // Ensure shrinking starts only once

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Capsule") && !isShrinking)
        {
            isShrinking = true; // Prevent multiple calls
            StartCoroutine(ShrinkOverTime());
        }
    }

    private System.Collections.IEnumerator ShrinkOverTime()
    {
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * shrinkSpeed);
            yield return null; // Wait for the next frame
        }

        transform.localScale = targetScale; // Ensure exact target size
    }
}
