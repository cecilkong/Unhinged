using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningInput : MonoBehaviour
{
    [SerializeField] float resetPositionRight = 50f;
    [SerializeField] float resetPositionLeft = -.5f;
    [SerializeField] float sensitivity = 1f;
    [SerializeField] GameObject mainCamera;
    public bool canInput = true;

    private void Update()
    {
        if (!canInput) return;
        mainCamera.transform.position += new Vector3(Input.GetAxis("Horizontal") * sensitivity * Time.deltaTime, 0, 0);
        if (mainCamera.transform.position.x < resetPositionLeft) mainCamera.transform.position = new Vector3(resetPositionRight, 0, -10);
        if (mainCamera.transform.position.x > resetPositionRight) mainCamera.transform.position = new Vector3(resetPositionLeft, 0, -10);
    }

}
