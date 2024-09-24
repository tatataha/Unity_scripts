using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
public class Machine
{
    public string name;
    public string corp;
    public string model;
    public string state;
}

[System.Serializable]
public class MachineResponse
{
    public Machine machine;
}

public class DatabaseSystem : MonoBehaviour
{
    public Text machineNameText;
    public Text machineCorpText;
    public Text machineModelText;
    public Text machineStateText;
    private string clickedObjectName;

    void Start()
    {
        StartCoroutine(GetDataFromLocalServer());
    }

    public void SetClickedObjectName(string name)
    {
        clickedObjectName = name;
        StartCoroutine(GetDataFromLocalServer());
    }

    IEnumerator GetDataFromLocalServer()
    {
        string url;
        if (clickedObjectName == "mixer")
            url = "http://localhost:8080/mixer.json";
        else if (clickedObjectName == "coiler")
            url = "http://localhost:8080/coiler.json";
        else if (clickedObjectName == "tanker")
            url = "http://localhost:8080/tanker.json";
        else if (clickedObjectName == "robot_arm")
            url = "http://localhost:8080/robocol.json";
        else if (clickedObjectName == "big_tanker")
            url = "http://localhost:8080/big_tanker.json";
        else if (clickedObjectName == "lathe")
            url = "http://localhost:8080/lathe.json";
        else if (clickedObjectName == "mini_lathe")
            url = "http://localhost:8080/mini_lathe.json";
        else if (clickedObjectName == "regulator")
            url = "http://localhost:8080/regulator.json";
        else if (clickedObjectName == "regulator_water")
            url = "http://localhost:8080/regulator_water.json";
        else
            url = "http://localhost:8080/data.json";

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Hata: " + request.error);
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;
            Debug.Log("Gelen Cevap: " + jsonResponse);

            MachineResponse data = JsonUtility.FromJson<MachineResponse>(jsonResponse);

            if (machineNameText != null)
                machineNameText.text = data.machine.name;
            else
                Debug.LogError("machineNameText referansı atanmadı!");

            if (machineCorpText != null)
                machineCorpText.text = data.machine.corp;
            else
                Debug.LogError("machineCorpText referansı atanmadı!");

            if (machineModelText != null)
                machineModelText.text = data.machine.model;
            else
                Debug.LogError("machineModelText referansı atanmadı!");

            if (machineStateText != null)
                machineStateText.text = data.machine.state;
            else
                Debug.LogError("machineStateText referansı atanmadı!");
        }
    }
}