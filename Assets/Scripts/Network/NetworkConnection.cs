using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkConnection : MonoBehaviourPunCallbacks
{
    private const string _roomName = "CrossMultiTest";
    
    private void Start()
    {
        ConnectToServer();
    }

    private void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try connect to server. . .");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server.");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom(_roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room.");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined.");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
