using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator pivotdoor = null;

    [SerializeField] private bool openTrigger = false;
    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
       {
            if (openTrigger)
            {
                pivotdoor.Play("dooranime", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeTrigger)
            {
                pivotdoor.Play("doorclose", 0, 0.0f);
                gameObject.SetActive(false);
            }
       }
    }
}
