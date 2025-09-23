using UnityEngine;

public class GameManager : MonoBehaviour
{
    GridManager gridManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        gridManager = FindFirstObjectByType<GridManager>();
        gridManager.InitalizeGrid();

        TileActor[] tileActors = FindObjectsByType<TileActor>(FindObjectsSortMode.None);
        foreach(TileActor actor in tileActors) {
            // Setting actors to random locations
            Vector2 randPosition = gridManager.GetRandomValidPosition();
            if(randPosition.x > 0) {
                gridManager.MoveActor(actor.gameObject, randPosition);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
