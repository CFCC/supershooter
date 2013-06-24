
function Update(){
	if (Input.GetButton("Fire3")){
		var obj : GameObject;
		var i = 0;
		obj = GameObject.Find("BowlingBall(Clone)");
		if (obj){
			DestroyObject(obj);
		}
	}
}