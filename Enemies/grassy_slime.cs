using Godot;
using System;

public partial class grassy_slime : CharacterBody2D
{
	Sprite2D sprite;
	RayCast2D bottomLeft;
	RayCast2D bottomRight;
	RayCast2D middleLeft;
	RayCast2D middleRight;
	public Vector2 velocity;
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public int speed = 30;
	public int attack_cooldown = 2;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite2D");
		bottomLeft = GetNode<RayCast2D>("left");
		bottomRight = GetNode<RayCast2D>("right");
		middleLeft = GetNode<RayCast2D>("leftMiddle");
		middleRight = GetNode<RayCast2D>("rightMiddle");
		velocity.X = speed;		
	}
	
	public override void _PhysicsProcess(double delta)
    {	
		//GD.Print(!bottomRight.IsColliding()+"|"+!bottomLeft.IsColliding()+"|"+middleRight.IsColliding()+"|"+middleLeft.IsColliding());
		velocity.Y += (float)(gravity*delta);
		if(velocity.Y>gravity){
			velocity.Y = gravity;
		}
		if(!bottomRight.IsColliding()){
			velocity.X = -speed;
			sprite.FlipH = false;
		}else if(!bottomLeft.IsColliding()){
			velocity.X = speed;
			sprite.FlipH = true;
		}else if(middleRight.IsColliding()){
			velocity.X = speed;
			sprite.FlipH = false;
		}else if(middleLeft.IsColliding()){
			velocity.X = -speed;
			sprite.FlipH = true;
		}
		//this is your problem now guys -Neil
		Velocity = velocity;
		MoveAndSlide();
	}
	private void _on_enemy_hurtbox_body_entered(Node2D body){
		if(body is player_char){
			player_char player = body as player_char;
			player.takedamage();
		}
	}
}
