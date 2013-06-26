#pragma strict
var hitWithin : int;
var triggerTag : String;
var destination : GameObject;
var objectToRelocate : GameObject;
var startHealth = 100;
var healthGui : GUIText;
private var currentHealth = startHealth;
var blood : Texture;
var timeAtStart : long;
var timeNow : long;
var rocketAmmoPrefab : GameObject;
var dudeAmmoPrefab : GameObject;


function DropAmmo(){

	var n = 0;
	for(var gunTrigger: GunTrigger in GetComponents(GunTrigger)){
		if (gunTrigger && gunTrigger.ammoCount > 0){
			var dropLocation = gameObject.transform.position;
			dropLocation.x = dropLocation.x + n*1.0;
			var ammoDrop = Instantiate(gunTrigger.ammoDropPrefab, dropLocation, gameObject.transform.rotation); 
			var newAmmo = ammoDrop.GetComponentInChildren(Ammo);
			newAmmo.ammoQuantity = gunTrigger.ammoCount;
			newAmmo.ammoType = gunTrigger.ammoType;
			gunTrigger.ammoCount = 0;
		}
		n++;
	}
}
function Update(){
	healthGui.text ="Health: " + currentHealth.ToString();
	if (currentHealth <= 0){
		DropAmmo();
		objectToRelocate.transform.position = destination.transform.position;
		currentHealth = startHealth;
	}

}


function ApplyDamage(number:int){
	currentHealth -= number;
	timeAtStart = System.DateTime.Now.Ticks;
}
						
function OnGUI(){
	// draws on mountain and in corner
	//Graphics.DrawTexture(Rect(10, 10, 100, 100), blood);
	if((timeAtStart + 2000000) > timeNow){
		GUI.DrawTexture(Rect(1900,10,-100,800), blood);
		GUI.DrawTexture(Rect(10,10,100,800), blood);
		
	}
	timeNow = System.DateTime.Now.Ticks;
	
}
    
