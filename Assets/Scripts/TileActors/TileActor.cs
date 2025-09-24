using UnityEngine;

public abstract class TileActor : MonoBehaviour
{
    public Vector2 position;
    GridManager grid;
    private void Start() {
        grid = FindFirstObjectByType<GridManager>();
    }

    public abstract void TakeAttack(GameObject source);
    public abstract bool CanAttack();
}