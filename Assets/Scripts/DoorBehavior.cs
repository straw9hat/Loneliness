using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    private bool roomEnd = false;
    private bool switchedOn = false;
    private bool soundPlayed = false;
    private Transform doorStartPosition;
    [SerializeField] private Transform doorEndPosition;
    [SerializeField] private int buttonReq;
    [SerializeField] private movementTest playerScript;
    private AudioSource doorAudio;
    void Awake()
    {
        doorStartPosition = transform;
        doorAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        var pos = transform.position;

        if(playerScript.buttonsFilled == buttonReq && !roomEnd)
        {
            
            //doorAudio.Play();
            switchedOn = true;
            transform.position = Vector3.MoveTowards(transform.position, doorEndPosition.position, .05f);
            
        }
        if(GameStateGameFinish.lastGate && this.name == "Door4Flow")
        {
            //doorAudio.Play();
            switchedOn = true;
            transform.position = Vector3.MoveTowards(transform.position, doorEndPosition.position, .01f);
            
        }
        if (switchedOn == true && doorAudio.isPlaying == false && !soundPlayed)
        {
            doorAudio.Play();
            soundPlayed = true;
        }
        else if (switchedOn == false && doorAudio.isPlaying == true)
        {
            doorAudio.Stop();
        }
    }

    public void closeDoor()
    {
        roomEnd = true;
        Vector3 pos = transform.localPosition;
        if(this.name == "Door1Flow")
        {
            pos.z = 1.24f;
        }
        if (this.name == "Door2Flow")
        {
            pos.z = -21.45f;
        }
        if (this.name == "Door3Flow")
        {
            pos.z = -0.45f;
        }
        if (this.name == "Door4Flow")
        {
            pos.z = -0.45f;
        }

        Debug.Log(transform.position);
        Debug.Log(transform.localPosition);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, pos, 4);
        doorAudio.Play();
        Debug.Log("closed");
    }
}
