using UnityEngine;

public class Services : SingletonMonobehaviour<Services>
{
    public bool clearPrefs;

    #region Variables
    [SerializeField]
    private PlayerService _playerService;
    [SerializeField]
    private AppService _appService;
    //private BackLogService _backLogService;
    //private InputService _inputService;
    [SerializeField]
    private UIService _uiService;
    [SerializeField]
    private AudioService _audioService;
    //private CameraService _cameraService;
    [SerializeField]
    private GameService _gameService;
    [SerializeField]
    public NotificationService _notificationService;
    //private ScoreService _scoreService;
    //private VibrationService _vibrationService;
    //private EffectService _effectService;
    //private SceneService _sceneService;
    //private GameElements _gameElements;
    private Canvas _canvas;
    //private DebugLogManager _debugConsole;
    //ServicesOrganizer _servicesOrganizer;
    //SignalBus _signalBus;

    #endregion

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        if (clearPrefs)
        {
            clearPrefs = false;
            PlayerPrefs.DeleteAll();
            PlayerService.ResetPlayer();
            Debug.Log("Prefs Cleared");
        }
    }

    #region public api

    public static Canvas Canvas
    {
        get { return instance._canvas; }
    }

    public static PlayerService PlayerService
    {
        get { return instance._playerService; }
    }

    public static AppService AppService
    {
        get { return instance._appService; }
    }
    public static UIService UIService
    {
        get { return instance._uiService; }
    }
    public static GameService GameService
    {
        get { return instance._gameService; }
    }

    public static AudioService AudioService
    {
        get { return instance._audioService; }
    }

    public static NotificationService NotificationService
    {
        get { return instance._notificationService; }
    }
    //public static VibrationService vibrationService
    //{
    //    get { return instance._vibrationService; }
    //}
    //public static BackLogService BackLogService
    //{
    //    get { return instance._backLogService; }
    //}

    //public static InputService InputService
    //{
    //    get { return instance._inputService; }
    //}

    //public static GameObject DebugConsole
    //{
    //    get { return instance._debugConsole.gameObject; }
    //}

    //public static GameElements GameElements
    //{
    //    get { return instance._gameElements; }
    //}



    //public static CameraService CameraService
    //{
    //    get { return instance._cameraService; }
    //}


    //public static ScoreService ScoreService
    //{
    //    get { return instance._scoreService; }
    //}

    //public static EffectService EffectService
    //{
    //    get { return instance._effectService; }
    //}

    //public static SceneService SceneService
    //{
    //    get { return instance._sceneService; }
    //}


    //public static ServicesOrganizer ServicesOrganizer
    //{
    //    get { return instance._servicesOrganizer; }
    //}

    //public static SignalBus SignalBus
    //{
    //    get { return instance._signalBus; }
    //}

    #endregion
}