using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class TCPTestClient : MonoBehaviour {  	
	#region private members
    public string serverIpAddr = "127.0.0.1";
	public InputField IpInputField;

    public int port = 8052; 	
	private TcpClient socketConnection; 	
	private Thread clientReceiveThread; 

	private bool isConnected = false;	
	#endregion  	
	// Use this for initialization 	
	void Start () {
		//ConnectToTcpServer();     
	}  	
	// Update is called once per frame
	void Update () {         
		/*if (Input.GetKeyDown(KeyCode.Space)) {             
			SendMessage("Space");         
		}     */
	}  	
	/// <summary> 	
	/// Setup socket connection. 	
	/// </summary> 	
	public void ConnectToTcpServer () { 		
		try {  			
			//InputField ObjText = ObjFind.gameObject.GetComponent<InputField>();
            //serverIpAddr = GameObject.Find("InputFieldServ").GetComponent<Text>().text;
			//Debug.Log("ICI" + serverIpAddr);
			serverIpAddr = IpInputField.text;
			Debug.Log(serverIpAddr);

			clientReceiveThread = new Thread (new ThreadStart(ListenForData)); 			
			clientReceiveThread.IsBackground = true; 			
			clientReceiveThread.Start();  
			isConnected = true;		
		} 		
		catch (Exception e) { 			
			Debug.Log("On client connect exception " + e); 		
		} 	
	}  	
	/// <summary> 	
	/// Runs in background clientReceiveThread; Listens for incomming data. 	
	/// </summary>     
	private void ListenForData() { 		
		try { 			
			socketConnection = new TcpClient(serverIpAddr, port);  			
			Byte[] bytes = new Byte[1024];             
			while (true) { 				
				// Get a stream object for reading 				
				using (NetworkStream stream = socketConnection.GetStream()) { 					
					int length; 					
					// Read incomming stream into byte arrary. 					
					while ((length = stream.Read(bytes, 0, bytes.Length)) != 0) { 						
						var incommingData = new byte[length]; 						
						Array.Copy(bytes, 0, incommingData, 0, length); 						
						// Convert byte array to string message. 						
						string serverMessage = Encoding.ASCII.GetString(incommingData); 						
						Debug.Log("server message received as: " + serverMessage); 					
					} 				
				} 			
			}         
		}         
		catch (SocketException socketException) {             
			Debug.Log("Socket exception: "+ " on " + serverIpAddr + socketException );         
		}     
	}  	
	/// <summary> 	
	/// Send message to server using socket connection. 	
	/// </summary> 	
	private void SendMessage(string message) {         
		if (socketConnection == null) {             
			return;         
		}  		
		try { 	

			// Get a stream object for writing. 			
			NetworkStream stream = socketConnection.GetStream(); 			
			if (stream.CanWrite) {                 
				string clientMessage = message; 				
				// Convert string message to byte array.                 
				byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage); 				
				// Write byte array to socketConnection stream.                 
				stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);                 
				Debug.Log("Client sent his message - should be received by server");             
			} 
	
        
		} 		
		catch (SocketException socketException) {             
			Debug.Log("Socket exception: " + socketException);         
		}     
	} 
}