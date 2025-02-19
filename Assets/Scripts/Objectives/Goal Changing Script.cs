using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class GoalChangingScript : MonoBehaviour
{
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    private bool hasChanged = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Capsule") && !hasChanged)
        {
            hasChanged = true;
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        if(newSprite != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
