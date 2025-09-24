using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class GoldActor : TileActor
{
    Vector2 healthRange = new Vector2(5, 10);
    public int health = 1;
    public UnityEvent OnDeath = new UnityEvent();

    private void Start() {
        health = Random.Range((int)healthRange.x, (int)healthRange.y);
    }

    public override void TakeAttack(GameObject source) {
        health--;
        source.GetComponent<PlayerActor>().GiveScore(1);

        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public override bool CanAttack() {
        throw new System.NotImplementedException();
    }
}
