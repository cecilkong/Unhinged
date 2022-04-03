using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningInput : MonoBehaviour
{
    [SerializeField] float limitRight = 50f;
    [SerializeField] float limitLeft = -.5f;
    [SerializeField] float sensitivity = 1f;
    [SerializeField] GameObject mainCamera;
    public bool canInput = true;

    private void Update()
    {
        if (!canInput) return;
        if (!(Input.GetAxis("Horizontal") < 0 && mainCamera.transform.position.x <= limitLeft) && !(Input.GetAxis("Horizontal") > 0 && mainCamera.transform.position.x >= limitRight))
        {
            mainCamera.transform.position += new Vector3(Input.GetAxis("Horizontal") * sensitivity * Time.deltaTime, 0, 0);
        }
    }

}
