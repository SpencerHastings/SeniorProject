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

	// Use this for initialization
	void Start () 
	{
		canvas_grp = gameObject.GetComponent<CanvasGroup> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		char_move = player.GetComponent<charactermovement> ();
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
		SetAll (current_line.text, current_line.name, null);
		//char_move.Movable (false);
		char_move.Freeze (true);
		Show ();
	}

	public void ChangeDialog()
	{
		linecount++;

		if (linecount <= current_dialog.num_lines)
		{
			current_line = current_dialog.lines.First(i => i.line_id == linecount);
			SetAll (current_line.text, current_line.name, null);
		}
		else
		{
			EndDialog();
		}
	}

	public void EndDialog()
	{
		Hide ();
		linecount = 0;
		current_dialog = null;
		current_line = null;
		//char_move.Movable (true);
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


	
	public static dialog_set GetDialog(int dialog_id)
	{
		return dialog_sets.First(i => i.dialog_id == dialog_id);
	}

	void Awake()
	{
		DontDestroyOnLoad(this);
	}
}





