using UnityEngine;
using TMPro;

public class BoneInteraction : MonoBehaviour
{
    public string boneName;
    public TextMeshProUGUI infoText;

    private Renderer rend;
    private Color originalColor;

    private static BoneInteraction lastSelected;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void OnMouseDown()
    {
        // resetar o anterior
        if (lastSelected != null)
        {
            lastSelected.ResetColor();
        }

        // atualizar atual
        infoText.text = "Osso: " + boneName;
        rend.material.color = Color.yellow;

        lastSelected = this;
    }

    void ResetColor()
    {
        rend.material.color = originalColor;
    }
}