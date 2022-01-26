using Photon.Pun;
using UnityEngine;

public class PlayerSpawnerByDevice : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerDesktop;
    [SerializeField] private GameObject playerMobile;
    [SerializeField] private GameObject networkDesktop;
    [SerializeField] private GameObject networkMobile;

    private GameObject spawnedPlayer;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
#if UNITY_STANDALONE
        playerDesktop.SetActive(true);
        spawnedPlayer = PhotonNetwork.Instantiate(networkDesktop.name, Vector3.zero, Quaternion.identity);
#endif
#if UNITY_ANDROID || UNITY_IPHONE
        playerMobile.SetActive(true);
        spawnedPlayer = PhotonNetwork.Instantiate(networkMobile.name, Vector3.zero, Quaternion.identity);
#endif
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayer);
    }
}
