using Godot;

public partial class Score : Control
{

	private Label valueLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		valueLabel = GetNode<Label>("Panel/ScoreValueLabel");
	}

	public void AddToScore(int additionalValue) 
	{
		int currentValue = int.Parse(valueLabel.Text);
		int newValue = currentValue + additionalValue;
		valueLabel.Text = "" + newValue;
	}

	public void Reset()
	{
		valueLabel.Text = "" + 0;
	}
}
