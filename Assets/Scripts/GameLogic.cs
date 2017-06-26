using UnityEngine;

public class GameLogic : MonoBehaviour {
	public GameObject player;
	public GameObject startUI, restartUI;
	public GameObject startPoint, playPoint, restartPoint;

	public bool playerWon = false;

	// Use this for initialization
	void Start() {
		player.transform.position = startPoint.transform.position;
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonDown(0) && player.transform.position == playPoint.transform.position) {
			puzzleSuccess();
		}
	}

	public void startPuzzle() { //Begin the puzzle sequence
		toggleUI();
		iTween.MoveTo(player,
			iTween.Hash(
				"position", playPoint.transform.position,
				"time", 2,
				"easetype", "linear"
			)
		);

	}

	public void resetPuzzle() { //Reset the puzzle sequence
		player.transform.position = startPoint.transform.position;
		toggleUI();
	}


	public void puzzleSuccess() { //Do this when the player gets it right
		iTween.MoveTo(player,
			iTween.Hash(
				"position", restartPoint.transform.position,
				"time", 2,
				"easetype", "linear"
			)
		);
	}
	public void toggleUI() {
		startUI.SetActive(!startUI.activeSelf);
		restartUI.SetActive(!restartUI.activeSelf);
	}

}
