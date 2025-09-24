using UnityEngine;

public class PlayerActor : TileActor
{
    public float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveScore(float amount) {
        score += amount;
    }

    public override void TakeAttack(GameObject source) {
        throw new System.NotImplementedException();
    }

    public override bool CanAttack() {
        throw new System.NotImplementedException();
    }
}
