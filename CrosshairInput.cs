using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class CrosshairInput : MonoBehaviour
{
    internal GameObject HitObject;
   [SerializeField] private StarterAssetsInputs starterAssetsInputs;
   [SerializeField] private GameObject tablet = null;
   [SerializeField] private DatabaseSystem databaseSystem = null;
   [SerializeField] private StandVideoCam_lather   ForObjName_lather = null;
   [SerializeField] private StandVideoCam_mini_lather   ForObjName_mini_lather = null;
   private Ray ray;
   

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                HitObject = hit.collider.gameObject;
                Debug.Log("tıklanan obje: " + HitObject.name);
                ForObjName_lather.SetClickedObjectName(HitObject.name);
                ForObjName_mini_lather.SetClickedObjectName(HitObject.name);
                if (HitObject.CompareTag("machine"))
                {
                    tablet.SetActive(true);
					CursorController(false);
					databaseSystem.SetClickedObjectName(HitObject.name);
                }
                if (!HitObject.CompareTag("machine") && !HitObject.CompareTag("tablet"))
                {
                    tablet.SetActive(false);
					CursorController(true);
                }
            }
			if (Input.GetKeyDown(KeyCode.V)) // Build alınacağı zaman (V) yerine (ESC) koyulacak
			{
				tablet.SetActive(false);
				CursorController(true);
			}
        }
    }

	private void CursorController(bool newState)
	{
		if (newState)
			Cursor.lockState = CursorLockMode.Locked;
		else
			Cursor.lockState = CursorLockMode.None;
		starterAssetsInputs.cursorLocked = newState;
		starterAssetsInputs.cursorInputForLook = true;
	}
}
