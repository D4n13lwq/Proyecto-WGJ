using TMPro;
using UnityEngine;

public class ChangeButtonTextColor : MonoBehaviour
{
    [SerializeField] Color selectedColor;
    [SerializeField] Color baseColor;
    TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ChangeColorToSelect()
    {
        textMeshProUGUI.color = selectedColor;
    }

    public void ChangeColorToUnselect()
    {
        textMeshProUGUI.color = baseColor;
    }

    private void OnDisable()
    {
        ChangeColorToUnselect();
    }
}
