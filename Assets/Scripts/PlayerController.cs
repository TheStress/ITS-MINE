using UnityEngine;

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
        gridManager.MoveActor(gameObject,  new Vector2(0,0));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(left)) {
            gridManager.MoveActor(gameObject, tileActor.position + new Vector2(-1, 0));
        }
        if (Input.GetKey(right)) {
            gridManager.MoveActor(gameObject, tileActor.position + new Vector2(1, 0));
        }
        if (Input.GetKey(up)) {
            gridManager.MoveActor(gameObject, tileActor.position + new Vector2(0, 1));
        }
        if (Input.GetKey(down)) {
            gridManager.MoveActor(gameObject, tileActor.position + new Vector2(0, -1));
        }
    }
}
