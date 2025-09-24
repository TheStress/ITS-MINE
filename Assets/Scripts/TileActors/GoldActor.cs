using UnityEditor;
using UnityEngine;

public class GoldActor : TileActor
{
    public int health = 1;

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
