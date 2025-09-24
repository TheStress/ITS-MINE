using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public PlayerActor actor;
    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = actor.score.ToString();
    }
}
