using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTest : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
