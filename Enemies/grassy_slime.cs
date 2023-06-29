using Godot;
using System;

public partial class grassy_slime : CharacterBody2D
{
	Sprite2D sprite;
	RayCast2D bottomLeft;
	RayCast2D bottomRight;
	private Vector2 velocity;
	private float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	private int speed = 30;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite");
		bottomLeft = GetNode<RayCast2D>("LeftRaycast");
		bottomRight = GetNode<RayCast2D>("RightRaycast");
		velocity.X = speed;
		
	}
	
	public  void _PhysicsProcess(double delta)
    {
		velocity.Y += (float)(gravity*delta);
		if(velocity.Y>gravity){
			velocity.Y = gravity;
		}
		if(!bottomRight.IsColliding()){
			velocity.X = -speed;
			sprite.FlipH = true;
		}else if(!bottomLeft.IsColliding()){
			velocity.X = speed;
			sprite.FlipH = false;
		}
		//this is your problem now guys -Neil
		MoveAndSlide();
    }
    
}
