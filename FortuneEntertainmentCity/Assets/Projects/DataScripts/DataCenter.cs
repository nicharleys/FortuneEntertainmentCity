using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DataCenter {
    private string _postAddress = "http://127.0.0.1:3000";
    private string _pingAddress = "127.0.0.1";
    private GameObject _networkFailedUI = null;
    private bool _isNetworkFailed = false;
    public bool IsNetworkFailed { get { return _isNetworkFailed; } }
    #region 資料設置
    private UserInfoMemento _userInfoMemeno = null;
    public UserInfoMemento UserInfoMemento { get { return _userInfoMemeno; } }
    #endregion

    #region 基礎設置
    public delegate void NetworkDelegate();
    public event NetworkDelegate NetworkFailedHandler;
    public event NetworkDelegate NetworkSuccessedHandler;

    private static DataCenter _instance;
    public static DataCenter Instance {
        get {
            if(_instance == null)
                _instance = new DataCenter();
            return _instance;
        }
    }
    public DataCenter() {
        Initialize();
        NetworkFailedHandler += OnNetworkFailed;
        NetworkSuccessedHandler += OnNetworkSuccessed;
    }
    #endregion
    private void Initialize() {
        _userInfoMemeno = new UserInfoMemento(this, _postAddress);
    }
    #region 連線事件
    public async Task NetworkTest() {
        Task<bool> networkTestTask = NetworkPing();
        while(!networkTestTask.IsCompleted)
            await Task.Yield();
        while(_isNetworkFailed)
            await Task.Yield();
    }
    public async Task<bool> NetworkPing() {
        if(!await DataRequest.Ping(_pingAddress)) {
            NetworkFailedHandler.Invoke();
            return false;
        }
        else {
            NetworkSuccessedHandler.Invoke();
            return true;
        }
    }
    private void OnNetworkSuccessed() {
        _isNetworkFailed = false;
    }
    private void OnNetworkFailed() {
        NetworkFailed().GetAwaiter();
    }
    private async Task NetworkFailed() {
        if(_isNetworkFailed)
            return;
        _isNetworkFailed = true;
        AsyncOperationHandle<GameObject> createNetworkFailedHandle = Addressables.InstantiateAsync("NetworkFailedUI", Vector3.zero, Quaternion.identity, null, true);
        while(!createNetworkFailedHandle.IsDone)
           await Task.Yield();
        GameObject staticCanvas = UnityTool.FindGameObject("StaticCanvas");
        createNetworkFailedHandle.Result.transform.SetParent(staticCanvas.transform);
        createNetworkFailedHandle.Result.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        createNetworkFailedHandle.Result.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        createNetworkFailedHandle.Result.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        _networkFailedUI = createNetworkFailedHandle.Result;
        if(await Reconnect()) {
            if(_networkFailedUI != null)
                Addressables.ReleaseInstance(_networkFailedUI);
            _isNetworkFailed = false;
            _networkFailedUI = null;
        }
    }
    private async Task<bool> Reconnect() {
        while(!await DataRequest.Ping(_pingAddress)) {
            Debug.Log("重新連線失敗");
        }
        return true;
    }
    #endregion
}
