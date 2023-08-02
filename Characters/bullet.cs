using Godot;
using System;

public partial class bullet : RigidBody2D
{
	float speed = 30f;
	int damage = 1;
	public void delete(){
		this.QueueFree();
	}
	public override void _Ready(){
		this.Position = GetNode<CharacterBody2D>("res://Characters/player_char.tscn").Position; //for some reason this doesnt work -astro
	}
	public override void _PhysicsProcess(double delta){
		Vector2 vel = new Vector2();
//		this.Velocity = vel; wah is tis
//		ApplyCentralImpulse(vel); < this line is a suggestion to replace ^ -astro
//		MoveAndSlide();
	}
}
