using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ManagerController : MonoBehaviour
{
    [SerializeField]
    private ActionBasedController _controller, _controllerTeleport;

    [SerializeField]
    private GameObject _controllerGO, _controllerTelerportGO, teleportAreas;


    // Añadimos las acciones
    void Start()
    {
        _controller.selectAction.action.started += Action_started;
        _controller.selectAction.action.canceled += Action_canceled;
    }

    // Al cancelar, volvemos quitamos el controller y activamos el controllerTeleport
    private void Action_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _controllerGO.SetActive(true);
        _controllerTelerportGO.SetActive(false);
        if(teleportAreas != null)
                teleportAreas.SetActive(false);
    }

    private void Action_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _controllerGO.SetActive(false);
        _controllerTelerportGO.SetActive(true);
        if (teleportAreas != null)
            teleportAreas.SetActive(true);
    }
}
