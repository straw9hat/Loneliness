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

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fillSFX;

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
        switch (buttonsFilled)
        {
            case 0: audioSource.pitch = 1f; break;
            case 1: audioSource.pitch = 1f; break;
            case 2: audioSource.pitch = 0.8f; break;
            case 3: audioSource.pitch = 0.75f; break;
            case 4: audioSource.pitch = 0.7f; break;
            case 5: audioSource.pitch = 0.65f; break;
            case 6: audioSource.pitch = 0.6f; break;
            case 7: audioSource.pitch = 0.55f; break;
            case 8: audioSource.pitch = 0.5f; break;
            case 9: audioSource.pitch = 0.4f; break;
        }
        
        audioSource.clip = fillSFX;
        audioSource.Play();

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
