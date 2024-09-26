using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class machineControlPanel : MonoBehaviour
{
    internal GameObject HitObject;
	[SerializeField] GameObject panelSuccess;
	[SerializeField] GameObject panelFail;
    [SerializeField] private int[] successCode;
    List<int> currentCode = new List<int>();
    int tickCount = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {  
                HitObject = hit.collider.gameObject;
            }

            if (HitObject.CompareTag("ControlButton") && tickCount < successCode.Length)
            {
                tickCount++;
                if (tickCount <= successCode.Length)
                {
                    CodeCollector();
                }
            }

            if (tickCount == successCode.Length)
            {
				ResultChooser();
            }
        }
    }

	private void ResultChooser()
	{
        if (CodeController())
        {
            StartCoroutine(ActivateAndDeactivatePanel(panelSuccess));
            //Debug.Log("BASARILI");
        }
        else
        {
			StartCoroutine(ActivateAndDeactivatePanel(panelFail));
            //Debug.Log("OLUMSUZ");
        }
        tickCount = 0;
        currentCode.Clear();
	}

    private void CodeCollector()
    {
        int id = HitObject.GetComponent<ButtonID>().id;
        //Debug.Log("hit id is :" + id);
        currentCode.Add(id);
    }

    private bool CodeController()
    {
        bool successState = successCode.SequenceEqual(currentCode);
        return successState;
    }

	IEnumerator ActivateAndDeactivatePanel(GameObject panel)
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(4f);
        panel.SetActive(false);
    }
}