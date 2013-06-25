#pragma strict
var triggerTag : String;
var destination : GameObject;
var objectToRelocate : GameObject;
var startHealth = 100;
var healthGui : GUIText;
private var currentHealth = startHealth;
var blood : Texture;
var timeAtStart : long;
var timeNow : long;

function Update(){
	healthGui.text ="Health: " + currentHealth.ToString();
	if (currentHealth <= 0){
			
		objectToRelocate.transform.position = destination.transform.position;
		currentHealth = startHealth;
	}

}


function OnCollisionEnter (c : Collision) : void{
		
		if (c.gameObject.tag == triggerTag){
			timeAtStart = System.DateTime.Now.Ticks;
			currentHealth -= 10;
			
			
		}
}
						
function OnGUI(){
	// draws on mountain and in corner
	//Graphics.DrawTexture(Rect(10, 10, 100, 100), blood);
	Debug.Log("time at start " + timeAtStart + " " + "time now " + timeNow);
	if((timeAtStart + 2000000) > timeNow){
		GUI.DrawTexture(Rect(10,10,100,800), blood);
	}
	timeNow = System.DateTime.Now.Ticks;
	
}
    
