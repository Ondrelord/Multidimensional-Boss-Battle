using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimHandler : MonoBehaviour
{
    Vector2 mousePosition;
    Vector2 mouseDelta;
    Vector2 mousePrevPosition;

    [SerializeField]
    private float maxDistance = 0.15f;
    [SerializeField]
    private float mouseSensitivity = 1f;

    static Vector2 mouseAimPosition;

    private void Start()
    {
        mousePrevPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseAimPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDelta = (mousePosition - mousePrevPosition) * mouseSensitivity;
        mouseAimPosition = Vector2.ClampMagnitude(new Vector2(mouseAimPosition.x + mouseDelta.x, mouseAimPosition.y + mouseDelta.y), maxDistance);
        
        mousePrevPosition = mousePosition;
    }

    public static Vector2 GetAim() => mouseAimPosition;
}
