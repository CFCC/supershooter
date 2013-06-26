var fireRate = 2.0;
var projectilePrefab : GameObject;
var projectileSpawn : GameObject;
var projectileSpeed = 10;
var projectileOrientToPlayer : boolean = false;
var inputButtonString = "Fire1";
var ammoCount = 10;
var ammoLabel : GUIText;
var ammoType = "Rockets";
var ammoPickupSound : AudioClip;
var ammoDropPrefab : GameObject;
var player : GameObject;

private var lastFire = -10000.0;

function OnGUI(){
	if (ammoLabel)
		ammoLabel.text = ammoType + ": " + ammoCount;	
}
function FixedUpdate () {
	
	// Pickup appropriate ammo
	var ammoPacks = GameObject.FindGameObjectsWithTag ("Ammo");
	for (var ammoPackObject in ammoPacks){
		var pos = player.transform.position;
		var rot = player.transform.rotation;
		var dist = Vector3.Distance(pos, ammoPackObject.transform.position);
		var ammoPack = ammoPackObject.GetComponent(Ammo);
 		if (dist < 3.0 && ammoPack.ammoType == ammoType){
 			Instantiate(ammoPack.pickupSound, pos, rot);
 	  		ammoCount+=ammoPack.ammoQuantity;
	 	  	Destroy(ammoPackObject);
 	  	}
	}
    
    
	// Fire Weapon
	if (Input.GetButton (inputButtonString) && ammoCount > 0) {
		var t = Time.time;
		if (lastFire + fireRate < t){
			var trans = projectileSpawn.transform;
			var projectile = Instantiate(projectilePrefab, trans.position, projectileOrientToPlayer ? trans.rotation : Quaternion.identity);
			if(ammoType == "Dudes"){
				projectile.name = "Decoy";
			}
			projectile.GetComponent(Rigidbody).velocity = projectileSpawn.transform.forward * projectileSpeed;
			
			ammoCount -= 1;
			lastFire = t;
		}
	}
}