using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blood : MonoBehaviour
{
    public GameObject blood;
    GameObject bloodClone;
    GameObject game;
    public float speed = 2f;
    public float lifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(Camera.main.transform.position);
        //game = transform.position += transform.forward * Time.deltaTime * 2f;
    }
}
