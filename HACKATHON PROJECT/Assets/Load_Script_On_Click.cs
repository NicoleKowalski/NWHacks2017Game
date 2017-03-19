using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Script_On_Click : MonoBehaviour {

	private const string typeName = "asdfASDFqwerQWERAAAAAA";
	private const string gameName = "RoomName";

    public void LoadByIndex (int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

	public void OnHostClick(){
		if (!Network.isClient && !Network.isServer) {
			StartServer ();
		} 
		else {
			Debug.Log ("Server did not initialize!");
			Debug.Log ("Is client: " + Network.isClient);
			Debug.Log ("Is server: " + Network.isServer);
		}
	}

	public void OnJoinClick(){
		RefreshHostList ();
		if (hostList != null){
			JoinServer(hostList [0]);
		}
	}

	//HOSTING
	private void StartServer(){
		Debug.Log ("StartServer was called!");
		Network.InitializeServer (4, 25000, !Network.HavePublicAddress ());
		MasterServer.RegisterHost (typeName, gameName);
		Debug.Log ("SERVER INITIALIZED :)");
	}


	//JOINING
	private HostData[] hostList;
	private void RefreshHostList(){
		MasterServer.RequestHostList(typeName);
	}
	private void JoinServer(HostData hostData){
		Network.Connect (hostData);
	}
	void OnMasterServerEvent(MasterServerEvent msEvent){
		if (msEvent == MasterServerEvent.HostListReceived)
			hostList = MasterServer.PollHostList();
	}
}
