using UnityEngine;

public abstract class TileActor : MonoBehaviour
{
    public Vector2 position;
    public abstract void TakeAttack(GameObject source);
    public abstract bool CanAttack();
}