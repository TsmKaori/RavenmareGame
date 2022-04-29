using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);//position.x = new Vector3(gameObject.transform.position.x + .1f, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
