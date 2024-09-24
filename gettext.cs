using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FetchLocalJson : MonoBehaviour
{
    public Text machineText;

    void Start()
    {
        StartCoroutine(GetDataFromLocalServer());
    }

    IEnumerator GetDataFromLocalServer()
    {
        string url = "http://localhost:8080/dt.json";
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;
            DataResponse data = JsonUtility.FromJson<DataResponse>(jsonResponse);
            machineText.text = data.machine;
        }
    }

    [System.Serializable]
    public class DataResponse
    {
        public string machine;
    }
}
