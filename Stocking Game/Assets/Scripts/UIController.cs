using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class UIController : MonoBehaviour {

	public void TresureHunt (){
		
		//It loads the Game scene, the scene called Day
		SceneManager.LoadScene ("Main Level");
	}

	public void Enter(){

		//It loads the Game scene, the scene called Day
		SceneManager.LoadScene ("Main Level");
	}

	public void Quit (){

		//It loads the Game scene, the scene called  Quit
		Application.Quit();
	}

  
}
