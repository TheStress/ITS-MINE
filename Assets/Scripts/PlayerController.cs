using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;


    TileActor tileActor;
    GridManager gridManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tileActor = GetComponent<TileActor>();
        gridManager = FindFirstObjectByType<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(left)) {
            MoveInput(new Vector2(-1, 0));
        }
        if (Input.GetKeyDown(right)) {
            MoveInput(new Vector2(1, 0));
        }
        if (Input.GetKeyDown(up)) {
            MoveInput(new Vector2(0, 1));
        }
        if (Input.GetKeyDown(down)) {
            MoveInput(new Vector2(0, -1));
        }
    }

    public void MoveInput(Vector2 inputDir) {
        Vector2 newPos = tileActor.position + inputDir;
        if (gridManager.WithinGrid(newPos)) {
            if (gridManager.GetObjectOnTile(newPos) == null) {
                gridManager.MoveActor(gameObject, newPos);
            }
            else {
                gridManager.AttackTile(gameObject, newPos);
            }
        }
    }
}