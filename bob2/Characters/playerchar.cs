using Godot;
using System;


public partial class playerchar : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 50;
	public int Gravity { get; set; } = 10;
	public float yvel = 0;
	public void GetInput()
	{
		Vector2 yv_vector = new Vector2(0,yvel);
		Vector2 inputDirection = Input.GetVector("right", "left", "up","down");//improvised code, hope null works -Minty
		Vector2 jump = Input.GetVector(null,null,"jump",null);
		Velocity = (inputDirection * Speed) + yv_vector; //<-- the direction vector multiplied by speed + down velocity
		yvel -= Gravity;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
