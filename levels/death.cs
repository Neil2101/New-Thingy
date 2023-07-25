using Godot;
using System;

public partial class death : Node
{
	
	public override void _Ready()
	{
		var start = GetNode<Button>("Start");
		start.Pressed += buttonstart;
		var quit = GetNode<Button>("Quit");
		quit.Pressed += buttonquit;
	}

	//what the button does
	private void buttonstart()
	{
    	GetTree().ChangeSceneToFile("levels/Level1.tscn");
	}
	private void buttonquit()
	{
    	GetTree().Quit();
	}
}
