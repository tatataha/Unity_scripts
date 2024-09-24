using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
    void Update()
    {
        //bool oddeven = Mathf.FloorToInt(Time.time) % 2 == 0;

        bool oddeven = false;

        rend.enabled = oddeven;
    }
}