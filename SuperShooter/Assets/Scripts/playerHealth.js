#pragma strict
var triggerTag : String;
var destination : GameObject;
var objectToRelocate : GameObject;
var startHealth = 100;
var healthGui : GUIText;
private var currentHealth = startHealth;



function Update(){
	healthGui.text ="Health: " + currentHealth.ToString();
	if (currentHealth <= 0){
			
		objectToRelocate.transform.position = destination.transform.position;
		currentHealth = startHealth;
	}

}

function OnCollisionEnter (c : Collision) : void{
		
		if (c.gameObject.tag == triggerTag){
			
			currentHealth -= 10;
			
		}
    Debug.Log("hit~! : " + currentHealth);
}
						

    
