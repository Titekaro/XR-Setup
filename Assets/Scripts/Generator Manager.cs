using System.Collections;
using System.Collections.Generic;
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

    void Awake() {
        alertAudio = GameObject.Find("Rooms").GetComponent<AudioSource>();
        generatorAudio = GameObject.Find("Generator").GetComponent<AudioSource>();
        buttonsDoor = GameObject.Find("Buttons Panel").GetComponent<ButtonsDoor>();
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

            //Enable buttons Door
            buttonsDoor.EnableButtons();
        } else {
            isGeneratorRunning = false;

            //Disable buttons Door
            buttonsDoor.DisableButtons();
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
