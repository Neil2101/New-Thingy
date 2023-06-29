using Godot;
using System;
//Only problem is arrow movement... -Neil
// ^ FIXED -astro

public partial class player_char : CharacterBody2D
{
	public const float Speed = 100.0f;
	public const float JumpVelocity = -200.0f;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("left", "right", "up", "down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
		processAnim();
	}
	//for the animation
	//main bug is that left up does not work properly -Neil
	public  void processAnim(){
		bool moveJump = Input.IsKeyPressed(Key.Space);
		bool moveLeft = Input.IsKeyPressed(Key.A); 
		bool moveRight = Input.IsKeyPressed(Key.D);
		int DirY;
		int DirX;
		Console.WriteLine(moveJump+"|"+moveLeft+"|"+moveRight);
		if (Input.IsKeyPressed(Key.D)){
			DirX = 1;
		}
		else if (Input.IsKeyPressed(Key.A)){
			DirX = -1;

		}
		else{
			DirX = 0;
		}
		if (Input.IsKeyPressed(Key.Space)){
			DirY = 1;
		}
		else{
			DirY = 0;
		}
		if (DirX != 0 || DirY != 0){
			if (DirX == 1){
				if (DirY == 1){
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("upper corner");
				}
				else{
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("right");
				}
			}
			if (DirX == -1){
				if (DirY == 1){
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("upper corner");
				}
				else{
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("right");
				}
			}
			else{
				if (DirY == 1){
						GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
						GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("up");
					}
				}
			}
		else{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("idle");
		}
	}
}