using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed=0;
    private Rigidbody rb;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject CheckPoint;
    private int count;
    private float movementX;
    private float movementY;
    private GameObject attachedCamera;
    private CameraController cameraController;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        count=0;
        SetCountText();
        winTextObject.SetActive(false);
        
    }
    public void SetCameraController(CameraController x){
        cameraController=x;
    }
    void OnMove(InputValue movementValue){
            Vector2 movementVector=movementValue.Get<Vector2>();
            movementX=movementVector.x;
            movementY=movementVector.y;
           
            
    }
    void OnLook(InputValue lookValue){
        cameraController.receiveOnLook(lookValue);
        
    }
    void SetCountText(){
        countText.text="Count: "+count.ToString();
        
    }
   
    void FixedUpdate(){
        Vector3 movement=new Vector3(movementX,0.0f,movementY);
        movement=Quaternion.Euler(0,attachedCamera.transform.eulerAngles.y,0)*movement;
        rb.AddForce(movement*speed);
        if(transform.position.y<-50)respawn();
    }
    public void SetCamera(GameObject camera){
        attachedCamera=camera;
    }
    void respawn(){
        transform.position=CheckPoint.transform.position;
        rb.velocity=Vector3.zero;
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("PickUp")){
        other.gameObject.SetActive(false);
        count++;
        SetCountText();
        }else
        {
            if(other.gameObject.CompareTag("CheckPoint"))
            {
                CheckPoint=other.gameObject;
                CheckPoint.SetActive(false);
            }else{
                if(other.gameObject.CompareTag("GoalPoint")){
                    winTextObject.GetComponent<TextMeshProUGUI>().text="You win with score of "+count;
                    winTextObject.SetActive(true);

                }
            }
        }
    }
    
}
