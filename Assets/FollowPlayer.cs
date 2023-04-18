using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool isFollowing = false;
    private bool goToButton = false;
    private float speed = 6f;
    [SerializeField] private GameObject player;
    [SerializeField] private movementTest playerScript = null;
    private Transform buttonPos;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        float distance = Vector3.Distance(transform.position, player.transform.position);
      
        
        if (isFollowing && distance > 2)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            this.transform.Translate(direction * speed * Time.deltaTime);
        }
        if (goToButton)
        {
            
            Vector3 direction = (buttonPos.position - transform.position).normalized;
            this.transform.Translate(direction * speed * Time.deltaTime);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isFollowing = true;
        }

        if(other.tag == "Button")
        {
            isFollowing= false;
            goToButton = true;
            GetComponent<BoxCollider>().enabled = false;
            buttonPos = other.GetComponent<Transform>();
            other.enabled= false;
            playerScript.FillButtons();
        }

    }

    
}
