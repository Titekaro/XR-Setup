using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableDoors : MonoBehaviour
{
    private bool canGoOutside = true;
    private bool canGoInside = true;
    private GameObject sasDoor;
    private GameObject outsideDoor;
    private Vector3 sasDoorClosedPosition;
    private Vector3 outsideDoorClosedPosition;

    void Awake() {
        sasDoor = GameObject.FindWithTag("SAS");
        sasDoorClosedPosition = sasDoor.transform.position;
        outsideDoor = GameObject.FindWithTag("Outdoor");
        outsideDoorClosedPosition = outsideDoor.transform.position;
    }

    void Start() {
        
    }

    void Update() {
        CanOpenOutdoorDoor();
    }

    // Allow to open the outside door only if sas door is closed
    private void CanOpenOutdoorDoor() {
        if(sasDoor.transform.position == sasDoorClosedPosition) {
            Debug.Log("You can go outside");
            canGoOutside = true;
            outsideDoor.Find("AttachPoint").SetActive(true);

        } else {
            Debug.Log("You CAN'T go outside");
            canGoOutside = false;
        }
    }

    // Allow to open the sas door only if outside door is closed
    private void CanOpenSasDoor() {
        if(outsideDoor.transform.position == outsideDoorClosedPosition) {
            Debug.Log("You can go inside");
            canGoInside = true;

        } else {
            Debug.Log("You CAN'T go inside");
            canGoInside = false;
        }
    }
    
}
