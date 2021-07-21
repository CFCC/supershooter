using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public partial class MainMenuGUI : MonoBehaviour
{
    public GUISkin customSkin;
    public bool isMenuShown;
    public Camera cameraToMask;
    public GameObject player;
    private const int HIDE_GUI = 2147483646;
    private const int SHOW_GUI = 2147483647;

    public virtual void OnGUI()
    {
        Event e = Event.current;
        if (e != null)
        {
            switch (e.type)
            {
                case EventType.KeyDown:
                    switch (e.keyCode)
                    {
                        case KeyCode.Escape:
                            this.isMenuShown = !this.isMenuShown;
                            break;
                    }

                    break;
            }
        }

        this.DoLayout();
        Cursor.visible = this.isMenuShown;
        if (this.cameraToMask)
        {
            this.cameraToMask.cullingMask = this.isMenuShown
                ? this.cameraToMask.cullingMask & HIDE_GUI
                : this.cameraToMask.cullingMask | SHOW_GUI;
        }

        if (this.player)
        {
            foreach (Component fpsWalker in this.player.GetComponentsInChildren(typeof(FPSWalker)))
            {
                ((Behaviour) fpsWalker).enabled = !this.isMenuShown;
            }

            foreach (Component mouseLook in this.player.GetComponentsInChildren(typeof(MouseLook)))
            {
                ((Behaviour) mouseLook).enabled = !this.isMenuShown;
            }

            foreach (Component gunTrigger in this.player.GetComponentsInChildren(typeof(GunTrigger)))
            {
                ((Behaviour) gunTrigger).enabled = !this.isMenuShown;
            }
        }
    }

    public virtual void DoLayout()
    {
        int guiH = 600;
        int guiW = 500;
        GUI.skin = this.customSkin;
        if (this.isMenuShown)
        {
            GUILayout.BeginArea(new Rect((Screen.width / 2) - (guiW / 2), ((Screen.height / 2) - (guiH / 2)) + 80, guiW,
                guiH));
            GUILayout.BeginVertical(this.customSkin.box, new GUILayoutOption[] { });
            GUILayout.Label("Menu", new GUILayoutOption[] { });
            GUILayout.Space(50);

            bool skirmish = false;
            bool campaign = false;
            bool campaign2 = false;
            bool exit = false;
            bool leave = false;

            int activeSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            if (activeSceneBuildIndex != 1 && activeSceneBuildIndex != 2 && activeSceneBuildIndex != 3)
            {
                skirmish = GUILayout.Button("Practice", new GUILayoutOption[] { });
                campaign = GUILayout.Button("Campaign", new GUILayoutOption[] { });
                campaign2 = GUILayout.Button("Campaign2", new GUILayoutOption[] { });
            }

            GUILayout.FlexibleSpace();
            if (activeSceneBuildIndex != 0)
            {
                leave = GUILayout.Button("Leave Game", new GUILayoutOption[] { });
            }

            exit = GUILayout.Button("Exit", new GUILayoutOption[] { });
            GUILayout.EndVertical();
            GUILayout.EndArea();
            if (exit)
            {
                Application.Quit();
            }
            else
            {
                if (leave)
                {
                    SceneManager.LoadScene(0);
                    // Application.LoadLevel(0);
                }
                else
                {
                    if (skirmish)
                    {
                        SceneManager.LoadScene(1);
                        //Application.LoadLevel(1);
                    }
                    else
                    {
                        if (campaign)
                        {
                            SceneManager.LoadScene(2);
                            // Application.LoadLevel(2);
                        }
                        else
                        {
                            if (campaign2)
                            {
                                SceneManager.LoadScene(3);
                                // Application.LoadLevel(3);
                            }
                        }
                    }
                }
            }
        }
    }
}