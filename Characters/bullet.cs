using Godot;
using System;

public partial class bullet : CharacterBody2D
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
// 		Vector2 vel = new Vector2();
// //		this.Velocity = vel; wah is tis -astro | This is just to apply the velocity to the object, "Velocity = vel" works too -Neil
// //		ApplyCentralImpulse(vel); < this line is a suggestion to replace ^ -astro
// //		MoveAndSlide();
	}
	public void Fire(){
		//essentialy, We want to disable cannon collision for about half a second, so we don't damage the player first, and then, we would want to make the bullet move forward at a decent velocity, and then to find out the bullet's direction, do something like finding the distance between mouse courser as a (a,b) and then use inverse sin or cos, I forgot, but do that :) -Neil
		Vector2 vel = new Vector2();
		Velocity = vel;
		MoveAndSlide();
	}
}
