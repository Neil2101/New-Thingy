using Godot;
using System;

public partial class PotatoCannon : Sprite2D
{
    public Timer cooldown;
    [Export]
    public PackedScene boolet = GD.Load<PackedScene>("res://Characters/bullet.tscn");
    public override void _Ready(){
            cooldown = GetNode<Timer>("CannonCooldown");
		    cooldown.Autostart = false;
        }
    public override void _PhysicsProcess(double delta){
        GD.Print(cooldown.TimeLeft);
        LookAt(GetGlobalMousePosition());
        RotationDegrees = Math.Abs(RotationDegrees);
		if(RotationDegrees%360>=90.0 && RotationDegrees%360<=270.0){
            FlipV = true;
        }
        else{
            FlipV = false;
        }
        if(Input.IsActionJustPressed("shoot") && cooldown.TimeLeft == 0){
            GD.Print(boolet);
			bullet Bullet = boolet.Instantiate<bullet>();
			this.AddChild(Bullet);
			cooldown.WaitTime = 1;
			cooldown.Start();
		}
    }
}