using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class dialog_box : MonoBehaviour {

	private CanvasGroup canvas_grp; 
	private charactermovement char_move;
	private GameObject player;
	public Text dialog;
	public Text name; 
	public Image picture;
	public dialog_set current_dialog;
	public line current_line;
	public int linecount = 0;
	public bool isActive = false;
	private sprite_storage spr;
	public GameObject map;
	private map m;

	// Use this for initialization
	void Start () 
	{
		canvas_grp = gameObject.GetComponent<CanvasGroup> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		char_move = player.GetComponent<charactermovement> ();
		spr = this.GetComponent<sprite_storage> ();
		m = map.GetComponent<map> ();
		Hide ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isActive)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				ChangeDialog();
			}

		}

	}


	public void SetAll(string Dialog, string Name, Sprite Image)
	{
		SetName (Name);
		SetText (Dialog);
		SetImage (Image);
	}

	public void SetText(string text)
	{
		dialog.text = text;
	}

	public void SetName(string text)
	{
		name.text = text;
	}

	public void SetImage(Sprite image)
	{
		picture.sprite = image;
	}

	public void Show()
	{
		canvas_grp.alpha = 1;
	}

	public void Hide()
	{
		canvas_grp.alpha = 0;
	}

	public void StartDialog (dialog_set dialog)
	{
		isActive = true;
		linecount++;
		current_dialog = dialog;
		current_line = current_dialog.lines.First(i => i.line_id == 1);
		SetAll (current_line.text, current_line.name, spr.GetImage (current_line.image_id));
		char_move.Movable (false);
		char_move.Freeze (true);
		Show ();
	}

	public void ChangeDialog()
	{
		linecount++;

		if (linecount <= current_dialog.num_lines)
		{
			current_line = current_dialog.lines.First(i => i.line_id == linecount);
			if (current_line.text == "Map")
			{
				m.Show();
			}
			else
			{
			SetAll (current_line.text, current_line.name, spr.GetImage (current_line.image_id));
			}
		}
		else
		{
			EndDialog();
		}
	}

	public void EndDialog()
	{
		if (current_dialog.dialog_id == 18 || current_dialog.dialog_id == 19)
		{
			Application.LoadLevel ("title");
		}

		m.Hide();
		Hide ();
		linecount = 0;
		current_dialog = null;
		current_line = null;
		char_move.Movable (true);
		char_move.Freeze (false);
		isActive = false;
	}
}


public class dialog_set 
{
	public List<line> lines;
	public int dialog_id;
	public int num_lines;

	public dialog_set(List<dialog_set> list, int Dialog_id, List<line> Lines)
	{
		lines = Lines;
		Lines = Lines.OrderBy(q => q.line_id).ToList();
		dialog_id = Dialog_id;
		list.Add (this);
		num_lines = lines.Count ();
	}
}

public class line
{
	public int line_id;
	public string text;
	public string name;
	public int image_id;

	public line(int Line_id, string Text, string Name, int Image_id)
	{
		line_id = Line_id;
		text = Text;
		name = Name;
		image_id = Image_id;
	}
}

public class dialog_storage : MonoBehaviour
{
	static List<dialog_set> dialog_sets = new List<dialog_set> ();

	static dialog_set sample = new dialog_set (dialog_sets, 1, new List<line> (new line[] {
		new line (1,"Dialogs", "Bob", 2),
		new line (2,"Dialogs2", "Joe", 3)

	}));

	static dialog_set potion_intro = new dialog_set (dialog_sets, 2, new List<line> (new line[] {
		new line (1,"Potions heal you. Select them in the inventory to use.", "Potion", 1),
		new line (2,"Bombs explode! Select them in the inventory to use.", "Bombs", 3)
			
	}));

	static dialog_set attack_intro = new dialog_set (dialog_sets, 3, new List<line> (new line[] {
		new line (1,"Press the IJKL buttons to perform attacks.", "Attacking", 4),
		new line (2,"Attacks drain HP.", "Attacking", 6),
		new line (3,"Use potions wisely.", "Attacking", 1)
			
	}));

	static dialog_set intro = new dialog_set (dialog_sets, 4, new List<line> (new line[] {
		new line (1, "You're a wizard and evil is afoot.", "Intro", 2),
		new line (2, "Use the WASD buttons to move.", "Movement", 2),
		new line (3, "Press the inventory button up right next to the pause botton to access the inventory.", "Inventory", 2),
		new line (4, "Click on objects to select and press \"E\" to use.", "Items", 2),
		new line (5, "Oh! There is a book already in your inventory.", "Book", 12)
			
	}));

	static dialog_set hill_stop = new dialog_set (dialog_sets, 5, new List<line> (new line[] {
		new line (1, "There appears to be a tree in the way.", "Obstruction!", 7)
			
	}));

	static dialog_set warning = new dialog_set (dialog_sets, 6, new List<line> (new line[] {
		new line (1, "\"THERE ARE FOUR OTHER CAVES. THEY MUST BE TRAVERSSED FIRST.\" says a voice.", "WARNING!", 12)
			
	}));

	static dialog_set voice_1 = new dialog_set (dialog_sets, 7, new List<line> (new line[] {
		new line (1, "\"Over here!\" someone calls from the west.", "A Stranger", 12)
			
	}));

	static dialog_set sign_1 = new dialog_set (dialog_sets, 8, new List<line> (new line[] {
		new line (1, "You spy an inscription that says \"Treasure up top!\"", "Notice!", 2)
			
	}));

	static dialog_set chest_1 = new dialog_set (dialog_sets, 9, new List<line> (new line[] {
		new line (1, "You open a chest and find a gold mask!", "Chest", 14)
			
	}));

	static dialog_set chest_2 = new dialog_set (dialog_sets, 10, new List<line> (new line[] {
		new line (1, "You open a chest and find a pair of gold boots!", "Chest", 15)
			
	}));

	static dialog_set chest_3 = new dialog_set (dialog_sets, 11, new List<line> (new line[] {
		new line (1, "You open a chest and find a gold shield!", "Chest", 16)
			
	}));

	static dialog_set chest_4 = new dialog_set (dialog_sets, 12, new List<line> (new line[] {
		new line (1, "You open a chest and find a gold staff!", "Chest", 13)
			
	}));

	static dialog_set mask = new dialog_set (dialog_sets, 13, new List<line> (new line[] {
		new line (1, "You try on the gold mask. The lack of holes makes it difficult to see and breathe.", "Gold Mask", 14)
			
	}));

	static dialog_set boots = new dialog_set (dialog_sets, 14, new List<line> (new line[] {
		new line (1, "You try on the gold boots. They make terrible shoes.", "Gold Boots", 15)
			
	}));

	static dialog_set staff = new dialog_set (dialog_sets, 15, new List<line> (new line[] {
		new line (1, "You hold the gold staff. Nothing happens.", "Gold Staff", 13)
			
	}));

	static dialog_set shield = new dialog_set (dialog_sets, 16, new List<line> (new line[] {
		new line (1, "You try out the gold shield. It blocks your own magic very effectively.", "Gold Shield", 16)
			
	}));

	static dialog_set book = new dialog_set (dialog_sets, 17, new List<line> (new line[] {
		new line (1, "You find a strange book inside your bag.", "Book", 17),
		new line (2, "All it says is \"Find the golden artifacts and take them North.\", along with a poorly drawn map...", "Book", 17),
		new line (3, "Map", "Book", 17)
			
	}));

	static dialog_set bad_ending = new dialog_set (dialog_sets, 18, new List<line> (new line[] {
		new line (1, "What's this? An unprepared adventurer?", "???", 12),
		new line (2, "You have met an untimely demise.", "Game Over", 2)
				
	}));

	static dialog_set good_ending = new dialog_set (dialog_sets, 19, new List<line> (new line[] {
		new line (1, "What's this??? A... prepared adventurer?", "???", 12),
		new line (2, "You have gotten the upper hand on this villan! TO BE CONTINUED.", "Game Over", 2)
			
	}));
	
	
	public static dialog_set GetDialog(int dialog_id)
	{
		return dialog_sets.First(i => i.dialog_id == dialog_id);
	}

	void Awake()
	{
		DontDestroyOnLoad(this);
	}


}





