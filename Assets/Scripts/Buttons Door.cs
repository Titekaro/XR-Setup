using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonsDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private Animator doorAnimator;

    private PlayerInput playerInput;
    private InputAction clickAction;
    
    void Awake() {
        doorAnimator = door.transform.GetComponent<Animator>();

        playerInput = GetComponent<PlayerInput>();
        clickAction = playerInput.actions["Click"];
    }

    void Start() {
        
    }

    void Update() {
        OnClickAction();
    }

    void OnClickAction() {
        if(clickAction.ReadValue<bool>() != false) {
            Debug.Log("clicked");
            doorAnimator.SetBool("isOpen", true);
        }
    }

}
