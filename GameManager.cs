using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject[] obstaclePrefabs;
	public Player player;
	public TextMesh infoText;
	public GameObject finishLine;

	public float spawnDistanceFromPlayer = 20f;
	public float spawnDistanceFromObstacles = 5f;
	public float finishLinePosition = 200f;

	private float obstaclePointer;

	private float gameTimer;
	private float finalTime;
	private bool isGameOver = false;

	private float gameOverTimer = 3f;

	// Use this for initialization
	void Start () {
		finishLine.transform.position = new Vector3 (0, 0, finishLinePosition);
	}
	
	// Update is called once per frame
	void Update () {
		if (obstaclePointer < player.transform.position.z) {
			obstaclePointer += spawnDistanceFromObstacles;

			GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

			GameObject obstacleObject = Instantiate (obstaclePrefab);
			obstacleObject.transform.position = new Vector3 (
				Random.Range(-4f, 4f),
				obstacleObject.transform.position.y,
				player.transform.position.z + spawnDistanceFromPlayer
			);
		}

		gameTimer += Time.deltaTime;

		if (isGameOver == false) {
			if (player.reachedFinishLine == true) {
				isGameOver = true;

				finalTime = gameTimer;
			}

			infoText.text = "Time: " + Mathf.FloorToInt (gameTimer);
		} else {
			infoText.text = "Game over!\nYour time: " + Mathf.FloorToInt (finalTime);

			gameOverTimer -= Time.deltaTime;

			if (gameOverTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		}
	}
}