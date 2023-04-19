using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class trapDoorTrigger : MonoBehaviour
{
    //public GameObject mainCamera;
    public static bool trapDoor1 = false;
    public static bool trapDoor2 = false;
    public static bool trapDoor3 = false;
    public static bool finsihLine = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private async void OnTriggerEnter(Collider other)
    {
        Debug.Log("out");
        if(this.name == "ExitTrigger1" && !trapDoor1)
        {
            Debug.Log("in");
            trapDoor1 = true;
            //Vector3 pos = Camera.main.transform.localPosition;
            //Debug.Log(Camera.main.transform.position);
            //Debug.Log(Camera.main.transform.localPosition);
            //pos.x = 8;
            //Camera.main.transform.localPosition = pos;
            //await threeSecondDelay();
            //Debug.Log("done");
            //pos.x = -1.09f;
            //Camera.main.transform.localPosition = pos;

        }
        if (this.name == "ExitTrigger2")
        {
            trapDoor2 = true;
        }
        if (this.name == "ExitTrigger3")
        {
            trapDoor3 = true;
        }
        if (this.name == "ExitTrigger4")
        {
            finsihLine = true;
        }
        this.gameObject.SetActive(false);
    }

    //private async Task threeSecondDelay()
    //{
    //    await Task.Delay(TimeSpan.FromSeconds(5));
    //}
}
