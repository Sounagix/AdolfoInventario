using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ManagerController : MonoBehaviour
{
    [SerializeField]
    private ActionBasedController _controller, _controllerTeleport;

    [SerializeField]
    private GameObject _controllerGO, _controllerTelerportGO, teleportAreas, menuInventarioGO;


    // Añadimos las acciones
    void Start()
    {
        _controller.selectAction.action.started += Action_started;
        _controller.selectAction.action.canceled += Action_canceled;
    }

    // Al cancelar, volvemos quitamos el controller y activamos el controllerTeleport
    private void Action_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(_controllerGO)
            _controllerGO.SetActive(true);
        if(_controllerTelerportGO)
            _controllerTelerportGO.SetActive(false);
        if(teleportAreas != null)
                teleportAreas.SetActive(false);
        if (menuInventarioGO != null)
            menuInventarioGO.SetActive(false);
    }


    private void Action_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_controllerGO)
            _controllerGO.SetActive(false);
        if (_controllerTelerportGO)
            _controllerTelerportGO.SetActive(true);
        if (teleportAreas != null)
            teleportAreas.SetActive(true);
        if (menuInventarioGO != null)
            menuInventarioGO.SetActive(true);
    }
}
