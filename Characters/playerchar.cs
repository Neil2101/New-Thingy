using Godot;
using System;
/*
public partial class player_char : CharacterBody2D
{
	directionX = 0;
	directionY = 0;
	public override void _Input(InputEvent @event){
		if (@event is InputEventKey keyEvent && keyEvent.Pressed){
			if (keyEvent.Keycode == Key.W){
				directionY += 100;
			}
			if (keyEvent.Keycode == Key.A){
				DirectionX-=100;
			}
			if (keyEvent.Keycode == Key.S){
				directionY -= 100;
			}
			if (keyEvent.Keycode == Key.D){
				DirectionX+=100;
			}
		}
		else{
			directionX -= 99;
			directiony -= 2;
		}
	}
}
*/

public partial class playerchar : CharacterBody2D
{
	[Export]
	public int Speed { get; set; } = 50;
	public int Gravity { get; set; } = 1;
	public float yvel = 0;
	public touching_ground = false;
	public void GetInput()
	{
		Vector2 yv_vector = new Vector2(0,yvel);
		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = (inputDirection * Speed) - yv_vector; //<-- the direction vector multiplied by speed - down velocity
		yvel -= Gravity;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}


private void _on_area_2d_body_entered(Node2D body)
{
	touching_ground = true;
}


private void _on_area_2d_area_shape_exited(Rid area_rid, Area2D area, long area_shape_index, long local_shape_index)
{
	touching_ground = false;
}
