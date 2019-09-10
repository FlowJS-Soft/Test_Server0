using UnityEngine;

using Colyseus;

public class ClientComponent : MonoBehaviour
{
	public Client client;
	public Room<State> room;

	// Use this for initialization
	public async void Start () {
		client = new Client("ws://35.213.112.173:2567");

		room = await client.Join<State>("demo");
		await room.Connect();

		// OnApplicationQuit();
	}

	async void OnDestroy ()
	{
		// Make sure client will disconnect from the server
		await room.Leave ();
	}

	void OnApplicationQuit()
	{
		// Ensure the connection with server is closed immediatelly
		OnDestroy();
	}
}
