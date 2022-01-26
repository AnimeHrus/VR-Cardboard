using Photon.Pun;
using Photon.Voice.Unity;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PhotonView), typeof(Recorder))]
public class NetworkDekstop : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform body;
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;
    [SerializeField] private InputActionReference micSwitchReference = null;

    private PhotonView _photonView;
    private Transform _headOrigin;
    private Transform _leftHandOrigin;
    private Transform _rightHandOrigin;
    private Recorder _recorder;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
        _recorder = GetComponent<Recorder>();
        if (_photonView.IsMine == false)
            return;

        PlayerDesktop origin = FindObjectOfType<PlayerDesktop>();
        _headOrigin = origin.transform.Find("Camera Offset/Main Camera");
        _leftHandOrigin = origin.transform.Find("Camera Offset/LeftHand Controller");
        _rightHandOrigin = origin.transform.Find("Camera Offset/RightHand Controller");
    }

    private void Start()
    {
        if (_photonView.IsMine == false)
            return;

        head.gameObject.SetActive(false);
        body.gameObject.SetActive(false);
        leftHand.gameObject.SetActive(false);
        rightHand.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_photonView.IsMine == false)
            return;

        SetWorldPosition(head, _headOrigin);
        SetWorldPosition(leftHand, _leftHandOrigin);
        SetWorldPosition(rightHand, _rightHandOrigin);
    }

    private void OnEnable()
    {
        micSwitchReference.action.started += switchMicActive;
    }

    private void OnDisable()
    {
        micSwitchReference.action.started -= switchMicActive;
    }

    private void SetWorldPosition(Transform target, Transform origin)
    {
        target.position = origin.position;
        target.rotation = origin.rotation;
    }

    private void switchMicActive(InputAction.CallbackContext context)
    {
        _recorder.TransmitEnabled = !_recorder.TransmitEnabled;
    }
}