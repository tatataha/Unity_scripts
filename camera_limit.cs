using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CameraLimit : MonoBehaviour
{
	[SerializeField] private GameObject Player = null;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera PlayerCam = null;
	[SerializeField] private GameObject CineMachineTarget = null;
	private float HorMax;
	private float HorMin;
	private float HorSpeed;
	private float CurrentHorVal;
	private CinemachinePOV pov;

	private void Start()
	{
		GetCamRanges();
	}
    private void GetCamRanges()
    {
        if (PlayerCam != null)
        {
			pov = PlayerCam.GetCinemachineComponent<CinemachinePOV>();
			if (pov != null)
			{
				HorMax = pov.m_HorizontalAxis.m_MaxValue;
				HorMin = pov.m_HorizontalAxis.m_MinValue;
				HorSpeed = pov.m_HorizontalAxis.m_MaxSpeed;
			}
			else
			{
				Debug.LogError("CinemachinePOV component not found on the virtual camera!");
			}
        }
        else
        {
            Debug.LogError("You don't have a CineMachine VR Cam!!");
        }
    }

    private void UpdatePlayerRot()
    {
		int HaveAction = 0;
		CurrentHorVal = pov.m_HorizontalAxis.Value;

		if(CurrentHorVal == HorMax || CurrentHorVal + 1 >= HorMax)
		{
			Player.transform.Rotate(HorSpeed * Time.deltaTime * Vector3.up);
			HaveAction = 1;
		}
		else if (CurrentHorVal == HorMin || CurrentHorVal - 1 <= HorMin)
		{
			Player.transform.Rotate(HorSpeed * Time.deltaTime * Vector3.up * -1);
			HaveAction = 1;
		}
		if (HaveAction == 1)
		{
			Debug.Log("test");
			CineMachineTarget.transform.rotation = Player.transform.rotation;
		}
    }
	private void Update()
	{
		UpdatePlayerRot();
		Debug.Log(CurrentHorVal);
	}
}