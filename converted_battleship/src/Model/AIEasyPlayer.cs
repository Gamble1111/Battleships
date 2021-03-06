using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
// using System.Data;
using System.Diagnostics;

/// <summary>
/// The AIEasyPlayer is a type of AIPlayer where it will randomly shoot even
/// if it has found a ship
/// </summary>
public class AIEasyPlayer : AIPlayer
{
	public AIEasyPlayer(BattleShipsGame controller) : base(controller)
	{
	}

	/// <summary>
	/// GenerateCoordinates should generate random shooting coordinates
	/// </summary>
	/// <param name="row">the generated row</param>
	/// <param name="column">the generated column</param>
	protected override void GenerateCoords(ref int row, ref int column)
	{
		do {
			//generate coordinates for AI Player to shoot
			SearchCoords(ref row, ref column);
		} while ((row < 0 || column < 0 || row >= EnemyGrid.Height || column >= EnemyGrid.Width || EnemyGrid[row, column] != TileView.Sea));
		//while inside the grid and not a sea tile do the search
	}

	/// <summary>
	/// SearchCoords will randomly generate shots within the grid as long as its not hit that tile already
	/// </summary>
	/// <param name="row">the generated row</param>
	/// <param name="column">the generated column</param>
	private void SearchCoords(ref int row, ref int column)
	{
		row = _Random.Next(0, EnemyGrid.Height);
		column = _Random.Next(0, EnemyGrid.Width);
	}

	/// <summary>
	/// ProcessShot will be called uppon when a ship is found.
	/// Easy AI Player will then search for another random coordinate to shoot
	/// </summary>
	/// <param name="row">the row it needs to process</param>
	/// <param name="col">the column it needs to process</param>
	/// <param name="result">the result of the last shot (should be hit)</param>

	protected override void ProcessShot(int row, int col, AttackResult result)
    {
		if (result.Value == ResultOfAttack.Hit) {
			SearchCoords(ref row, ref col);
		} else if (result.Value == ResultOfAttack.ShotAlready) {
			throw new ApplicationException("Error in AI");
		}
	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
