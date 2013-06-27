var explosion : GameObject;
var causesExplosion : boolean;
var model : GameObject;
var colideCount = 0;
var collided = false;

function Start(){

	Invoke("Explode", 12.2);	
}
function Explode(){
	if (causesExplosion){
		var newexplosion = Instantiate(explosion, gameObject.transform.position, Random.rotation );
		var radius = 75.0;
		var power = 10000.0;
		var explosionPos = gameObject.transform.position;
		
		var colliders = Physics.OverlapSphere (explosionPos, radius);
   		
   		for (var hit in colliders) {
        	if (hit == null)
	       		continue;
	   		if (!hit.isTrigger && hit.rigidbody){
				hit.gameObject.SendMessage("OnExplosion", explosionPos, SendMessageOptions.DontRequireReceiver );
			}
	   	} 	 
	   	
	   	colliders = Physics.OverlapSphere (explosionPos, radius); 		
	   	
		for (var hit in colliders) {
 			if (hit == null)
       			continue;
        	if (!hit.isTrigger && hit.rigidbody){
				hit.rigidbody.AddExplosionForce(power, explosionPos, radius, 0);
			}
		}
	}
	Invoke ("DestroyNow", 0);
}
function DestroyNow(){
	DestroyObject(gameObject);
}