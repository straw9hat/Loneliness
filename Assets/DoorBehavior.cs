using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public int buttonsFilled = 0;
    private Transform doorStartPosition;
    [SerializeField] private Transform doorEndPosition;
    // Start is called before the first frame update
    void Start()
    {
        doorStartPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        print(buttonsFilled);

        if(buttonsFilled == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorEndPosition.position, .01f);
        }
    }

    public void FillButtons()
    {
        buttonsFilled++;
    }
}
