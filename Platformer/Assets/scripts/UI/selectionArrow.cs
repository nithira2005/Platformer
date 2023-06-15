using UnityEngine;

public class selectionArrow : MonoBehaviour
{
   [SerializeField] private RectTransform[] options;
    private RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
}
