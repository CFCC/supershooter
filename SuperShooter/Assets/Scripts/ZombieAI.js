var corpse : GameObject;

private var health = 100;

function Update () {

var moveSpeed = 10;
var rotationSpeed = 5;
	var aggroDistance = 100;
	var targetPlayer : GameObject;
	var targetPlayerDistance = aggroDistance;
	
	var zombiePos = transform.position;	
	
	
	//find everything thats near
	var colliders : Collider[] = Physics.OverlapSphere (zombiePos, aggroDistance);
	
	// loop through everything that we found to find players
	for (var hit in colliders) {
		if (hit == null)
				continue;
				
		if(hit.gameObject.tag == "Player"){
			// when we find a player, calculate the distance to that players
			var distance = Vector3.Distance(transform.position, hit.gameObject.transform.position);
			
			//if the player is closer than the previously found player than store it as the player to attack

			if (distance <= aggroDistance && (targetPlayer != null || targetPlayerDistance >= distance )){
					targetPlayer = hit.gameObject;
					targetPlayerDistance = distance;
				
			
			}
			
		
		}
	}
	
		
	if (targetPlayer != null){
		
		// reorient the zombie to the player that is closest
		//var v : Vector3; 
		
		// this is interfeering with the physics and the zombie twitches
		//var pPos = targetPlayer.transform.position;
	
		//v = Vector3(pPos.x, transform.position.y,pPos.z);

		//transform.LookAt(v);
	
		transform.rotation = Quaternion.Slerp(transform.rotation,
	    	Quaternion.LookRotation(targetPlayer.transform.position - transform.position), rotationSpeed*Time.deltaTime);
	 	transform.position += transform.forward * moveSpeed * Time.deltaTime;
	
	
	}
			
		
		
		
		
				
		
		
	
	
}
function OnExplosion (explosionPosition : Vector3){
	lookAtPlayer = false;
	
	var radius = 20;
	var maxDamage = 3000;
	
	var distance = Vector3.Distance(transform.position, explosionPosition);
	
	var percentDamage = (radius - distance) / radius;
	
	percentDamage = Mathf.Max(percentDamage, 0);
	
	var damage = percentDamage * maxDamage;
	
	health = health - damage;
	
	if (health <= 0){
		Instantiate(corpse, transform.position, transform.rotation);
		Destroy(gameObject);
	
	}
	
}