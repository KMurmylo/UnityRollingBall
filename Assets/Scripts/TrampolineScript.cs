using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    public int strength=500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void OnTriggerEnter(Collider other){
    other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up*strength);
   }
}
