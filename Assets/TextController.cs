using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom, corridor};
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
		text.text = "Get out of here...";
		text.horizontalOverflow = HorizontalWrapMode.Wrap;
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.cell) state_cell ();
		else if (myState == States.sheets_0) state_sheets_0 ();
		else if (myState == States.mirror) state_mirror ();
		else if (myState == States.lock_0) state_lock_0 ();
		else if (myState == States.cell_mirror) state_cell_mirror ();
		else if (myState == States.sheets_1) state_sheets_1 ();
		else if (myState == States.lock_1) state_lock_1 ();
		else if (myState == States.freedom) state_freedom ();
	}

	#region State handler methods
	void state_cell (){
		text.text = "You are in a prison cell, and you want to escape. \n There are some dirty sheets on the bed" + 
			", a mirror on the wall, and the door is locked from the outside.\n\n" + 
			"Press S to view Sheets, M for Mirror, and L for lock.";
		if (Input.GetKeyDown (KeyCode.S)) myState = States.sheets_0;
		if (Input.GetKeyDown (KeyCode.M)) myState = States.mirror;
		if (Input.GetKeyDown (KeyCode.L)) myState = States.lock_0;
	}

	void state_sheets_0 (){
		text.text = "Your sheets are helluh dirty bro. You best be washin them. \n\n"+
			"Press R to return to roaming your cell";
		if (Input.GetKeyDown (KeyCode.R)) myState = States.cell;
	}

	void state_mirror () {
		text.text = "You are looking at your mirror.\nPress R to return, or T to take.";
		if (Input.GetKeyDown (KeyCode.R)) myState = States.cell;
		if (Input.GetKeyDown (KeyCode.T)) myState = States.cell_mirror;
	}

	void state_lock_0 () {
		text.text = "You are looking at a lock.\nPress R to return.";
		if (Input.GetKeyDown (KeyCode.R)) myState = States.cell;
	}

	void state_cell_mirror () {
		text.text = "You have just taken the mirror.\n" +
			"to use the mirror on the sheets press S\n" +
			"to use mirror on the lock press L";
		if (Input.GetKeyDown (KeyCode.S)) myState = States.sheets_1;
		if (Input.GetKeyDown (KeyCode.L)) myState = States.lock_1;
	}

	void state_sheets_1 () {
		text.text = "You are looking at the sheets again with the mirror.\nPress R to return.";
		if (Input.GetKeyDown (KeyCode.R)) myState = States.cell_mirror;
	}

	void state_lock_1 () {
		text.text = "You are looking at the lock with a mirror.\nPress R to return or O to open.";
		if (Input.GetKeyDown (KeyCode.R)) myState = States.cell_mirror;
		if (Input.GetKeyDown (KeyCode.O)) myState = States.freedom;
	}

	void state_freedom () {
		text.text = "You've successfully opened the lock.\nPress C to continue to the corridor.";
		if (Input.GetKeyDown (KeyCode.C)) myState = States.cell;
	}
	#endregion

}
