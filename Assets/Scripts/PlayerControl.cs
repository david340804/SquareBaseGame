using UnityEngine;

public class PlayerControl : MonoBehaviour,
OuyaSDK.IMenuButtonUpListener,
OuyaSDK.IMenuAppearingListener,
OuyaSDK.IPauseListener,
OuyaSDK.IResumeListener
{
	public float innerDeadzone;	//avoid jitters around center
	
	public float moveSpeed;	//how far to go per second

	public Material mainMaterial;		//main appearance
	public Material secondaryMaterial;	//switchable second appearance

	public OuyaSDK.OuyaPlayer Index;
	
	void Awake()
	{
		OuyaSDK.registerMenuButtonUpListener(this);
		OuyaSDK.registerMenuAppearingListener(this);
		OuyaSDK.registerPauseListener(this);
		OuyaSDK.registerResumeListener(this);
		Input.ResetInputAxes();
	}
	void OnDestroy()
	{
		OuyaSDK.unregisterMenuButtonUpListener(this);
		OuyaSDK.unregisterMenuAppearingListener(this);
		OuyaSDK.unregisterPauseListener(this);
		OuyaSDK.unregisterResumeListener(this);
		Input.ResetInputAxes();
	}
	
	public void OuyaMenuButtonUp()
	{
	}
	
	public void OuyaMenuAppearing()
	{
	}
	
	public void OuyaOnPause()
	{
	}
	
	public void OuyaOnResume()
	{
	}
	
	void Update()
	{
		//moving with L stick
		Vector3 pos = transform.position;
		
		Vector2 input;
		input.x = OuyaExampleCommon.GetAxis(OuyaSDK.KeyEnum.AXIS_LSTICK_X, OuyaExampleCommon.Player);
		input.y = OuyaExampleCommon.GetAxis(OuyaSDK.KeyEnum.AXIS_LSTICK_Y, OuyaExampleCommon.Player);
		
		if (Mathf.Abs(input.x) > innerDeadzone)
		{
			pos.x += input.x*moveSpeed*Time.deltaTime;
		}
		
		if (Mathf.Abs(input.y) > innerDeadzone)
		{
			pos.y -= input.y*moveSpeed*Time.deltaTime;
		}
		
		transform.position = pos;

		//buttons
		if (OuyaExampleCommon.GetButton(OuyaSDK.KeyEnum.BUTTON_O, OuyaSDK.OuyaPlayer.player1)){
			renderer.material = mainMaterial;
		}

		if (OuyaExampleCommon.GetButton(OuyaSDK.KeyEnum.BUTTON_A, OuyaSDK.OuyaPlayer.player1)){
			renderer.material = secondaryMaterial;
		}
	}
}