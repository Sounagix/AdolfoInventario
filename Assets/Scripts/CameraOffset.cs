using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este Script sirve para desplazar correctamente la cámara cuando el jugador se ponga las gafas
public class CameraOffset : MonoBehaviour
{

#if UNITY_EDITOR
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = Vector3.up * 1.7f; 
    }

#endif
}
