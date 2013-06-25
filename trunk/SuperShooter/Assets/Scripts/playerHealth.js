#pragma strict
var triggerTag : String;
var destination : GameObject;
var objectToRelocate : GameObject;
var startHealth = 100;
var healthGui : GUIText;
private var currentHealth = startHealth;
var blood : Texture;


function Update(){
	healthGui.text ="Health: " + currentHealth.ToString();
	if (currentHealth <= 0){
			
		objectToRelocate.transform.position = destination.transform.position;
		currentHealth = startHealth;
	}

}
function OnGUI(){
	// draws on mountain and in corner
	//Graphics.DrawTexture(Rect(10, 10, 100, 100), blood);
	GUI.DrawTexture(Rect(10,10,100,800), blood);

}

function OnCollisionEnter (c : Collision) : void{
		
		if (c.gameObject.tag == triggerTag){
			
			currentHealth -= 10;
			
			
		}
}
						

    
