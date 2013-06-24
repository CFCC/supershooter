
private var t = Time.time;
function Update () {
	if (audio){
		if (Time.time - t > 5 && !audio.isPlaying){
			Destroy(audio);
			Destroy(this);
		}
	}else{
		Destroy(this);
	}
}