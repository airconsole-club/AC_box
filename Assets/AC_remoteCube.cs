using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class AC_remoteCube : MonoBehaviour {
	Transform cube_transform;
	private float movement_speed = 0.1f;
	 
	void Start () {
		cube_transform = GetComponent<Transform>();

	}
	void Awake () {
		AirConsole.instance.onMessage += OnMessage;		
		print("Awake!!");
	}
	void update(){
		var cur_position = new { action = "move",
							    info = new { amount = 5, torque = 234.8f }
								};
		// if(cube_transform.localPosition.x >= 2 && cube_transform.localPosition.z >= 2){
		// 	//post location to web client
			
		// 	AirConsole.instance.Message(	AirConsole.convertPlayerNumberToDeviceId(0)	, message);
		// }
	}
	void OnMessage (int from, JToken data){
		//Debug.Log (">>>MESSAGE (" +from+ "):" + data);
			switch(data["action"].ToString()	){
				case "right":
					cube_transform.localPosition += new Vector3(movement_speed, 0,0);
					break;
				case "left":
					cube_transform.localPosition += new Vector3(-movement_speed, 0,0);
					break;
				case "up":
					cube_transform.localPosition += new Vector3(0,0,movement_speed);
					break;
				case "down":
					cube_transform.localPosition += new Vector3(0,0,-movement_speed);
					break;
				case "return":
					cube_transform.localPosition = new Vector3(0, 0,0);
					break;	
				default:
					print(data["action"]+ "DOES NOT RESPOND!");
					break;

			
		}
		
	}

	void OnDestory(){
		if(AirConsole.instance != null){
			AirConsole.instance.onMessage -= OnMessage;
		}
	}
	// // Use this for initialization
	// void Start () {
		
	// }
	
	// // Update is called once per frame
	// void Update () {
		
	// }
}
