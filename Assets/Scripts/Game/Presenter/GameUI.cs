using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class GameUI : MonoBehaviour
{
      private InputSystem_Actions _actions;

      [SerializeField] private ResumeUI resume;

    private void Awake()
    {
        _actions = new InputSystem_Actions();
        _actions.Enable();
        Time.timeScale = 1f;
        _actions.UI.Resume.performed += Toggle;
    }

    private void OnDestroy()
    {
        _actions.UI.Resume.performed -= Toggle;
        _actions.Disable();
    }

    private void Toggle(InputAction.CallbackContext ctx)
    {
        Debug.Log("Toggle");
        Action action = resume.gameObject.activeInHierarchy ? resume.Play : resume.Resume;
        action();
    }

   
}