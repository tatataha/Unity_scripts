using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamRecControl : MonoBehaviour
{
    [SerializeField] private GameObject[] Cams = new GameObject[5];
    [SerializeField] private CrosshairInput crosshairInput;

    private int buttickCount = 0;
    private string tickobjName;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tickobjName = crosshairInput.HitObject.name;
            if (tickobjName == "CamCtrlButton")
            {
                CamChanger();
            }
        }
    }

    void CamChanger()
    {
        foreach (var cam in Cams)
        {
            cam.SetActive(false);
        }

        Cams[buttickCount].SetActive(true);

        buttickCount++;
        if (buttickCount >= Cams.Length)
        {
            buttickCount = 0;
        }
    }
}
