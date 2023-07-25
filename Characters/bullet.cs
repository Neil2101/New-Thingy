using Godot;
using System;

public partial class bullet : CharacterBody2D
{
    Timer DespawnTimer;
    float DespawnTime = 3;
    Vector2 cannonxy;
    float potatovel = 200;
	public override void _Ready(){
        DespawnTimer = GetNode<Timer>("Despawntimer");
        this.Visible = false;
        RotationDegrees = Math.Abs(RotationDegrees);
		LookAt(GetGlobalMousePosition());
        
    }
    public override void _PhysicsProcess(double delta){
        //despawning
        if(IsOnFloor() && DespawnTimer.TimeLeft == 0){
            DespawnTimer.WaitTime = DespawnTime;
        }
        if(DespawnTimer.TimeLeft == 0){
            this.QueueFree();
        }
        
    }
	public Vector2 anglexy(float angle)
	{
		float x = (float) Math.Cos(angle)*potatovel;
		float y = (float) Math.Sin(angle)*potatovel;
		Vector2 result = new Vector2(x, y);
		return result;
	}
    public void fire(){
        cannonxy = anglexy(RotationDegrees);
        Velocity = cannonxy;
        MoveAndSlide(); 
    }
}
