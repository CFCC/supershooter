var explosion : GameObject;
var causesExplosion : boolean;
var model : GameObject;
var colideCount = 0;
var collided = false;

function DestroyNow ()
{
	DestroyObject(gameObject);
}