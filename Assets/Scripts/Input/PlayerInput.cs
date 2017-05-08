using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInput {

    [SerializeField]
    private int index; //Controller index

    InputType inputType;

    public Hashtable controllerMapButton;

    public bool Enable = false;

    public void Init(int idx, Hashtable _controllerMapButton)
    {
        index = idx;

        if(controllerMapButton == null)
        {
            inputType = InputType.Keyboard;
        }else{
            inputType = InputType.Joystick;
        }
        controllerMapButton = _controllerMapButton;
		Debug.Log ("Conectado >>> " + index);
        Enable = true;

    }

    #region JoystickInfo
    /// <summary>
    /// Return true if the Button is down in the frame.
    /// </summary>
    public bool GetButtonDown(ButtonActions action)
    {
        switch (action)
        {
            case ButtonActions.Start:
                return GetKeyDown("Start");
            case ButtonActions.Select:
                return GetKeyDown("Select");
            case ButtonActions.Fire:
                return GetKeyDown("Fire");
            case ButtonActions.SpecialFire:
                return GetKeyDown("SpecialFire");
            case ButtonActions.Break:
                return GetKeyDown("Break");
            case ButtonActions.Boost:
                return GetKeyDown("Boost");

        }
        return false;
    }

    public bool GetButtonPress(ButtonActions action){
        switch (action)
        {
            case ButtonActions.Start:
                return GetKeyPress("Start");
            case ButtonActions.Select:
                return GetKeyPress("Select");
            case ButtonActions.Fire:
                return GetKeyPress("Fire");
            case ButtonActions.SpecialFire:
                return GetKeyPress("SpecialFire");
            case ButtonActions.Break:
                return GetKeyPress("Break");
            case ButtonActions.Boost:
                return GetKeyPress("Boost");

        }
        return false;
    }

	public bool GetButtonUp(ButtonActions action){
		switch (action)
		{
		case ButtonActions.Start:
			return GetKeyUp("Start");
		case ButtonActions.Select:
			return GetKeyUp("Select");
		case ButtonActions.Fire:
			return GetKeyUp("Fire");
		case ButtonActions.SpecialFire:
			return GetKeyUp("SpecialFire");
		case ButtonActions.Break:
			return GetKeyUp("Break");
		case ButtonActions.Boost:
			return GetKeyUp("Boost");

		}
		return false;
	}

    private bool GetKeyDown(string stringAction)
    {
        return Input.GetKeyDown(GetButtonName((string)controllerMapButton[stringAction]));
    }

    private bool GetKeyPress(string stringAction)
    {
		return Input.GetKey(GetButtonName((string)controllerMapButton[stringAction]));
    }

	private bool GetKeyUp(string stringAction){
		return Input.GetKeyUp ((string)controllerMapButton [stringAction]);
	}

    private string GetButtonName(string buttonIdx)
    {
        return "joystick " + index + " button " + buttonIdx;
    }

    public float GetAxisJoystickX()
    {
        return Input.GetAxis("JoystickH" + index);
    }


    public float GetAxisJoystickY()
    {
        return Input.GetAxis("JoystickV" + index);
    }
    #endregion

}
