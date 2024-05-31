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
    
    void Awake() {
        doorAnimator = door.transform.GetComponent<Animator>();
    }

    void Start() {
        
    }

    void Update() {
    }

    void OnClickAction() {
        if(transform.tag == "OpenDoor") {
            doorAnimator.SetBool("isOpen", true);

            Debug.Log("open");
        }

        if(transform.tag == "CloseDoor") {
            doorAnimator.SetBool("isOpen", false);

            Debug.Log("closed");
        }
    }

    public void EnableButtons() {
        OnClickAction();

        Debug.Log("Buttons ON");
    }

    public void DisableButtons() {
        Debug.Log("Buttons OFF");
    }

}
