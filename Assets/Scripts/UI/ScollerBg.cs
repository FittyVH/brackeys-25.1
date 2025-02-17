using UnityEngine;
using UnityEngine.UI;

public class ScollerBg : MonoBehaviour
{
    [SerializeField] RawImage bg;
    [SerializeField] float x, y;
    
    void Update()
    {
        bg.uvRect = new Rect(bg.uvRect.position + new Vector2(x, y) * Time.deltaTime, bg.uvRect.size);
    }
}
