using Godot;
using System;

public partial class PotatoCannon : Sprite2D
{
    public override void _PhysicsProcess(double delta){
        LookAt(GetGlobalMousePosition());
        RotationDegrees = Math.Abs(RotationDegrees);
		if(RotationDegrees%360>=90.0 && RotationDegrees%360<=270.0){
            FlipV = true;
        }
        else{
            FlipV = false;
        }
        if(Input.IsActionPressed("shoot")){
            GD.Print("You've been shot!");
            bullet boolet = new bullet(); // Create a new Sprite2D.
            AddChild(boolet);
            boolet.fire();
        }
    }
}