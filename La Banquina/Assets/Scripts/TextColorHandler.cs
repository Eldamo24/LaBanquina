using TMPro;
using UnityEngine;

public class TextColorHandler : MonoBehaviour
{
    public TMP_Text targetText;
    private void Start()
    {
        targetText = GetComponentInChildren<TMP_Text>();
    }

    public void SetColor()
    {
        if (targetText != null)
        {
            targetText.color = Color.red;
        }
    }

    public void SetExitColor()
    {
        if (targetText != null)
        {
            targetText.color = Color.black;
        }
    }

    private void OnDisable()
    {
        if (targetText != null)
        {
            targetText.color = Color.black;
        }
    }
}

