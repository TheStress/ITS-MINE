using UnityEngine;

public class PlayerActor : TileActor
{
    public float score;
    public bool stunned = false;
    public float stunDuration = 2;
    public float timer;

    public void GiveScore(float amount) {
        score += amount;
    }
    private void Update() {
        timer -= Time.deltaTime;
        if(timer <= 0 && stunned == true) {
            stunned = false;
        }
    }

    public override void TakeAttack(GameObject source) {
        if(!stunned) {
            stunned = true;
            timer = stunDuration;
        }
    }

    public override bool CanAttack() {
        return true;
    }
}
