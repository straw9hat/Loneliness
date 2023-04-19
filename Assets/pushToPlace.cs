using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pushToPlace : MonoBehaviour
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
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<movementTest>();
    }

    // Update is called once per frame
    void Update()
    {


        float distance = Vector3.Distance(transform.position, player.transform.position);


        if (isFollowing && (distance > 1))
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

        if (other.tag == "Button")
        {
            isFollowing = false;
            goToButton = true;
            GetComponent<BoxCollider>().enabled = false;
            Destroy(GetComponent<SpringJoint>());
            buttonPos = other.GetComponent<Transform>();
            other.enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            playerScript.FillButtons();
            this.tag = "RoomOneGhosts";
        }

    }

    public void trappedIn()
    {
        isFollowing = true;
        goToButton = false;
        GetComponent<BoxCollider>().enabled = true;
    }
}
