using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StandVideoCam_mini_lather : MonoBehaviour
{
	[SerializeField] private VideoPlayer	StandVideo = null;
	[SerializeField] private GameObject		Panel = null;
	[SerializeField] private GameObject		Image = null;
	private	bool isShowing = false;
	private bool isPlaying = false;
	private string ClickedObjectName;

	public void SetClickedObjectName(string name)
    {
        ClickedObjectName = name;
    }

	private bool VidPlayer(bool isPlaying)
	{
		if (isPlaying)
		{
			StandVideo.Pause();
			isPlaying = false;
		}
		else
		{
			StandVideo.Play();
			isPlaying = true;
		}
		return isPlaying;
	}

	private	bool	ImageShower(bool isShowing)
	{
		if (isShowing)
		{
			Image.SetActive(false);
			isShowing = false;
		}
		else
		{
			Image.SetActive(true);
			isShowing = true;
		}
		return isShowing;
	}
	void Update()
	{
        if (ClickedObjectName == "standCambutton_mini_lather")
        {
			if (isShowing)
			{
				isShowing = ImageShower(isShowing);
			}
            isPlaying = VidPlayer(isPlaying);
            Panel.SetActive(isPlaying);
            ClickedObjectName = null;
        }
        else if (ClickedObjectName == "standInfobutton_mini_lather")
        {
			if (isPlaying)
			{
				isPlaying = VidPlayer(isPlaying);
				Panel.SetActive(isPlaying);
			}
            isShowing = ImageShower(isShowing);
            ClickedObjectName = null;
        }
	}

	
}
