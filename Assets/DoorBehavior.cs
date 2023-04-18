using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    
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
        

        if(playerScript.buttonsFilled == buttonReq)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorEndPosition.position, .01f);
        }
    }

    
}
