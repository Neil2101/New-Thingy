using Godot;
using System;
using System.Collections;


public partial class PotatoCannon : Sprite2D
{
	public Timer cooldown;
	
	[Export]
	public PackedScene boolet = GD.Load<PackedScene>("res://Characters/bullet.tscn");
	public ArrayList BulletList = new ArrayList();
	public override void _Ready(){
			cooldown = GetNode<Timer>("CannonCooldown");
			cooldown.Autostart = false;
			cooldown.OneShot = true;
		}
	public override void _PhysicsProcess(double delta){
		//GD.Print(cooldown.TimeLeft);
		LookAt(GetGlobalMousePosition());
		RotationDegrees = Math.Abs(RotationDegrees);
		if(RotationDegrees%360>=90.0 && RotationDegrees%360<=270.0){
			FlipV = true;
		}
		else{
			FlipV = false;
		}
		if(Input.IsActionJustPressed("shoot") && cooldown.TimeLeft == 0){
			//GD.Print(boolet);
			bullet Bullet = boolet.Instantiate<bullet>();
			this.AddChild(Bullet);
			Bullet.Fire();
			GD.Print(Bullet);
			cooldown.WaitTime = 1;
			cooldown.Start();
		}
		for(int i = 0;i>BulletList.Count;i++){
			bullet BooletInstance = BulletList[i] as bullet; //casting because vscode :(
			BooletInstance.Fire();
		}
	}
}
