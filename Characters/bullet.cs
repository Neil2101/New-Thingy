using Godot;
using System;

public partial class bullet : CharacterBody2D
{
    float speed = 30f;
    int damage = 1;
    public void delete(){
        this.QueueFree();
    }
    public override void _PhysicsProcess(double delta){
        Vector2 vel = new Vector2();
        Velocity = vel;
        MoveAndSlide();
    }
}
