using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blood : MonoBehaviour
{
    public GameObject blood;
    GameObject game;
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
