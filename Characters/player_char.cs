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
	public int health = 5;
	public int DirY;
	public int DirX;
	public Timer dmgtimer;
	public bool TimerStartedAtLeastOnce = false;
	public bool takendamage = false;

    public override void _Ready()
    {
        dmgtimer = GetNode<Timer>("DamageTimer");
		dmgtimer.Autostart = false;
    }
    
	public override void _PhysicsProcess(double delta)
	{	
		checktimer();
		//GD.Print(takendamage+"|"+(dmgtimer.TimeLeft == 0)+"|"+ !TimerStartedAtLeastOnce);
		Vector2 velocity = Velocity;
		//air drag
		if(velocity.Y>=1000f){
			velocity.Y-= 50f;
		}
		//friction
		if(velocity.X>=1000f){
			velocity.X-= 50f;
		}
		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;
		if(!takendamage){
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
			processMovementAnim();
		}
		if(Input.IsActionJustPressed("shoot")){
			bullet Bullet = new bullet();
			AddChild(Bullet);
			Bullet.fire();
		}
		Velocity = velocity;
		MoveAndSlide();
		checkhealth();
		//for debugging the timer
		//GD.Print(dmgtimer.TimeLeft);
	}
	//for the animation
	//main bug is that left up does not work properly -Neil
	//fixed -Neil
	public  void processMovementAnim(){	
		if (Input.IsKeyPressed(Key.D)){
			DirX = 1;
		}
		if (Input.IsKeyPressed(Key.A)){
			DirX = -1;

		}
		if((!Input.IsKeyPressed(Key.A) && !Input.IsKeyPressed(Key.D)) || (Input.IsKeyPressed(Key.A) && Input.IsKeyPressed(Key.D))){
			DirX = 0;
		}
		if (Input.IsKeyPressed(Key.Space)){
			DirY = 1;
		}
		else{
			DirY = 0;
		}
		//if you are moving lr or up
		if (DirX != 0 || DirY != 0){
			//If you are moving to the left,
			if (DirX == 1){
				//if you are jumping, play animation
				if (DirY == 1){
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("upper corner");
				}
				//if you are not jumping, play animation
				else{
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
					GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("right");
				}
			}
			//if you are moving to the right
			else if (DirX == -1){
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
		//debug
		//GD.Print(DirX+"|"+DirY);
	}
	public void takedamage(){
		if (dmgtimer.TimeLeft == 0 || !TimerStartedAtLeastOnce){
			health -= 1;
			Velocity = new Vector2(500f*-DirX,-200f);
			MoveAndSlide();
			dmgtimer.Start(2);
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("damage");
			TimerStartedAtLeastOnce = true;
		}
	}
	public void checkhealth(){
		if (health <= 0){
			GetTree().ChangeSceneToFile("death.tscn");
		}
	}
	public void checktimer(){
		if(dmgtimer.TimeLeft == 0 || !TimerStartedAtLeastOnce){
			takendamage = false;
		}
		else{
			takendamage = true;
		}
	}
}