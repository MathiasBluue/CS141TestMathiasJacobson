using System.Collections;
using TMPro;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Scoop : MonoBehaviour
{
	public static int vanillaScoops;
	public static int chocolateScoops;
	public static int strawberryScoops;

	public static int totalScoops;
	
	public static bool hasPutInput;
	public static bool validInput;
	public static bool isOrdering;


	static string[] iceCreamFlavors = new string[] { "vanilla", "chocolate", "strawberry" };
	static string[] orderedIceCreams = new string[] { };

	static List<string> originalOrders = new List<string>();

	public GameObject testObject;
	public GameObject[] panels;

	public TextMeshProUGUI totalScoopCount;
	public TextMeshProUGUI vanillaScoopCount;
	public TextMeshProUGUI chocolateScoopCount;
	public TextMeshProUGUI strawberryScoopCount;

	// Start is called before the first frame update
	void Start()
	{
		StartStore();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			Application.Quit();
		}
	}
   

	public static void StartStore()
	{
		Console.WriteLine("-------------------------------------------------");
		isOrdering = true;
		hasPutInput = false;

		//Write welcome message, display flavors in iceCreamFlavors[], display instructions
		greetCustomer();

		//Ask for user input, check if validInput
		
	}

	public static void greetCustomer()
	{
		isOrdering = true;

		Console.WriteLine("Hello and Welcome to Scoop's Ice Cream Parlor.");
		Console.WriteLine("We have the following flavors available: ");
		Console.WriteLine("");

		//loops through each item of iceCreamFlavors[] to create custom listing
		for (int i = 0; i < iceCreamFlavors.Length; i++)
		{
			Console.WriteLine(" - " + iceCreamFlavors[i] + " ice cream.");
			Console.WriteLine("");
		}

		Console.WriteLine("Order scoops by typing the flavor name with no spaces, and clicking enter.");
		Console.WriteLine("");
		Console.WriteLine("For example; type vanilla for vanilla ice cream.");
		Console.WriteLine("");
		Console.WriteLine("When you have finished ordering, type 'done,' and click enter.");

		Console.WriteLine("-------------------------------------------------");
	}


	public static void askForInput()
	{
		/*
		set valid input to false by default before input is checked
		validInput = false;

		if (hasPutInput == true)
		{
			Console.WriteLine("   Selections updated. Please make another selection or type 'done'.");
			Console.WriteLine(" ");
		}
		else
		{
			//ask to enter choice
			Console.WriteLine("   Enter your selection here: ");
		}

		//add space for user
		//Console.Write("   > ");
		//detect user input

		*/

		//call function to check if input is valid. pass through the lowercase user input.

		/*
		if (validInput == true)
		{
			//originalOrders.Add(rawInput);
			hasPutInput = true;
		}
		else if (validInput == false)
		{
			Console.WriteLine(" -Flavor Unavailable, or Input Error- ");
			hasPutInput = false;
		}
		*/

		//Console.WriteLine(" - - - ");
	}

	
	public static void checkIfValid(string input)
	{
		/*
		//loop through the items in iceCreamFlavors[] to see if they match user input
		for (int i = 0; i < iceCreamFlavors.Length; i++)
		{
			//if input matches an item of the array, set validInput to true and call the trackOrder function to calculate totals
			if (input == iceCreamFlavors[i])
			{
				validInput = true;
				trackOrder(input, i);
			}
			//if user inputs 'done' then move to finishOrder(), display totals etc.
			else if (input == "done")
			{
				validInput = true;
				finishOrder();
				break;
			}
			//if user tries to input nothing, it is valid, but nothing will happen
			else if (input == "")
			{
				validInput = true;
				Console.WriteLine("No input");
				break;
			}
			//if user input doesn't match an item from the array, it will simply loop through, and validInput will remain false
			else
			{
				continue;
			}
			*/
		}
		

	//takes in a string for the name of the flavor and the array position of the flavor, and adds a scoop to the total and specific tallies
	public static void trackOrder(string flavor, int arrayPosition)
	{
		int pos = arrayPosition;
		switch (pos)
		{
			case 0:
				vanillaScoops++;
				totalScoops++;
				break;
			case 1:
				chocolateScoops++;
				totalScoops++;
				break;
			case 2:
				strawberryScoops++;
				totalScoops++;
				break;
		}
	}

	//sets the isOrdering bool to false to stop asking for additional selections, class displayFinalInfo()
	public static void finishOrder()
	{
		isOrdering = false;
		displayFinalInfo();
	}

	//formats the final screen that shows data, generates totals for all scoops, 
	public static void displayFinalInfo()
	{
		//Console.WriteLine("-----------------------------------");
		//Console.WriteLine("");
		//Console.WriteLine("    Total number of ice cream scoops: " + totalScoops);
		//Console.WriteLine("");

		//for loop to create message for each flavor of ice cream based on their individual amounts
		for (int i = 0; i < iceCreamFlavors.Length; i++)
		{
			int currentFlavorScoops = 0;

			if (iceCreamFlavors[i] == "vanilla")
			{
				currentFlavorScoops = vanillaScoops;
			}
			else if (iceCreamFlavors[i] == "chocolate")
			{
				currentFlavorScoops = chocolateScoops;
			}
			else if (iceCreamFlavors[i] == "strawberry")
			{
				currentFlavorScoops = strawberryScoops;
			}

			//Console.WriteLine("   >  " + iceCreamFlavors[i] + " scoops: " + currentFlavorScoops);
		}

		//spacing lines here
		//Console.WriteLine("");
		//Console.WriteLine("    Original Orders: ");
		//Console.WriteLine("");
		//for loop to print the original valid orders in the order they came through
		for (int i = 0; i < originalOrders.Count; i++) // Loop through List with for
		{
			Console.WriteLine((i + 1) + "   " + originalOrders[i]);
		}

		//Spacing line
		//Console.WriteLine("");

		//Offer user options to restart
		//Console.WriteLine("To restart your order, type anything");
		string userRestartCode = Console.ReadLine();
		if (userRestartCode == userRestartCode)
		{
			vanillaScoops = 0;
			chocolateScoops = 0;
			strawberryScoops = 0;

			hasPutInput = false;
			isOrdering = false;

			StartStore();
		}
	}

	#region Functions I made specifically with unity in mind

	#region panelChangeButtons
	public void panel1to2()
	{
		panels[0].SetActive(false);
		panels[1].SetActive(true);
	}

	public void panel2to3()
	{
		panels[1].SetActive(false);
		panels[2].SetActive(true);

		setUpPanel3Scores();
	}

	public void panel3to1()
	{
		panels[2].SetActive(false);
		panels[0].SetActive(true);

		vanillaScoops = 0;
		chocolateScoops = 0;
		strawberryScoops = 0;
		totalScoops = 0;
	}
	#endregion

	public void addScoops (int flavorId)
	{
		switch (flavorId)
		{
			case 1:
				vanillaScoops++;
				totalScoops++;
				break;
			case 2:
				chocolateScoops++;
				totalScoops++;
				break;
			case 3:
				strawberryScoops++;
				totalScoops++;
				break;
		}

		Debug.Log("scoops: " + totalScoops);
		Debug.Log("vanilla " + vanillaScoops);
		Debug.Log("chocolate" + chocolateScoops);
		Debug.Log("strawberry " + strawberryScoops);
	}

	public void setUpPanel3Scores()
	{
		totalScoopCount.text = totalScoops.ToString();
		vanillaScoopCount.text = vanillaScoops.ToString();
		chocolateScoopCount.text = chocolateScoops.ToString();
		strawberryScoopCount.text = strawberryScoops.ToString();
	}

	/*
	public void togglePanel()
	{
		GameObject currentPanel;
		for (int i = 0; i < panels.Length; i++)
		{
			if (panels[i].activeInHierarchy == true)
			{
				if (i < panels.Length)
				{
					panels[i].SetActive(false);
					panels[i + 1].SetActive(true);
				} else if (i == panels.Length)
				{
					panels[i].SetActive(false);
					panels[i - panels.Length].SetActive(true);
				}
			} else
			{
				continue;
			}
		}
		*/
}



#endregion



