using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class NetworkMobile : MonoBehaviour
{
    [SerializeField] private Transform head;

    private PhotonView _photonView;
    private Transform _headOrigin;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
        if (_photonView.IsMine == false)
            return;

        PlayerMobile origin = FindObjectOfType<PlayerMobile>();
        _headOrigin = origin.transform.Find("Main Camera");
    }

    private void Start()
    {
        if (_photonView.IsMine == false)
            return;

        head.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_photonView.IsMine == false)
            return;

        SetWorldPosition(head, _headOrigin);
    }

    private void SetWorldPosition(Transform target, Transform origin)
    {
        target.position = origin.position;
        target.rotation = origin.rotation;
    }
}