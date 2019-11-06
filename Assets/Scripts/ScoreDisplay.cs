using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDisplay : MonoBehaviour
{
    Text _txt;

    private void Awake()
    {
        _txt = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        _txt.text = GameSession.Instance.GetScore().ToString();
    }
}
