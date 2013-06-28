var customSkin : GUISkin;
var isMenuShown : boolean = false;
var cameraToMask : Camera;
var player : GameObject;

private var HIDE_GUI = 0x7FFFFFFF;
private var SHOW_GUI = 0x80000000;

function OnGUI() {
	var e = Event.current;
	if (e){
		switch(e.type){
			case EventType.KeyDown:
				switch(e.keyCode){
					case KeyCode.Escape:
						isMenuShown = !isMenuShown;	
						break;
				}
				break;
		}	
	}
	

		DoLayout();
		
		
	Screen.showCursor=isMenuShown;
	
	if (cameraToMask)
		cameraToMask.cullingMask = isMenuShown ? (cameraToMask.cullingMask & HIDE_GUI) : (cameraToMask.cullingMask | SHOW_GUI);
	
	if (player){
		for (var fpsWalker in player.GetComponentsInChildren(FPSWalker))
			fpsWalker.enabled = !isMenuShown;
		for (var mouseLook in player.GetComponentsInChildren(MouseLook))
			mouseLook.enabled = !isMenuShown;
		for (var gunTrigger in player.GetComponentsInChildren(GunTrigger))
			gunTrigger.enabled = !isMenuShown;
	}
	
}

function DoLayout(){


	var guiH = 600;
	var guiW = 500;

	
	GUI.skin = customSkin;
	if (isMenuShown ){
		
		GUILayout.BeginArea(Rect(Screen.width / 2 - guiW/2, Screen.height / 2 - guiH/2 + 80, guiW, guiH));
	
		GUILayout.BeginVertical (customSkin.box);
		GUILayout.Label("Menu");
		GUILayout.Space(50);
		
		if (Application.loadedLevel != 1 && Application.loadedLevel != 2 && Application.loadedLevel != 3){
			var skirmish = GUILayout.Button("Practice");
			var campaign = GUILayout.Button("Campaign");
			var campaign2 = GUILayout.Button("Campaign2");
		}
		GUILayout.FlexibleSpace();
		
		if (Application.loadedLevel != 0)
			var leave = GUILayout.Button("Leave Game");
		var exit = GUILayout.Button("Exit");
		GUILayout.EndVertical();
		GUILayout.EndArea ();
	
		if (exit){
			Application.Quit();
		}else if (leave){
			Application.LoadLevel(0);	
		}else if (skirmish) {
			Application.LoadLevel(1);
		}else if (campaign){
			Application.LoadLevel(2);
		}else if (campaign2){
			Application.LoadLevel(3);			
		}
		
	}
}