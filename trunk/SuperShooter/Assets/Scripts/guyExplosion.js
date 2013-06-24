var explosion : GameObject;
var causesExplosion : boolean;
var model : GameObject;
var colideCount = 0;
var collided = false;
yield WaitForSeconds (5);	
		var renderer : Renderer = model.GetComponent(Renderer);
	
		DestroyObject(model);
			
			
		
		if (causesExplosion){
			var radius =20.0;
			var power = 5000.0;
			var explosionPos = transform.position;
  	  		  					
			   
			
    		
    }
	
	Invoke ("DestroyNow", 3);


function DestroyNow ()
{
	DestroyObject(gameObject);
}