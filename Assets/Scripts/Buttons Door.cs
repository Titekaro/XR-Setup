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
    private Button buttonOpen;
    private Button buttonClose;
    
    void Awake() {
        doorAnimator = door.transform.GetComponent<Animator>();
        buttonOpen = transform.Find("Button Open").GetComponent<Button>();
        buttonClose = transform.Find("Button Close").GetComponent<Button>();
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
        buttonOpen.interactable = true;
        buttonClose.interactable = true;

        OnClickAction();

        Debug.Log("Buttons ON");
    }

    public void DisableButtons() {
        buttonOpen.interactable = false;
        buttonClose.interactable = false;

        Debug.Log("Buttons OFF");
    }

}
