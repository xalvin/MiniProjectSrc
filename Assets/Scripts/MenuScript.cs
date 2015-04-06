using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
  private GUISkin skin;

  void Start()
  {
    skin = Resources.Load("GUISkin") as GUISkin;
  }

  void OnGUI()
  {
    GUI.skin = skin;


    if (GUI.Button(new Rect(Screen.width/3,Screen.height/8*1,Screen.width/3,Screen.height/8),"Start"))
    {
      	Application.LoadLevel("LevelSelection"); 
    }
    if (GUI.Button(new Rect(Screen.width/3,Screen.height/8*3,Screen.width/3,Screen.height/8),"Achievements"))
    {
      	Application.LoadLevel(""); 
    }
    if (GUI.Button(new Rect(Screen.width/3,Screen.height/8*5,Screen.width/3,Screen.height/8),"Record"))
    {
      	Application.LoadLevel(""); 
    }
    if (GUI.Button(new Rect(Screen.width/3,Screen.height/8*7,Screen.width/3,Screen.height/8),"Exit"))
    {
		Application.Quit();
    }
  }
}