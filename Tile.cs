using Godot;
using System;

public partial class Tile : Polygon2D
{
	private int value = 0;
	private Label label;

	public int GetValue(){
		return value;
	}

	public void SetValue(int newValue){
		value = newValue;
		UpdateLabel();
	}

	public void UpdateLabel(){
		label = GetNode<Label>("Label");
		label.Text = value.ToString();
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
