using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [Header("Car settings")]

    public float drriftFactor = 0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 20;

    public float accelerationInput = 0;
    public float steeringInput = 0;

    public float rotationAngele = 0;
    float rotationAngele2 = 0;

    Rigidbody2D carRigidbody2D;

    float velosityVsUp = 0;

    public Timer timer;

    public bool enable = false;
    public bool enable2 = false;
    public Fine fine;

    public Transform[] form_car;



    private void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
       
    }

    void Start()
    {
        Camera.main.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        Time.timeScale = 1f;
        form_car[PlayerPrefs.GetInt("SavedInteger")].gameObject.SetActive(true);
    }

    void LateUpdate()
    {
      
        if (!enable && !enable2)
        {
            
            Camera.main.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            enable2 = true;

        }
        else if (enable )
        {
            //Vector3 direct = transform.position - Camera.main.transform.position;
            // Quaternion rotation = Quaternion.LookRotation(direct);
            //Quaternion rotationCam = Camera.main.transform.rotation;
            //rotationCam.z = 90;
            //Quaternion rotationCar = transform.rotation;
            //print(rotationCar.z);
            //rotationCar.z = rotationAngele - 90;
            //rotationCar.z -= 1f;
            //Camera.main.gameObject.transform.rotation = Quaternion.Lerp(rotationCam, rotationCar, Time.fixedDeltaTime * 60);
            //Camera.main.gameObject.transform.eulerAngles = new Vector3(0, 0, Camera.main.gameObject.transform.rotation.z - 90)
            //Camera.main.transform.Rotate(0f, 0f, Camera.main.transform.eulerAngles.z-180);
            Camera.main.gameObject.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 90);
            enable2 = false;
        }
        

    }

    private void FixedUpdate()
    {
        
        ApplyEngineForce();

        KillOrthogonalVelocity();

        ApplyStreeing();

        if (accelerationInput == 0)
        {
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3.0f, Time.fixedDeltaTime * 6);
        }
        else
        {
            carRigidbody2D.drag = 0;
        }

        
        
    }

    private void ApplyEngineForce()
    {

        velosityVsUp = Vector2.Dot(transform.right, carRigidbody2D.velocity);

        if (velosityVsUp > maxSpeed && accelerationInput > 0)
        {
            return;
        }

        if (velosityVsUp < -maxSpeed * 0.5f && accelerationInput < 0)
        {
            return;
        }

        if (carRigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
        {
            return;
        }

        Vector2 engineForceVecrtor = transform.right * accelerationInput * accelerationFactor;

        carRigidbody2D.AddForce(engineForceVecrtor, ForceMode2D.Force);

        
    }

    private void ApplyStreeing()
    {
        //if (accelerationInput < 0)
        //{
        //    steeringInput *= -1;
        //}
        float minSpeedBeforeAllowTurningFactor = (carRigidbody2D.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        rotationAngele -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;

        
        
        
        carRigidbody2D.MoveRotation(rotationAngele);
        

    }

    public void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);
        Vector2 rightVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);

        carRigidbody2D.velocity = forwardVelocity + rightVelocity * drriftFactor;
    }

    public void setInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;  
    }

    public bool IsTireScreeching(out float later, out bool isBraking)
    {
        later = GetLaterVelocity();
        isBraking = false;

        if(accelerationInput < 0 && velosityVsUp > 0)
        {
            isBraking = true;
            return true;
        }
        if(Mathf.Abs(GetLaterVelocity()) > 4.5f)
            return true;
        
        return false;
    }
    float GetLaterVelocity()
    {
        return Vector2.Dot(transform.right, carRigidbody2D.velocity);
    }

   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "gran")
        {
            timer.timeStart -= 10;
            fine.getEffect();
        }
    }

    

}
