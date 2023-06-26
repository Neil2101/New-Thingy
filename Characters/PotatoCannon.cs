using Godot;
using System;

public partial class PotatoCannon : Sprite2D
{
//	Node playerchar = GetParent().GetParent(); // playerchar is the PlayerChar node
	Vector2 cannonxy;
	
	public Vector2 anglexy(float angle)
	{
		float x = (float) Math.Cos(angle);
		float y = (float) Math.Sin(angle);
		Vector2 result = new Vector2(x, y);
		return result;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		LookAt(GetGlobalMousePosition());
		if (Input.IsActionPressed("shoot"))
		{
			cannonxy = anglexy(RotationDegrees);
			GD.Print(RotationDegrees);
			GD.Print(cannonxy.X);
			GD.Print(cannonxy.Y);
		}
	}
}
