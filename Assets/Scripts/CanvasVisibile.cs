using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasVisibile : MonoBehaviour
{
    [SerializeField]
    private CanvasManager canvasManager;

    private void OnEnable()
    {
        canvasManager.InicializaInventario();
    }
}
