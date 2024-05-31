using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{

    private bool isGeneratorRunning = false;
    private bool isBatterySet;
    private bool isCardSet;
    private AudioSource alertAudio;
    private AudioSource generatorAudio;

    [SerializeField] private GameObject socketCard;
    [SerializeField] private GameObject socketBattery;
    [SerializeField] private ButtonsDoor buttonsDoor;

    private GameObject doorManager;

    void Awake() {
        alertAudio = GameObject.Find("Rooms").GetComponent<AudioSource>();
        generatorAudio = GameObject.Find("Generator").GetComponent<AudioSource>();
        doorManager = GameObject.Find("Door Manager");
    }

    void Start() {
    }

    void Update() {
        RunGenerator();
        PlayAlert();
    }

    void RunGenerator() {
        //Check if card is placed in the generator
        if(socketCard.tag == "Set") {
            isCardSet = true;
        } else {
            isCardSet = false;
        }
        //Check if battery is placed in the generator
        if(socketBattery.tag == "Set") {
            isBatterySet = true;
        } else {
            isBatterySet = false;
        }

        //Set generator as activated
        if(isBatterySet && isCardSet) {
            isGeneratorRunning = true;

            if (!generatorAudio.isPlaying) generatorAudio.Play();
            

            //Enable buttons Door
            for (int i = 0; i < doorManager.transform.childCount; i++){
                GameObject child = doorManager.transform.GetChild(i).gameObject;
                child.GetComponent<ButtonsDoor>().EnableButtons();
            }

        } else {
            isGeneratorRunning = false;

            //Disable buttons Door
            for (int i = 0; i < doorManager.transform.childCount; i++){
                GameObject child = doorManager.transform.GetChild(i).gameObject;
                child.GetComponent<ButtonsDoor>().DisableButtons();
            }
        }

        Debug.Log(isGeneratorRunning);
    }
    
    void PlayAlert(){
        if(alertAudio != null) {
            if(isGeneratorRunning) {
                alertAudio.Stop();
            } else {
                if(!alertAudio.isPlaying) alertAudio.Play();
            }
        }
    }

}
