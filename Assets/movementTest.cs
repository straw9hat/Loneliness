using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class movementTest : MonoBehaviour
{
    public int buttonsFilled = 0;
    public float speed = 5.0f;
    public float rotationSpeed = 720f;
    public static bool playCutscene = false;


    Vector3 buttonPos;
    PlayableDirector director;



    private void Awake()
    {
        director = FindObjectOfType<PlayableDirector>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!playCutscene)
        {
            Vector3 pos = this.transform.position;
            if (Input.GetKey(KeyCode.W))
            {
                pos.z += Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                pos.x -= Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                pos.z -= Time.deltaTime * speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos.x += Time.deltaTime * speed;
            }
            this.transform.position = pos;
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            StandOnBtn(buttonPos);
        }


       
    }
    
    public void FillButtons()
    {
        buttonsFilled++;
    }

    void StandOnBtn(Vector3 btnPos)
    {
        var t = 1 / (transform.position - btnPos).magnitude;
        this.transform.position = Vector3.Lerp(transform.position, btnPos, t * 0.04f);
        print(btnPos);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HallwayBtn")
        {
            playCutscene = true;
            buttonPos = other.transform.position;
            other.enabled = false;
            director.Play();
        }
    }
}
