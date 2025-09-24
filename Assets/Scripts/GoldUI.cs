using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour {
    public GoldActor actor;
    public TMP_Text text;

    // Update is called once per frame
    void Update() {
        text.text = actor.health.ToString();
    }
}
