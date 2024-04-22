using Godot;
using System;
using System.Collections.Generic;

public partial class Grid : Node2D
{
	private Tile[,] grid;
	private PackedScene sceneTile;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sceneTile = ResourceLoader.Load<PackedScene>("res://Tile.tscn");

		grid = new Tile[4,4];

		PopulateStartingTiles();
	}

	private bool MoveTiles(string direction){
		GD.Print("Moving tiles " + direction);
		bool movementOccurred = false;
		bool isHorizontal = direction == "left" || direction == "right";
		bool isReverse = direction == "up" || direction == "left";

		for(int i = 0; i < 4; i++){
			Stack<Tile> tiles = new Stack<Tile>();
			for(int j = 0; j < 4; j++){
				int x = isHorizontal ? (isReverse?3-j:j) : i;
				int y = isHorizontal ? i : (isReverse?3-j:j);
				if(grid[x,y] != null){
					tiles.Push(grid[x,y]);
					grid[x,y] = null; // clear the tile from the grid
				}
			}
		}

		return movementOccurred;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private Vector2 ArrayToTileCoords(Vector2 arrayCoords){
		return new Vector2(arrayCoords.X * 115 + 15, arrayCoords.Y * 115 + 15);
	}

	private void PopulateStartingTiles(){
		Random random = new Random();
		Vector2 tile1coords = new Vector2(random.Next(0,4), random.Next(0,4));
		Vector2 tile2coords = new Vector2(random.Next(0,4), random.Next(0,4));
		while(tile1coords.X == tile2coords.X && tile1coords.Y == tile2coords.Y){
			tile1coords = new Vector2(random.Next(0,4), random.Next(0,4));
			tile2coords = new Vector2(random.Next(0,4), random.Next(0,4));
		}

		Tile t1 = sceneTile.Instantiate() as Tile;
		t1.Position = ArrayToTileCoords(tile1coords);
		t1.SetValue(2);
		AddChild(t1);

		Tile t2 = sceneTile.Instantiate() as Tile;
		t2.Position = ArrayToTileCoords(tile2coords);
		t2.SetValue(2);
		AddChild(t2);

		grid[(int)tile1coords.X, (int)tile1coords.Y] = t1;
		grid[(int)tile2coords.X, (int)tile2coords.Y] = t2;
	}

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("up"))
		{
			MoveTiles("up");
		}
		if (@event.IsActionPressed("down"))
		{
			MoveTiles("down");
		}
		if (@event.IsActionPressed("left"))
		{
			MoveTiles("left");
		}
		if (@event.IsActionPressed("right"))
		{
			MoveTiles("right");
		}
    }
}
