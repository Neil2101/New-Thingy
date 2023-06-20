using Godot;
using System;

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
