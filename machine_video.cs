using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
public class CameraClick : MonoBehaviour
{
	internal GameObject HitObject;
	[SerializeField] private GameObject videoScreen;
	[SerializeField] private VideoPlayer videoPlayer;
	[SerializeField] private GameObject cameraObject;
	
	int counter = 0;
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;


			if (Physics.Raycast(ray, out hit))
			{  
				HitObject = hit.collider.gameObject;
				if (HitObject.name == cameraObject.name)
				{
					counter++;
					if (counter % 2 == 0)
					{
						videoScreen.SetActive(false);
						videoPlayer.Pause();
					}
					else
					{
						videoScreen.SetActive(true);
						videoPlayer.Play();
						
					}
				}
			}
		}
	}
}
