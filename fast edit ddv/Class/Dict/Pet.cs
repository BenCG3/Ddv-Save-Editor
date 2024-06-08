using System.Collections.Generic;

namespace ddv_edit
{
	
		public class Pet
		{
		public int PetItemID { get; set; }
		public string NamePets { get; set; }

	//	public string Name { get; internal set; }

		public static List<string> groupNamesToCheck = new List<string>
		{
			"CollectionSet.CrittersRabbit_CollectionName 0",
			"CollectionSet.CrittersRacoon_CollectionName 0",
			"CollectionSet.CrittersSquirrel_CollectionName 0",
			"CollectionSet.CrittersBabySeaTurtle_CollectionName 0",
			"CollectionSet.CrittersSunbird_CollectionName 0",
			"CollectionSet.CrittersBabyCrocodile_CollectionName 0",
			"CollectionSet.CrittersCrow_CollectionName 0",
			"CollectionSet.CrittersBabyArcticFox_CollectionName 0",
			"CollectionSet.CrittersCapybara_CollectionName 0",
			"CollectionSet.CrittersMonkey_CollectionName 0",
			"CollectionSet.CrittersCobra_CollectionName 0"
		};

		public static Dictionary<int, string> petNames = new Dictionary<int, string>
{
	//////////////
	{120000000, "Pua"},
	/////////////////
	{120000001, "Classic Squirrel"},
	{120000002, "Classic Rabbit"},
	{120000003, "Classic Sea Turtle"},
	{120000005, "Red Squirrel"},
	{120000006, "Gray Squirrel"},
	{120000007, "Black Squirrel"},
	{120000008, "White Squirrel"},
	{120000009, "Brown Sea Turtle"},
	{120000010, "White Sea Turtle"},
	{120000011, "Purple Sea Turtle"},
	{120000012, "Black Sea Turtle"},
	{120000013, "Black Rabbit"},
	{120000014, "Brown Rabbit"},
	{120000015, "White Rabbit"},
	{120000016, "Calico Rabbit"},
	{120000017, "Classic Raccoon"},
	{120000018, "Red Raccoon"},
	{120000019, "Black Raccoon"},
	{120000020, "White Raccoon"},
	{120000021, "Blue Raccoon"},
	{120000022, "Red Sunbird"},
	{120000023, "Turquoise Sunbird"},
	{120000024, "Emerald Sunbird"},
	{120000025, "Golden Sunbird"},
	{120000026, "Orchid Sunbird"},
	{120000027, "Classic Crocodile"},
	{120000028, "Blue Crocodile"},
	{120000029, "Red Crocodile"},
	{120000030, "Golden Crocodile"},
	{120000031, "White Crocodile"},
	{120000032, "Classic Raven"},
	{120000033, "Red Raven"},
	{120000034, "White Raven"},
	{120000035, "Blue Raven"},
	{120000036, "Brown Raven"},
	{120000037, "White Fox"},
	{120000038, "Classic Fox"},
	{120000039, "Black Fox"},
	{120000040, "Blue Fox"},
	{120000041, "Red Fox"},
	{120000042, "Pink Crocodile"},
	{120000043, "Celestial Sea Turtle"},
	{120000044, "Regal Fox"},
	{120000045, "Choco Crocodile"},
	{120000046, "IncrediSquirrel"},
	{120000047, "Wind-Up Raccoon"},
	{120000048, "Festive Fox"},
	{120000049, "Gentle Rabbit"},
	////////////////
	{120000051, "Scary Squirrel"},
	///////////////
	{120000052, "Magical Squirrel"},
	{120000053, "Blue Whimsical Squirrel"},
	{120000054, "Pink Whimsical Squirrel"},
	{120000055, "Pink Spring Rabbit"},
	{120000056, "Blue Spring Rabbit"},
	{120000057, "Yellow Spring Rabbit"},
	{120000058, "Blue Whimsical Crocodile"},
	{120000059, "Pink Whimsical Crocodile"},
	{120000060, "Blue Whimsical Fox"},
	{120000061, "Pink Whimsical Fox"},
	{120000062, "Blue Whimsical Rabbit"},
	{120000063, "Pink Whimsical Rabbit"},
	{120000064, "Blue Whimsical Raccoon"},
	{120000065, "Pink Whimsical Raccoon"},
	{120000066, "Blue Whimsical Raven"},
	{120000067, "Pink Whimsical Raven"},
	{120000068, "Blue Whimsical Sunbird"},
	{120000069, "Pink Whimsical Sunbird"},
	{120000070, "Blue Whimsical Turtle"},
	{120000071, "Pink Whimsical Turtle"},
	{120000072, "Fiery Raven"},
	{120000073, "Rainbow Fox"},
	{120000074, "Bountiful Croc"},
	{120000075, "Tart Turtle"},
	{120000076, "Fear Raccoon"},
	{120000077, "Anger Raccoon"},
	{120000078, "Disgust Raccoon"},
	{120000079, "Joy Raccoon"},
	{120000080, "Sadness Raccoon"},
	{120000081, "Classic Capybara"},
	{120000082, "Black and White Capybara"},
	{120000083, "Blue Striped Capybara"},
	{120000084, "Gray Striped Capybara"},
	{120000085, "Red and White Striped Capybara"},
	{120000086, "Ghostly \"Zero\" Fox"},
	{120000087, "Pirate Parrot"},
	{120000088, "Classic Cobra"},
	{120000089, "Blue and Red Striped Cobra"},
	{120000090, "Pink Spotted Cobra"},
	{120000091, "Yellow and Purple Striped Cobra"},
	{120000092, "Green and White Striped Cobra"},
	{120000093, "Classic Monkey"},
	{120000094, "Black and Brown Monkey"},
	{120000095, "Red and Beige Monkey"},
	{120000096, "Beige Monkey"},
	{120000097, "Black and Gray Monkey"},
	{120000098, "Ancient Robot"},
	{120000099, "Gingerbread Rabbit"},
	{120000100, "Jester Monkey"},
	{120000102, "Flowery Capybara"},
	{120000104, "Snowy Raccoon"},
	{120000105, "Rosy Cloud Turtle"},
	{120000107, "Pink Lovebird"},
	{120000108, "Green Lovebird"},
	{120000109, "Toon Capybara"},
	{120000110, "Toon Cobra"},
	{120000111, "Heihei"},
	{120000112, "Toon Monkey"},
	{120000113, "Peppy Popcorn Squirrel"}
};

	}

}
