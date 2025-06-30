using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tile : MonoBehaviour
{
    [System.Serializable]
    //tells us the color of the tile which indicates its state
    public class State
    {
        public Color fillColor;
        public Color outlineColor;

    }
    //things which will appear on a tile
    private TextMeshProUGUI text;
    private Image fill;
    private Outline outline;
    //creates a state for the tile
    public State state { get; private set; }
    //initalizes a char called letter
    public char letter { get; private set; }

    private void Awake()
    {
        //Lets each tile change its text, fill color, and outline color
        text = GetComponentInChildren<TextMeshProUGUI>();
        fill = GetComponent<Image>();
        outline = GetComponent<Outline>();
    }

    //Sets text on a block to the character which was entered
    public void SetLetter(char letter)
    {
        this.letter = letter;
        text.text = letter.ToString();
    }
    //what each tile state will look like
    public void setState(State state) 
    {
        this.state = state;
        fill.color = state.fillColor;
        outline.effectColor = state.outlineColor;
    }
}
