var triggerTag : String;
var destination : GameObject;
var objectToRelocate : GameObject;


function OnTriggerEnter (c : Collider) : void{
		
		if (c.gameObject.tag == triggerTag){
			
			objectToRelocate.transform.position = destination.transform.position;
		}
    
}