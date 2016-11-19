using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

public class TextRenderer : MonoBehaviour {
	public string TextPath;
	public Text MessageText;
	public int LinesDisplay = 3;

	private List<string> TextBuffer = new List<string>();
	private Dictionary<int, string> Text = new Dictionary<int, string>();
	private int CurrentLine;
	// Use this for initialization
	void Start() {
		bool LoadedText = Load(TextPath);
		for (CurrentLine = 1; CurrentLine <= LinesDisplay; CurrentLine++) {
			MoveToBuffer(CurrentLine);
		}

		WriteBuffer();
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyUp(KeyCode.DownArrow)) {
			MoveToBuffer(++CurrentLine);
			WriteBuffer();
		}

		if (Input.GetKeyUp(KeyCode.B)) {
			Debug.Log("/----------------------");
			foreach (var A in TextBuffer) {
				Debug.Log(" Value: " + A);
			}
			Debug.Log("\\-----------------------");
		}
	}

	private void MoveToBuffer(int LineNr) {
		string BufferText;
		try {
			BufferText = Text[LineNr];
		} catch (KeyNotFoundException) {
			return;
		}
		Text.Remove(LineNr);


		if (TextBuffer.Count >= LinesDisplay) {
			TextBuffer.RemoveAt(0);
		}

		TextBuffer.Add(BufferText);
	}

	private void WriteBuffer() {
		string OutputString = "";
		foreach (var ThisText in TextBuffer) {
			OutputString += ThisText + "\n";
		}

		try {
			int CheckNextTextLine = CurrentLine + 1;
			string CheckText = Text[CheckNextTextLine];
			OutputString += "        (Scroll Down)";
		} catch (KeyNotFoundException) {

		}

		MessageText.text = OutputString;
	}

	private bool Load(string fileName) {
		// Handle any problems that might arise when reading the text
		try {
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader) {
				int CurLineNumber = 0;
				// While there's lines left in the text file, do this:
				do {
					line = theReader.ReadLine();
					CurLineNumber++;
					if (line != null) {
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()
						Text.Add(CurLineNumber, line);
					}
				}
				while (line != null);
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
				return true;
			}
		}
			// If anything broke in the try block, we throw an exception with information
			// on what didn't work
			catch (Exception e) {
			Debug.Log(e.ToString());
			return false;
		}
	}
}
