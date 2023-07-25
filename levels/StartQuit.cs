using Godot;
using System;

public partial class StartQuit : Node
{
	// Called when the node enters the scene tree for the first time.
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
