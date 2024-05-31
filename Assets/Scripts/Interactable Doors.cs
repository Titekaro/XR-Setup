using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableDoors : MonoBehaviour
{
    internal bool canGoOutside = true;
    internal bool canGoInside = true;

    private GameObject sasDoor;
    private GameObject outsideDoor;
    private float doorClosedPosition = -0.024f;

    void Awake() {
        sasDoor = GameObject.FindWithTag("SAS");
        outsideDoor = GameObject.FindWithTag("Outdoor");

        // Reset doors position
        sasDoor.transform.position = new Vector3(doorClosedPosition, sasDoor.transform.position.y, sasDoor.transform.position.z);
        outsideDoor.transform.position = new Vector3(doorClosedPosition, outsideDoor.transform.position.y, outsideDoor.transform.position.z);

        Debug.Log(sasDoor.transform.position);
        Debug.Log(outsideDoor.transform.position);
    }

    void Start() {
        
    }

    void Update() {
        CanOpenOutdoorDoor();
    }

    // Allow to open the outside door only if sas door is closed
    private void CanOpenOutdoorDoor() {
        if(sasDoor.transform.position.x == doorClosedPosition) {
            //Debug.Log("You can go outside");
            canGoOutside = true;
            Transform attach = outsideDoor.transform.Find("AttachPoint");
            attach.gameObject.SetActive(true);
        } else {
            //Debug.Log("You CAN'T go outside");
            canGoOutside = false;
            Transform attach = outsideDoor.transform.Find("AttachPoint");
            attach.gameObject.SetActive(false);
        }
    }

    // Allow to open the sas door only if outside door is closed
    private void CanOpenSasDoor() {
        if(outsideDoor.transform.position.x == doorClosedPosition) {
            //Debug.Log("You can go inside");
            canGoInside = true;
            Transform attach = sasDoor.transform.Find("AttachPoint");
            attach.gameObject.SetActive(true);

        } else {
            //Debug.Log("You CAN'T go inside");
            canGoInside = false;
            Transform attach = sasDoor.transform.Find("AttachPoint");
            attach.gameObject.SetActive(false);
        }
    }
    
}
