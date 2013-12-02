using UnityEngine;

public class PlayerControl : MonoBehaviour,
OuyaSDK.IMenuButtonUpListener,
OuyaSDK.IMenuAppearingListener,
OuyaSDK.IPauseListener,
OuyaSDK.IResumeListener
{
	public float INNER_DEADZONE = 0.1f;
	
	public float MOVE_SPEED = 5f;
	
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
		Vector3 pos = transform.position;
		
		Vector2 input;
		input.x = OuyaExampleCommon.GetAxis(OuyaSDK.KeyEnum.AXIS_LSTICK_X, OuyaExampleCommon.Player);
		input.y = OuyaExampleCommon.GetAxis(OuyaSDK.KeyEnum.AXIS_LSTICK_Y, OuyaExampleCommon.Player);
		
		if (Mathf.Abs(input.x) > INNER_DEADZONE)
		{
			pos.x += input.x*MOVE_SPEED*Time.deltaTime;
		}
		
		if (Mathf.Abs(input.y) > INNER_DEADZONE)
		{
			pos.y -= input.y*MOVE_SPEED*Time.deltaTime;
		}
		
		transform.position = pos;
	}
}