var zombie : GameObject;
var spawnRate = 5;

private var lastzombiespawn = 0; 


function Awake (){



}


function Update () {

	var dif ;
	dif = Time.time-lastzombiespawn;

	if (dif > spawnRate){
		var position = Vector3(Random.Range(100, 200), 10, Random.Range(100, 200));
		var newZombie = Instantiate(zombie, position, Quaternion.identity);
		var zombieAI = newZombie.GetComponent("ZombieAI");
		
		lastzombiespawn = Time.time;
	}

}