using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI text;


    //private void Start()
    //{
    //    text = text.GetComponent<TextMeshPro>();
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Capsule"))
        {
            text.text = "Finished";
        }
    }
}
