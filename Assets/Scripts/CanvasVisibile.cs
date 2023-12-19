using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasVisibile : MonoBehaviour
{
    [SerializeField]
    private CanvasManager canvasManager;

    [SerializeField]
    private GameObject cameraGO;

    [SerializeField]
    private float offset;

    private void OnEnable()
    {
        transform.localPosition = cameraGO.transform.forward * offset;
        transform.LookAt(cameraGO.transform.position,Vector3.up);
        canvasManager.InicializaInventario();
    }


    private void OnDisable()
    {
        canvasManager.QuitEvents();
    }
}
