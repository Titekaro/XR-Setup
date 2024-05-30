using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoors : MonoBehaviour
{
    private bool canGoOutside = true;
    private GameObject sasDoor;
    private GameObject outsideDoor;
    private Vector3 sasDoorClosedPosition;

    void Awake() {
        sasDoor = GameObject.FindWithTag("SAS");
        sasDoorClosedPosition = sasDoor.transform.position;
        Debug.Log(sasDoorClosedPosition);
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

        } else {
            Debug.Log("You CAN'T go outside");
            canGoOutside = false;
        }
    }

    // Allow to open the sas door only if outside door is closed
    private void CanOpenSasDoor() {
        if(sasDoor.transform.position == sasDoorClosedPosition) {
            Debug.Log("You can go outside");
            canGoOutside = true;

        } else {
            Debug.Log("You CAN'T go outside");
            canGoOutside = false;
        }
    }
    
}
