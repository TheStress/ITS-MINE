using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine.UIElements;
public class GridManager : MonoBehaviour
{
    public List<List<GameObject>> grid = new List<List<GameObject>>(); // The Grid
    public int width = 10; // The width of the grid
    public int height = 10;  // The hight of the grid
    public float tileSize = 2; // How big each tile is, this is for the grid generation and has nothing to do with
    public GameObject tilePrefab; // The tile prefab that is spawned in 






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    public void InitalizeGrid() {
        // Instantiate List
        for (int i = 0; i < width; i++) {
            List<GameObject> newList = new List<GameObject>(); // Creating new list
            for (int j = 0; j < height; j++) {
                newList.Add(null); // Populating that list with nothing
            }
            grid.Add(newList); // Adding the nothing list to the grid
        }

        // Generate Grid
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {
                Vector3 position = new Vector3(i * tileSize, 0, j * tileSize); // Calculating position
                GameObject currentTile = Instantiate(tilePrefab, position, Quaternion.identity); // Creating object
                grid[i][j] = currentTile; // Setting object to tile position
            }
        }
    }

    private void UpdateActorPosition() {
        GridTile currentTile; // Declaring 

        // Iteratorating through whole grid
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++) {

                currentTile = GetGridTile(new Vector2(i, j)); // Getting tile at certain position
                if (currentTile.objectOnTile != null) { // If there is something on the tile

                    // Setting object ON the tile to the position of the tile
                    currentTile.objectOnTile.transform.position = currentTile.actorPlacement.position; 
                }
            }
        }
    }

    public Vector2 GetTileActorPosition(GameObject actor) {
        for(int row = 0; row < grid.Count; row++) {
            for(int col = 0; col < grid[row].Count; col++) {

                // Checking if its the right tile
                if (GetGridTile(new Vector2(row, col)).objectOnTile == actor) {
                    return new Vector2(row, col);
                }
            }
        }

        return new Vector2(-1, -1);
    }

    public bool MoveActor(GameObject actor, Vector2 position) {
        // Checking within range
        if(!WithinGrid(position)) {
            return false;
        }

        // Checking is there is something on the tile
        if (GetObjectOnTile(position) != null) {
            return false;
        }

        // Setting new position
        Vector2 previousActorPosition = GetTileActorPosition(actor); // Getting previous position
        if (WithinGrid(previousActorPosition)) { // Checking if its a valid position
            GetGridTile(previousActorPosition).objectOnTile = null; // Setting previous position to null
        }

        GetGridTile(position).objectOnTile = actor; // Setting actor to new position
        actor.GetComponent<TileActor>().position = position;
        UpdateActorPosition();
        return true;
    }

    public void AttackTile(GameObject attacker, Vector2 position) {
        if(WithinGrid(position)) { // Checking for valid position
            GameObject victim = GetObjectOnTile(position);
            if (victim != null) { // Checking for valid object
                victim.GetComponent<TileActor>().TakeAttack(attacker);
            }
        }
    }
    public GameObject GetObjectOnTile(Vector2 position) {
        return GetGridTile(position).objectOnTile;
    }

    public GridTile GetGridTile(Vector2 position) {
        return grid[(int)position.x][(int)position.y].GetComponent<GridTile>();
    }

    public bool WithinGrid(Vector2 position) {
        if (position.x < 0 || position.x >= width) {
            return false;
        }
        if(position.y < 0 || position.y >= height) {
            return false;
        }
        return true;
    }

    public Vector2 GetRandomValidPosition() {
        // Initalizing position check
        int xPos = Random.Range(0, width);
        int yPos = Random.Range(0, height);
        Vector2 output = new Vector2(xPos, yPos);

        int attempts = 30;
        while(GetObjectOnTile(output) != null && attempts > 0) { // Checking if the object is on that tile + if we ran out of attempts
            xPos = Random.Range(0, width);
            yPos = Random.Range(0, height);
            output = new Vector2(xPos, yPos);
            attempts--;
        }
        
        if(attempts <= 0) {
            return new Vector2(-1, -1);
        }

        return output;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
