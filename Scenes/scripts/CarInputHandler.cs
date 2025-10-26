using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarInputHandler : MonoBehaviour
{
    CarMove carMove;
    //public Joystick joystick;
    Vector2 inputVector;
    bool _onDown = false;
    bool _onDown2 = false;
    bool _onDown3 = false;
    bool _onDown4 = false;
    void Awake()
    {
        carMove = GetComponent<CarMove>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = Vector2.zero;
        
        inputVector.x = Input.GetAxis("Horizontal");
        //inputVector.x = joystick.Horizontal;
        //inputVector.x = joystick.Vertical;
        inputVector.y = Input.GetAxis("Vertical");
        

        //inputVector.y = joystick.Horizontal;
        if (_onDown)
        {
            inputVector.y = 1.0f;
        }
        if (_onDown2)
        {
            inputVector.y = -1.0f;
        }
        if (_onDown3 && _onDown2)
        {
            inputVector.x = -1.0f;
        }
        if (_onDown4 && _onDown2)
        {
            inputVector.x = 1.0f;
        }
        if (_onDown3 && !_onDown2)
        {
            inputVector.x = 1.0f;
        }
        if (_onDown4 && !_onDown2)
        {
            inputVector.x = -1.0f;
        }
        carMove.setInputVector(inputVector);
    }

    public void OnF()
    {
        _onDown = true;
    }

    public void OffF()
    {
        _onDown = false;
    }
    public void OnF2()
    {
        _onDown2 = true;
    }

    public void OffF2()
    {
        _onDown2 = false;
    }

    public void OnF3()
    {
        _onDown3 = true;
    }

    public void OffF3()
    {
        _onDown3 = false;
    }
    public void OnF4()
    {
        _onDown4 = true;
    }

    public void OffF4()
    {
        _onDown4 = false;
    }
}
