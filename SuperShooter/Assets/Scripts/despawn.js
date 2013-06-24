
// Use this for initialization
var time = 5;
function Start () {
yield WaitForSeconds(5);
collider.isTrigger = true;
Destroy (gameObject, time);
}