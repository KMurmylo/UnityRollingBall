using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private float rotation ;

    public int smoothnes;
    
    // Start is called before the first frame update
    void Start()
    {
        offset=transform.position - player.transform.position;
        player.GetComponent<PlayerController>().SetCamera(this.gameObject);
        player.GetComponent<PlayerController>().SetCameraController(this);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-offset,Vector3.up),  Time.deltaTime*smoothnes);
        transform.position=player.transform.position+offset;

    }
    void FixedUpdate(){
        

    }
    public void receiveOnLook(InputValue lookValue)
     {
            rotation=lookValue.Get<Vector2>().x;
             Quaternion q=Quaternion.AngleAxis(rotation,Vector3.up);
            offset=q*offset;
        
    }
}
