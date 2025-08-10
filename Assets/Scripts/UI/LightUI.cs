using UnityEngine;

public class LightUI : MonoBehaviour
{

    public RectTransform canvasRectTransform;

    private RectTransform HideBackground;

    private RectTransform LightRectTransform;

    void Awake()
    {

        LightRectTransform = GetComponent<RectTransform>();

        if (transform.childCount > 0)
        {
            HideBackground = transform.GetChild(0).GetComponent<RectTransform>();
        }
    }

    void Update()
    {
        if (canvasRectTransform != null)
        {
            Vector2 localPoint;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRectTransform,
                Input.mousePosition,
                null,
                out localPoint))
            {

                LightRectTransform.localPosition = localPoint;

                if (HideBackground != null)
                {
                    HideBackground.localPosition = -localPoint;
                }
            }
        }
    }
}

