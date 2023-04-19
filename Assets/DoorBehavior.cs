using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    private bool roomEnd = false;
    private Transform doorStartPosition;
    [SerializeField] private Transform doorEndPosition;
    [SerializeField] private int buttonReq;
    [SerializeField] private movementTest playerScript;
    // Start is called before the first frame update
    void Start()
    {
        doorStartPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(playerScript.buttonsFilled == buttonReq && !roomEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorEndPosition.position, .01f);
        }
        if(GameStateGameFinish.lastGate && this.name == "Door4Flow")
        {
            transform.position = Vector3.MoveTowards(transform.position, doorEndPosition.position, .01f);
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
        Debug.Log("closed");
    }
}
