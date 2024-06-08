using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddv_edit
{
	internal class Houses
	{
		public int ItemIDHouses { get; set; }
		public int AmountHouses { get; set; }


		public static Dictionary<int, string> HousesNames = new Dictionary<int, string>
	{
		{20500000, "Yellow Gablefront House"},
		{20500001, "Green Gablefront House"},
		{20500002, "White Gablefront House"},
		{20500003, "Blue Gablefront House"},
		{20500004, "Purple Gablefront House"},
		{20500005, "Orange Gablefront House"},
		{20500006, "Palace"},
		{20500007, "Purple Cottage"},
		{20500008, "Prince Eric's Ship"},
		{20500009, "Mike and Sulley's Apartment"},
		{20500011, "Sweet House"},
		{20500012, "Beach House"},
		{20500013, "Nightmare Castle"},
		{20500014, "Mushroom Manor"},
		{20500015, "Frosty Fortress"},
		{20500016, "Haunted Mansion"},
		{20500017, "Haunted 'Before Christmas' Mansion"},
		{20500018, "Desert Palace"},
		{20500019, "Fairy's Bloss-Home"},
		{20500020, "Flowery Summer Cottage"},
		{20500021, "Winter Palace"},
		{20500024, "French Bakery House"},
		{20500025, "Snuggly Duckling Tavern House"},
		{20500026, "Lady Tremaine's Manor House"},
		{20500027, "Pink Castle"},
		{20500028, "Provincial Library House"},
		{20500029, "Carl's House"},
		{20500030, "Belle's Cottage"},
		{20500031, "Leafy Cottage House"},
		{20500032, "Jungle House"},
		{20500033, "V8 Cafe House"},
		{20500034, "Main Street Confectionary"}
	};

	}
}
