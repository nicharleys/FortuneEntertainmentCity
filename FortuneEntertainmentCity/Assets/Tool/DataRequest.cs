using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
public static class DataRequest {
    public static async Task<string> RemotePost(string url) {
        UnityWebRequest request = new UnityWebRequest(url, "POST") {
            downloadHandler = new DownloadHandlerBuffer()
        };
        return await SendRequest(request);
    }
    public static async Task<string> RemotePost(string url, string jsonData) {
        byte[] byteData = Encoding.UTF8.GetBytes(jsonData);
        UnityWebRequest request = new UnityWebRequest(url, "POST") {
            uploadHandler = new UploadHandlerRaw(byteData),
            downloadHandler = new DownloadHandlerBuffer()
        };
        return await SendRequest(request);
    }
    public static bool CheckFile(string dataName) {
        if(File.Exists(Application.persistentDataPath + "/" + dataName + ".json"))
            return true;
        else
            return false;
    }
    public static void LocalDelete(string dataName) {
        File.Delete(Application.persistentDataPath + "/" + dataName + ".json");
    }
    public static void LocalSave<T>(T data, string dataName) {
        string jsondata = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/" + dataName + ".json", jsondata);
    }
    public static T LocalLoad<T>(string dataName) {
        string jsondata = File.ReadAllText(Application.persistentDataPath + "/" + dataName + ".json");
        return JsonUtility.FromJson<T>(jsondata);
    }
    public static async Task<bool> Ping(string ipAddress) {
        float pingTime = 0;
        #if UNITY_STANDALONE_WIN
        Ping ping = new Ping(ipAddress);
        while(!ping.isDone) {
            await Task.Delay(100);
            pingTime += 0.1f;
            if(pingTime > 3.0)
                return false;
        }
        #endif
        #if UNITY_WEBGL
        NetworkReachability network = Application.internetReachability;
        while(network == NetworkReachability.NotReachable) {
            await Task.Delay(100);
            pingTime += 0.1f;
            if(pingTime > 3.0)
                return false;
        }
        #endif
        return true;
    }
    private static async Task<string> SendRequest(UnityWebRequest request) {
        request.SetRequestHeader("Content-Type", "application/json");
        UnityWebRequestAsyncOperation operation = request.SendWebRequest();
        while(!operation.isDone)
            await Task.Yield();
        if(request.isNetworkError || request.isHttpError)
            return request.error;
        else
            return request.downloadHandler.text;
    }
}
