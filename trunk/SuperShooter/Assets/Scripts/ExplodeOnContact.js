var explosion : GameObject;
var causesExplosion : boolean;
var model : GameObject;
var colideCount = 0;
var collided = false;
function OnCollisionEnter (c : Collision) : void{
	if (!collided && c.contacts.length > 0){
		
		collided = true;
		var contact = c.contacts[0];
		
		
		var collider : Collider = GetComponent(Collider);
		var renderer : Renderer = model.GetComponent(Renderer);
	
		DestroyObject(model);
		collider.isTrigger = true;
		rigidbody.velocity = Vector3.zero;
	
	
		var rot = Random.rotation;
		Instantiate(explosion, contact.point + contact.normal * 0, rot);
		
		
		if (causesExplosion){
			var radius =20.0;
			var power = 5000.0;
			var explosionPos = transform.position;
  	  		var colliders : Collider[] = Physics.OverlapSphere (explosionPos, radius);
    
    		for (var hit in colliders) {
        		if (hit == null)
            		continue;
        		if (!hit.isTrigger && hit.rigidbody){
					hit.gameObject.SendMessage("OnExplosion", contact.point, SendMessageOptions.DontRequireReceiver );
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
    
	}
	Invoke ("DestroyNow", 3);
}

function DestroyNow ()
{
	DestroyObject(gameObject);
}