using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.InputSystem.Interactions;

public class GameManager : MonoBehaviour
{
    GridManager gridManager;
    TileActor[] tileActors;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        gridManager = FindFirstObjectByType<GridManager>();
        tileActors = FindObjectsByType<TileActor>(FindObjectsSortMode.None);

        foreach (TileActor actor in tileActors) {
            // Setting actors to random locations
            actor.gameObject.SetActive(false);
        }

        StartGame();
    }

    public void StartGame() {
        gridManager.InitalizeGrid();

        foreach (TileActor actor in tileActors) {
            actor.gameObject.SetActive(true);
            // Setting actors to random locations
            Vector2 randPosition = gridManager.GetRandomValidPosition();
            if (randPosition.x > 0) {
                gridManager.MoveActor(actor.gameObject, randPosition);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
