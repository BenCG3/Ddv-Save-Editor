using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.IO.Compression;
using TextBox = System.Windows.Forms.TextBox;
using System.Security.Cryptography;
using System.Data;

namespace ddv_edit
{

	public partial class Edit_Pets_Form : Form
	{
		private BindingList<Pet> petBindingList;
		private BindingList<Clothes> ClothesBindingList;
	//	private BindingList<Houses> HousesBindingList;
		private BindingList<Pet> originalPetsList;
	//	private BindingList<Clothes> originalClothesList;
		private bool searsh = false;
		private JObject rootData;
		private string filePath = "";
		private readonly string imagesFolderPath = "img/pet";
		private readonly static string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
		private readonly string iniFilePath = Path.Combine(appDirectory, "config.ini");
		private bool ok = false;

		#region"Decrypt"
		private void DecryptSaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			IniFile iniFile = new IniFile(iniFilePath);
			string retrievedValuePath = iniFile.Read("Localisation", "PathToSave");

			if (retrievedValuePath == "")
			{
				//Make Backup and retrieve the path
				string localLowPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Low");
				OpenFileDialog openFileDialogPath = new OpenFileDialog()
				{
					InitialDirectory = localLowPath,
					Title = "Select profile.json",
					Filter = "JSON files (*.json)|*.json",
					FilterIndex = 1,
					RestoreDirectory = true
				};

				if (openFileDialogPath.ShowDialog() == DialogResult.OK)
				{
					if (Path.GetFileName(openFileDialogPath.FileName) != "profile.json")
					{
						MessageBox.Show("Please select the file named 'profile.json'.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					iniFile.Write("Localisation", "PathToSave", openFileDialogPath.FileName);

					filePath = openFileDialogPath.FileName;
					Make_BackupSave();
				}
				else
				{
					Console.WriteLine("No file selected.");
					return;
				}
			}
			else
			{
				filePath = retrievedValuePath;
				Make_BackupSave();
			}

			byte[] fileContent = File.ReadAllBytes(filePath);
			//test if file is encrypted
			double entropy = CalculateEntropy(fileContent);
			bool isEncrypted = entropy > 7.5;

			if (isEncrypted == true)
			{
				//you need to put the key here
				string hexKey = "";
				string outputDirectory = Path.GetDirectoryName(filePath);
				string outputFilePath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + "tmp.json");
				byte[] key = HexStringToByteArray(hexKey);
				try
				{
					DecryptFileAesEcbNoPadding(filePath, outputFilePath, key);
					Uncompresssave(outputFilePath);
					toolStripLabelStatut.Text = "Loaded successfully.";
					Final_load();

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error dec");
				}
			}
			else
			{
				toolStripLabelStatut.Text = "Loaded successfully.";
				Final_load();
			}
		}
		public static void DecryptFileAesEcbNoPadding(string inputFilePath, string outputFilePath, byte[] key)
		{
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = key;
				aesAlg.Mode = CipherMode.ECB;
				aesAlg.Padding = PaddingMode.None;

				using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, null))
				using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
				using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
				using (CryptoStream cryptoStream = new CryptoStream(inputFileStream, decryptor, CryptoStreamMode.Read))
				{
					cryptoStream.CopyTo(outputFileStream);
				}
			}
		}

		public static byte[] HexStringToByteArray(string hex)
		{
			return Enumerable.Range(0, hex.Length / 2)
							 .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
							 .ToArray();
		}
		static double CalculateEntropy(byte[] data)
		{
			int[] frequency = new int[256];
			foreach (byte b in data)
			{
				frequency[b]++;
			}

			double entropy = 0.0;
			int dataLength = data.Length;
			foreach (int freq in frequency)
			{
				if (freq > 0)
				{
					double probability = (double)freq / dataLength;
					entropy -= probability * Math.Log(probability, 2);
				}
			}

			return entropy;
		}
		private void Uncompresssave(string zipFilePath)
		{
			string tmp = Path.GetDirectoryName(zipFilePath);
			try
			{
				using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
				{
					foreach (ZipArchiveEntry entry in archive.Entries)
					{
						string destinationPath = Path.Combine(tmp, entry.FullName);
						Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
						entry.ExtractToFile(destinationPath, true);
					}
				}
				File.Delete(zipFilePath);
				Console.WriteLine("File successfully Uncompressed.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred: {ex.Message}");
			}
		}

		#endregion

		#region"Click"
		private void ToolStripLabelUnknow_Click(object sender, EventArgs e)
		{
			if (ok == false) return;
			using (InputForm inputForm = new InputForm())
			{
				if (inputForm.ShowDialog() == DialogResult.OK)
				{
					if (int.TryParse(inputForm.InputValue, out int value))
					{
						toolStripLabelUnknow.Text = value.ToString();
						Change_Currency("80000009", value);
					}
					else
					{
						MessageBox.Show("Please enter a valid integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
		private void ToolStripLabelMist_Click(object sender, EventArgs e)
		{
			if (ok == false) return;
			using (InputForm inputForm = new InputForm())
			{
				if (inputForm.ShowDialog() == DialogResult.OK)
				{
					if (int.TryParse(inputForm.InputValue, out int value))
					{
						toolStripLabelMist.Text = value.ToString();
						Change_Currency("80000003", value);
					}
					else
					{
						MessageBox.Show("Please enter a valid integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
		private void ToolStripLabelPixelDust_Click(object sender, EventArgs e)
		{
			if (ok == false) return;
			using (InputForm inputForm = new InputForm())
			{
				if (inputForm.ShowDialog() == DialogResult.OK)
				{
					if (int.TryParse(inputForm.InputValue, out int value))
					{
						toolStripLabelPixelDust.Text = value.ToString();
						Change_Currency("80200002", value);
					}
					else
					{
						MessageBox.Show("Please enter a valid integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
		private void ToolStripLabelDreamlight_Click(object sender, EventArgs e)
		{
			if (ok == false) return;
			using (InputForm inputForm = new InputForm())
			{
				if (inputForm.ShowDialog() == DialogResult.OK)
				{
					if (int.TryParse(inputForm.InputValue, out int value))
					{
						toolStripLabelDreamlight.Text = value.ToString();
						Change_Currency("80300000", value);
					}
					else
					{
						MessageBox.Show("Please enter a valid integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
		private void ToolStripLabelStarCoins_Click(object sender, EventArgs e)
		{
			if (ok == false) return;
			using (InputForm inputForm = new InputForm())
			{
				if (inputForm.ShowDialog() == DialogResult.OK)
				{
					if (int.TryParse(inputForm.InputValue, out int value))
					{
						toolStripLabelStarCoins.Text = value.ToString();
						Change_Currency("80000000", value);
					}
					else
					{
						MessageBox.Show("Please enter a valid integer.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
		private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewCell cell in dataGridViewPets.SelectedCells)
			{
				if (cell.RowIndex != -1 && !dataGridViewPets.Rows[cell.RowIndex].IsNewRow)
				{
					int petItemID = Convert.ToInt32(dataGridViewPets.Rows[cell.RowIndex].Cells["PetItemID"].Value);
					var pet = originalPetsList.FirstOrDefault(p => p.PetItemID == petItemID);
					if (pet != null)
					{
						dataGridViewPets.Rows.RemoveAt(cell.RowIndex);
						originalPetsList.Remove(pet);
						petBindingList.Remove(pet);	
					}
				}
			}
			tabPagePets.Text = "Pets in list : " + petBindingList.Count.ToString();
			toolStripLabelStatut.Text = "Deleted Pet ok";
		}

		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveDataPet();
			SaveDataClothes();
		}
		private void AddAllPetsToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			PopulateAllPetsDataGridView();
			toolStripLabelStatut.Text = "All Pets added ok";
		}
		private void MenuItem_Click(object sender, EventArgs e)
		{
			// Retrieve the clicked menu item
			var menuItem = sender as ToolStripMenuItem;
			if (menuItem != null)
			{
				// Retrieve the ID from the Tag property
				int id = (int)menuItem.Tag;
				AddPet(id, menuItem.Text);
			}
		}
	
		private void unlockAllHousesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			unlock_houses_ok();
		}
		private void unlockAllSkinsNPCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			unlock_skins_ok();
		}
		private void AddAllClothesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClothesBindingList = new BindingList<Clothes>();
			foreach (var item in Clothes.ClothesNames)
			{
				try
				{
					var tt = item.Key;
					var pp = item.Value;
					ClothesBindingList.Add(new Clothes { ItemID = tt, ItemName = pp, Amount = 1 });
				}

				catch (Exception ex)
				{
					Console.WriteLine($"Error parsing item ID: {ex.Message}");
				}
			}
			Init_clothes_grid();
			dataGridViewClothes.DataSource = ClothesBindingList;
		}

		private void ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewCell cell in dataGridViewClothes.SelectedCells)
			{
				if (cell.RowIndex != -1 && !dataGridViewClothes.Rows[cell.RowIndex].IsNewRow)
				{
					dataGridViewClothes.Rows.RemoveAt(cell.RowIndex);
				}
			}
			toolStripLabelStatut.Text = "Deleted Clothes ok";
		}

		private void unlockAllClothesinCollectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Unlock all clothes in collection."
				+ Environment.NewLine +
				"If you want to unlock in youre wardrobe add it to the list.", "Unlock all Clothes", buttons: MessageBoxButtons.OK, MessageBoxIcon.Question);
			Cop_clothescollection();
		}

		private void unlockAllCollectionCritterToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			MessageBox.Show("Unlock all companions in collection."
							+ Environment.NewLine +
							"If you want to unlock in pet cattegory add it to the list.", "Unlock all Companions", buttons: MessageBoxButtons.OK, MessageBoxIcon.Question);
			Cop_petcollection();
		}

		private void default42ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			mightbebuggy();
			change_size_inventory(42);
		}

		private void toolStripMenuItemINV68_Click(object sender, EventArgs e)
		{
			mightbebuggy();
			change_size_inventory(68);
		}

		private void toolStripMenuItemINV80_Click(object sender, EventArgs e)
		{
			mightbebuggy();
			change_size_inventory(80);
		}

		private void toolStripMenuItemINV100_Click(object sender, EventArgs e)
		{
			mightbebuggy();
			change_size_inventory(100);
		}

		#endregion

		#region"Methode"
		public JObject LoadJson(string filePath)
		{
			try
			{
				string json = File.ReadAllText(filePath);
				return JObject.Parse(json);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "LoadJson");
				return null;
			}
		}
		private void SaveDataPet()
		{
			try
			{
				if (rootData != null)
				{
					var petsArray = JArray.FromObject(petBindingList);
					foreach (JObject pet in petsArray)
					{
						pet.Remove("Name");
						pet.Remove("NamePets");
					}
					rootData["Player"]["Pets"] = petsArray;
					SaveJson(filePath, rootData);
				}
				else
				{
					toolStripLabelStatut.Text = "Error";
					MessageBox.Show("No data to save.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "SaveData");
			}
		}
		public void SaveJson(string filePath, JObject rootData)
		{
			try
			{
				string json = JsonConvert.SerializeObject(rootData, Formatting.None); 
				File.WriteAllText(filePath, json);
				toolStripLabelStatut.Text = "Saved successfully.";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "SaveJson");
			}
		}

		//unlock all compagnons in collection
		private void Cop_petcollection()
		{
			try
			{
				string json = File.ReadAllText(filePath);
				JObject data = JObject.Parse(json);

				// Navigate through the nested JSON structure
				if (data["Player"]?["CollectionSets"] is JArray collectionSets)
				{
					foreach (var set in collectionSets)
					{
						if (set["GroupData"] is JArray groupDataArray)
						{
							foreach (var group in groupDataArray)
							{
								// Check if the GroupName matches
								if (group["GroupName"] != null && Pet.groupNamesToCheck.Contains(group["GroupName"].ToString()))
								{
									// Update the state
									group["State"] = "SetState_Completed";
									// Update all GroupsCollectionItems to true
									var items = (JObject)group["GroupsCollectionItems"];
									foreach (var item in items.Properties())
									{
										items[item.Name] = true;
									}
									// Break the loop after updating the desired group
									break;
								}
							}
						}
					}
				}
				toolStripLabelStatut.Text = "Ok collection completed";
				SaveJson(filePath, data);
				Final_load();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "cop_petcollection");
			}
		}
		private void Cop_clothescollection()
		{
			try
			{
				string json = File.ReadAllText(filePath);
				JObject data = JObject.Parse(json);

				// Navigate through the nested JSON structure
				if (data["Player"]?["CollectionSets"] is JArray collectionSets)
				{
					foreach (var set in collectionSets)
					{
						if (set["GroupData"] is JArray groupDataArray)
						{
							foreach (var group in groupDataArray)
							{
								// Check if the GroupName matches
								if (group["GroupName"] != null && Clothes.groupNamesToCheckClothes.Contains(group["GroupName"].ToString()))
								{
									// Update the state
									group["State"] = "SetState_Completed";
									// Update all GroupsCollectionItems to true
									var items = (JObject)group["GroupsCollectionItems"];
									foreach (var item in items.Properties())
									{
										items[item.Name] = true;
									}
									// Break the loop after updating the desired group
									break;
								}
							}
						}
					}
				}
				toolStripLabelStatut.Text = "Ok collection completed";
				SaveJson(filePath, data);
				Final_load();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "cop_petcollection");
			}
		}
		private void SaveDataClothes()
        {
            try
            {
                if (rootData != null)
                {
                    var clothesArray = JArray.FromObject(ClothesBindingList);
                    foreach (JObject clothes in clothesArray)
                    {
                        var itemId = clothes["ItemID"].ToObject<int>();
                    }
                    foreach (var clothes in ClothesBindingList)
                    {
                        var itemObject = new JObject();
                        itemObject["Amount"] = clothes.Amount;
                        rootData["Player"]["ListInventories"]["1"]["Inventory"][clothes.ItemID.ToString()] = itemObject;
                    }
                    SaveJson(filePath, rootData);
                }
                else
                {
                    toolStripLabelStatut.Text = "Error";
                    MessageBox.Show("No data to save.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SaveDataClothes");
            }
        }

        private void Change_Currency(string id, int value)
		{
			try
			{
				string json = File.ReadAllText(filePath);
				JObject data = JObject.Parse(json);
				data["Player"]["CurrencyAmounts"][id] = value;
				toolStripLabelStatut.Text = "Added Currency OK";
				SaveJson(filePath, data);
				Final_load();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "money");
			}
		}
		private void PopulatePetNamesMenu()
		{
			foreach (var entry in Pet.petNames)
			{
				var menuItem = new ToolStripMenuItem(entry.Value)
				{
					Tag = entry.Key 
				};
				menuItem.Click += MenuItem_Click;
				addToolStripMenuItem.DropDownItems.Add(menuItem);
			}
		}
		private void Make_BackupSave()
		{
			try
			{
				string backupDirectory = Path.GetDirectoryName(filePath);
				string backupFilePath = Path.Combine(backupDirectory, $"{Path.GetFileNameWithoutExtension(filePath)}_{DateTime.Now.ToString("HHmmss")}_{"Backup"}{Path.GetExtension(filePath)}");

				File.Copy(filePath, backupFilePath, true);
				Console.WriteLine($"Backup created: {backupFilePath}");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Make Backup");
			}
		}
		private void mightbebuggy()
		{
			MessageBox.Show("Be careful this is a little buggy", "This can be buggy !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		#endregion

		#region "DataGridView Gestion"

		private void Init_pets_grid()
		{
			dataGridViewPets.Rows.Clear();
			dataGridViewPets.Columns.Clear();
			dataGridViewPets.DataSource = null;
			dataGridViewPets.Refresh();
			dataGridViewPets.AutoGenerateColumns = false;
			dataGridViewPets.RowHeadersWidth = 4;
			dataGridViewPets.RowTemplate.Height = 72;

			dataGridViewPets.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "PetItemID",
				DataPropertyName = "PetItemID", // Match the property name in the Pet class
				Name = "PetItemID",
			});

			dataGridViewPets.Columns.Add(new DataGridViewTextBoxColumn
			{
				HeaderText = "Name",
				DataPropertyName = "NamePets", // Assuming you've added a "Name" property to the Pet class
				ReadOnly = true,
				AutoSizeMode = (DataGridViewAutoSizeColumnMode)AutoSizeMode.GrowAndShrink,
			});
			dataGridViewPets.Columns[1].Width = 250;
			dataGridViewPets.Columns.Add(new DataGridViewImageColumn
			{
				HeaderText = "Preview",
				Name = "Image", // Name of the image column
				ImageLayout = (DataGridViewImageCellLayout)ImageLayout.Stretch,
				ReadOnly = true,
			}); ;
		}

        private void Init_clothes_grid()
        {
            dataGridViewClothes.Rows.Clear();
            dataGridViewClothes.Columns.Clear();
            dataGridViewClothes.DataSource = null;
            dataGridViewClothes.Refresh();
            dataGridViewClothes.AutoGenerateColumns = false;
            dataGridViewClothes.RowHeadersWidth = 4;
            dataGridViewClothes.RowTemplate.Height = 72;

            dataGridViewClothes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ClothesItemID",
                DataPropertyName = "ItemID", // Match the property name in the Pet class
                Name = "ClothesItemID",
            });

            dataGridViewClothes.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "ItemName", // Assuming you've added a "Name" property to the Pet class
                ReadOnly = true,
                AutoSizeMode = (DataGridViewAutoSizeColumnMode)AutoSizeMode.GrowAndShrink,
            });
            dataGridViewClothes.Columns[1].Width = 250;

        }
		//Init ALL

		private void unlock_houses_ok()
		{
			string json = File.ReadAllText(filePath);
			JObject data = JObject.Parse(json);

			// Path to the inventory dictionary in JSON
			var inventory = data["Player"]["ListInventories"]["5"]["Inventory"] as JObject;

			// Populate the inventory using the HousesNames dictionary
			foreach (var house in Houses.HousesNames)
			{
				var houseKey = house.Key.ToString();
				if (inventory.ContainsKey(houseKey))
				{
					// If the item already exists, set its Amount to 1
					inventory[houseKey]["Amount"] = 1;
				}
				else
				{
					// If the item does not exist, add it with Amount set to 1
					inventory[houseKey] = new JObject
					{
						["Amount"] = 1
					};
				}
			}
			SaveJson(filePath, data);
			Final_load();
		}
		private void unlock_skins_ok()
		{
			//////////////////////////////next you can create a custom file and load items id's and name from it
			//string path_to_customHouses_data = Path.Combine(appDirectory, jsonFolderPath + "CharactersSkins.json");
			//string load_json = File.ReadAllText(path_to_customHouses_data);
			//SkinsNpc.CharacterSkins = JsonConvert.DeserializeObject<Dictionary<int, string>>(load_json);

			string json = File.ReadAllText(filePath);
			JObject data = JObject.Parse(json);

			// Path to the inventory dictionary in JSON
			var inventory = data["Player"]["ListInventories"]["7"]["Inventory"] as JObject;

			// Populate the inventory using the chara dictionary
			foreach (var skin in SkinsNpc.CharacterSkins)
			{
				var skinKey = skin.Key.ToString();
				if (inventory.ContainsKey(skinKey))
				{
					// If the item already exists, set its Amount to 1
					inventory[skinKey]["Amount"] = 1;
				}
				else
				{
					// If the item does not exist, add it with Amount set to 1
					inventory[skinKey] = new JObject
					{
						["Amount"] = 1
					};
				}
			}
			SaveJson(filePath, data);
			Final_load();
		}

		private void change_size_inventory(int newSize)
		{
			string jsonload = File.ReadAllText(filePath);
			JObject data = JObject.Parse(jsonload);

			// Path to the specific inventory in JSON
			var containerInventory = data["Player"]["ContainerInventories"]["0"];
			var inventoryArray = containerInventory["Inventory"] as JArray;

			//int newSize = 68;

			// Update the Size field
			containerInventory["Size"] = newSize;

			// Count existing items with specific properties
			int currentCount = 0;
			foreach (var item in inventoryArray)
			{
				if ((int)item["ItemID"] == 0 && (int)item["Amount"] == 0 && item["State"] == null)
				{
					currentCount++;
				}
			}

			// Adjust the number of items to match the new size
			if (currentCount < newSize)
			{
				// Add items to match the new size
				for (int i = currentCount; i < newSize; i++)
				{
					inventoryArray.Add(new JObject
					{
						["ItemID"] = 0,
						["Amount"] = 0,
						["State"] = null
					});
				}
			}
			else if (currentCount > newSize)
			{
				// Remove excess items
				int itemsToRemove = currentCount - newSize;
				for (int i = inventoryArray.Count - 1; i >= 0 && itemsToRemove > 0; i--)
				{
					var item = inventoryArray[i];
					if ((int)item["ItemID"] == 0 && (int)item["Amount"] == 0 && item["State"] == null)
					{
						inventoryArray.RemoveAt(i);
						itemsToRemove--;
					}
				}
			}

			// Save the modified JSON back to the file
			//File.WriteAllText(filePath, json.ToString());
			SaveJson(filePath, data);
			Final_load();
			Console.WriteLine("Data updated successfully.");

		}

		private void load_clothes_data(JToken inventoryData)
		{
			ClothesBindingList = new BindingList<Clothes>();

			foreach (var item in inventoryData.Children())
			{
				try
				{
					var pathParts = item.Path.Split('.');
					var itemId = int.Parse(pathParts[pathParts.Length - 1]); // Get the last part of the path

					var amount = (int)item.First["Amount"];

					// Check if item ID exists in the clothes dictionary
					if (Clothes.ClothesNames.ContainsKey(itemId))
					{
						ClothesBindingList.Add(new Clothes { ItemID = itemId, ItemName = Clothes.ClothesNames[itemId], Amount = amount });
					}
					else
					{
						// Handle missing item ID in dictionary
					}
				}

				catch (Exception ex)
				{
					Console.WriteLine($"Error parsing item ID: {item.Path}. {ex.Message}");
				}
			}
			Console.WriteLine($"Loaded {ClothesBindingList.Count} items.");
			dataGridViewClothes.DataSource = ClothesBindingList;

		}
		private void Final_load()
		{
			try
			{
				Init_pets_grid();
				
				Init_clothes_grid();

                unlockAllCollectionCritterToolStripMenuItem.Enabled = true;
				addToolStripMenuItem.Enabled = true;
				saveToolStripMenuItem.Enabled = true;
				addAllPetsToolStripMenuItem.Enabled = true;
				decryptSaveToolStripMenuItem.Enabled = false;
				//toolStripComboBoxVersion.Enabled = false;
				petsToolStripMenuItem.Enabled = true;
				changeInventorySpaceToolStripMenuItem.Enabled = true;
				unlockAllSkinsNPCToolStripMenuItem.Enabled = true;	
				clothesToolStripMenuItem.Enabled = true;
				addAllClothesToolStripMenuItem.Enabled = true;
				unlockAllClothesinCollectionToolStripMenuItem.Enabled = true;
				unlockAllHousesToolStripMenuItem.Enabled = true;	
				ok = true;

                rootData = LoadJson(filePath);

                var inventoryData = rootData["Player"]["ListInventories"]["1"]["Inventory"];
				load_clothes_data(inventoryData);

				var pets = rootData["Player"]["Pets"].ToObject<List<Pet>>();
				//searsh = true;
				LoadPetsData(pets);

				var version = rootData["GameInfo"]["Version"].ToString();
				var Nom = rootData["Player"]["Name"].ToString();
				var Lvl = rootData["Player"]["Level"].ToString();

				var starcoins = rootData["Player"]["CurrencyAmounts"]["80000000"];
				var mist = rootData["Player"]["CurrencyAmounts"]["80000003"];
				var daisycoins = rootData["Player"]["CurrencyAmounts"]["80000009"];
				var pixeldust = rootData["Player"]["CurrencyAmounts"]["80200002"];
				var dreamlight = rootData["Player"]["CurrencyAmounts"]["80300000"];


				toolStripLabelVersion.Text = "Save version : " + version;
				toolStripLabelName.Text = Nom + " lvl : " + Lvl;


				toolStripLabelDreamlight.Text = "Dreamlight : " + dreamlight;
				toolStripLabelPixelDust.Text = "Pixel Dust : " + pixeldust;
				toolStripLabelUnknow.Text = "Daisy Coins : " + daisycoins;
				toolStripLabelStarCoins.Text = "Star Coins : " + starcoins;
				toolStripLabelMist.Text = "Mist : " + mist;


				toolStripLabelStatut.Text = "Successful !";
			}
			catch (Exception ex)
			{
				ok = false;
				petsToolStripMenuItem.Enabled = false;
				clothesToolStripMenuItem.Enabled = false;
				addAllClothesToolStripMenuItem.Enabled = false;

				changeInventorySpaceToolStripMenuItem.Enabled = false;
				unlockAllSkinsNPCToolStripMenuItem.Enabled = false;
				unlockAllHousesToolStripMenuItem.Enabled = false;
				unlockAllClothesinCollectionToolStripMenuItem.Enabled = false;
				addAllPetsToolStripMenuItem.Enabled = false;
				unlockAllCollectionCritterToolStripMenuItem.Enabled = false;
				addToolStripMenuItem.Enabled = false;
				saveToolStripMenuItem.Enabled = false;
				toolStripLabelStatut.Text = "Error";
				MessageBox.Show(ex.Message, "Error loading Save file");
				return;
			}
		}
		//AddPets
		private void AddPet(int IDPet, string name)
		{
			try
			{
				foreach (var item in petBindingList.ToList())
				{
					if (item.PetItemID == IDPet)
					{

						MessageBox.Show("Pet ID already exists in the list."
								+ Environment.NewLine +
								$"{IDPet} Not Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}
				var newPet = new Pet { PetItemID = IDPet , NamePets = name };
				petBindingList.Add(newPet);
				LoadPetsData(petBindingList.ToList());
				toolStripLabelStatut.Text = "Added Pet ok";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "AddPet");
				toolStripLabelStatut.Text = "Error";
			}
		}


	
		public void LoadPetsData(List<Pet> pets)
		{

			if (searsh == true)
			{
				
			}
			else
			{
				///for using search methode we need to store the actual pets list
				originalPetsList = new BindingList<Pet>(pets);
			}

			///
			try
			{
				petBindingList = new BindingList<Pet>(pets);
				dataGridViewPets.DataSource = petBindingList;
				int petItemIDColumnIndex = 0;
				// Populate the name column
				foreach (DataGridViewRow row in dataGridViewPets.Rows)
				{
					// Access the cell directly by index for PetItemID
					if (row.Cells.Count > petItemIDColumnIndex && row.Cells[petItemIDColumnIndex].Value != null)
					{
						int petItemID = Convert.ToInt32(row.Cells[petItemIDColumnIndex].Value);
						if (Pet.petNames.TryGetValue(petItemID, out string petName))
						{
							// Assuming Name is the second column (index 1)
							int nameColumnIndex = 1;
							if (row.Cells.Count > nameColumnIndex)
							{
								if(petName == "Scary Squirrel"|| petName == "Pua")
								{
									row.Cells[nameColumnIndex].Style.BackColor = Color.Red;
									row.Cells[0].Style.BackColor = Color.Red;
									row.Cells[nameColumnIndex].Value = petName + " DONT USE IF YOUR NOT ALREADY OWNED, Unlock it with the quest";
								}
								else
								{
									row.Cells[nameColumnIndex].Value = petName;
								}
								
							}
						}
						string imagePath = Path.Combine(imagesFolderPath, $"{petItemID}.png");
						if (File.Exists(imagePath))
						{
							row.Cells[2].Value = Image.FromFile(imagePath);
						}
						else
						{
							row.Cells[2].Value = Image.FromFile(Path.Combine(imagesFolderPath, "unknow.png"));
						}
					}
				}
				tabPagePets.Text = "Pets in list : " + petBindingList.Count.ToString();
				toolStripLabelStatut.Text = "Loaded Pet's";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "LoadPetsData");
				toolStripLabelStatut.Text = "Error";
			}
		}
		//Add all pets in data
		private void PopulateAllPetsDataGridView()
		{
			petBindingList.Clear();
			foreach (var pet in Pet.petNames)
			{
				//dataGridView.Rows.Add(pet.Key);
				var newPet = new Pet { PetItemID = pet.Key, NamePets = pet.Value }; // Default value, change as needed
				petBindingList.Add(newPet);
				//petBindingList.Add(pet.Key);
			}
			//searsh = true;
			LoadPetsData(petBindingList.ToList());

		}
		public void LoadClothesData(List<Clothes> clothes)
		{
			try
			{
				ClothesBindingList = new BindingList<Clothes>(clothes);
				dataGridViewPets.DataSource = ClothesBindingList;
				int clotheItemIDColumnIndex = 0;
				// Populate the name column
				foreach (DataGridViewRow row in dataGridViewPets.Rows)
				{
					// Access the cell directly by index for PetItemID
					if (row.Cells.Count > clotheItemIDColumnIndex && row.Cells[clotheItemIDColumnIndex].Value != null)
					{
						int clotheItemID = Convert.ToInt32(row.Cells[clotheItemIDColumnIndex].Value);
						if (Clothes.ClothesNames.TryGetValue(clotheItemID, out string clothName))
						{
							// Assuming Name is the second column (index 1)
							int nameColumnIndex = 1;
							if (row.Cells.Count > nameColumnIndex)
							{
								row.Cells[nameColumnIndex].Value = clothName;
							}
						}
					}
				}
				toolStripLabelStatut.Text = "Loaded Clothe's";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "LoadPetsData");
				toolStripLabelStatut.Text = "Error";
			}
		}


		#endregion

		#region"Nightmare Grid"

		///////////Pets
		//Add just numeric not anthing else in datagridview
		private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (dataGridViewPets.CurrentCell.ColumnIndex == 0) // Assuming the first column is the one you want to validate
			{
				TextBox tb = e.Control as TextBox;
				if (tb != null)
				{
					tb.KeyPress -= new KeyPressEventHandler(Tb_KeyPress);
					tb.KeyPress += new KeyPressEventHandler(Tb_KeyPress);
				}
			}
		}
		//Add just numeric not anthing else in datagridview
		private void Tb_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Allow control keys such as backspace
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}
		//Add just numeric not anthing else in datagridview
		private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				string input = e.FormattedValue.ToString();
				if (!IsNumeric(input))
				{
					e.Cancel = true;
					MessageBox.Show("Only numeric values are allowed.");
				}
			}
		}
		//Add just numeric not anthing else in datagridview
		private bool IsNumeric(string input)
		{
			return input.All(char.IsDigit);
		}

		//Check if the same id is already in datagridview
		private void DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (e.ColumnIndex == dataGridViewPets.Columns["PetItemID"].Index && e.RowIndex != -1)
			{
				DataGridViewCell cell = dataGridViewPets.Rows[e.RowIndex].Cells[e.ColumnIndex];

				// Store the original value in the cell's Tag property
				cell.Tag = cell.Value;
			}
		}
		//Ne pas rentrer plus d'une fois le même ID
		private void Check_same_idInDataGrid(DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == dataGridViewPets.Columns["PetItemID"].Index && e.RowIndex != -1)
			{
				DataGridViewCell cell = dataGridViewPets.Rows[e.RowIndex].Cells[e.ColumnIndex];

				if (cell.Value != null)
				{
					int editedID = Convert.ToInt32(cell.Value);
					int originalID = Convert.ToInt32(cell.Tag); // Retrieve the original ID from the cell's Tag property

					// Check if the edited ID already exists in other rows
					foreach (DataGridViewRow row in dataGridViewPets.Rows)
					{
						if (row.Index != e.RowIndex && row.Cells["PetItemID"].Value != null && (int)row.Cells["PetItemID"].Value == editedID)
						{
							MessageBox.Show("Pet ID already exists in the list."
								+ Environment.NewLine +
								$"{editedID} Not Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

							// Restore the original value
							cell.Value = originalID;

							//return;
						}
					}
				}
			}
		}
		//If value is edited we edit the datagridview
		private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			Check_same_idInDataGrid(e);
			if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assume tItemID is the first column
			{
				DataGridViewRow row = dataGridViewPets.Rows[e.RowIndex];
				if (row.Cells[0].Value != null)
				{
					//check_same_idInDataGrid(e);
					int petItemID = Convert.ToInt32(row.Cells[0].Value);
					if (Pet.petNames.TryGetValue(petItemID, out string petName))
					{
						row.Cells[1].Value = petName;
					}
					else
					{
						row.Cells[1].Value = "Unknow Pet ID !";
					}
					string imagePath = Path.Combine(imagesFolderPath, $"{petItemID}.png");
					if (File.Exists(imagePath))
					{
						row.Cells[2].Value = Image.FromFile(imagePath);
					}
					else
					{
						row.Cells[2].Value = Image.FromFile(Path.Combine(imagesFolderPath, "unknow.png"));
					}
				}
			}
		}

		///////////////
		//clothes///
		private void DataGridViewClothes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (dataGridViewPets.CurrentCell.ColumnIndex == 0) // Assuming the first column is the one you want to validate
			{
				TextBox tb = e.Control as TextBox;
				if (tb != null)
				{
					tb.KeyPress -= new KeyPressEventHandler(Tb_KeyPress);
					tb.KeyPress += new KeyPressEventHandler(Tb_KeyPress);
				}
			}
		}

		private void Check_same_idInDataGridClothes(DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == dataGridViewPets.Columns["ItemID"].Index && e.RowIndex != -1)
			{
				DataGridViewCell cell = dataGridViewPets.Rows[e.RowIndex].Cells[e.ColumnIndex];

				if (cell.Value != null)
				{
					int editedID = Convert.ToInt32(cell.Value);
					int originalID = Convert.ToInt32(cell.Tag); // Retrieve the original ID from the cell's Tag property

					// Check if the edited ID already exists in other rows
					foreach (DataGridViewRow row in dataGridViewPets.Rows)
					{
						if (row.Index != e.RowIndex && row.Cells["ItemID"].Value != null && (int)row.Cells["ItemID"].Value == editedID)
						{
							MessageBox.Show("Clothe ID already exists in the list."
								+ Environment.NewLine +
								$"{editedID} Not Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

							// Restore the original value
							cell.Value = originalID;

							//return;
						}
					}
				}
			}
		}
		private void DataGridViewClothes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			Check_same_idInDataGridClothes(e);
			if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Assume tItemID is the first column
			{
				DataGridViewRow row = dataGridViewClothes.Rows[e.RowIndex];
				if (row.Cells[0].Value != null)
				{
					int ClothesItemID = Convert.ToInt32(row.Cells[0].Value);
					if (Clothes.ClothesNames.TryGetValue(ClothesItemID, out string NameClothes))
					{
						row.Cells[1].Value = NameClothes;
					}
					else
					{
						row.Cells[1].Value = "Unknow Clothe ID !";
					}
				}
			}
		}

		private void DataGridViewClothes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				string input = e.FormattedValue.ToString();
				if (!IsNumeric(input))
				{
					e.Cancel = true;
					MessageBox.Show("Only numeric values are allowed.");
				}
			}
		}

		private void DataGridViewClothes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (e.ColumnIndex == dataGridViewPets.Columns["ItemID"].Index && e.RowIndex != -1)
			{
				DataGridViewCell cell = dataGridViewPets.Rows[e.RowIndex].Cells[e.ColumnIndex];

				// Store the original value in the cell's Tag property
				cell.Tag = cell.Value;
			}
		}


		#endregion

		#region"Search in grid"
		private void PerformSearch(string searchValue)
		{
			if (!string.IsNullOrEmpty(searchValue))
			{
				var filteredPets = originalPetsList
					  .Where(p => (p.NamePets?.ToLower().Contains(searchValue) ?? false) || p.PetItemID.ToString().Contains(searchValue))
					.ToList();
				searsh = true;
				LoadPetsData(filteredPets);
				lblNoResults.Visible = true; lblNoResults.Text = filteredPets.Count.ToString() + " found";
			}
			else
			{
				searsh = false;
				LoadPetsData(originalPetsList.ToList());
				lblNoResults.Visible = false;
			}

			HighlightSearchResults(searchValue);
		}

		private void HighlightSearchResults(string searchValue)
		{
			foreach (DataGridViewRow row in dataGridViewPets.Rows)
			{
				foreach (DataGridViewCell cell in row.Cells)
				{
					if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchValue) && !string.IsNullOrEmpty(searchValue))
					{
						cell.Style.BackColor = Color.Yellow; // Highlight matching cells
					}
					else
					{
						if (cell.Value.ToString().ToLower() == "Scary Squirrel" || cell.Value.ToString().ToLower() == "Pua")
						{
							cell.Style.BackColor = Color.Red;
						}

					}
				}
			}
		}

		private void TxtSearch_TextChanged(object sender, EventArgs e)
		{
			PerformSearch(txtSearch.Text.ToLower());
		}
		#endregion

		public Edit_Pets_Form()
		{
			InitializeComponent();
		}
		private void Edit_Pets_Form_Load(object sender, EventArgs e)
		{
			txtSearch.TextChanged += TxtSearch_TextChanged;
			dataGridViewPets.CellBeginEdit += DataGridView_CellBeginEdit;
			dataGridViewPets.CellValidating += DataGridView1_CellValidating;
			dataGridViewPets.CellValueChanged += DataGridView_CellValueChanged;
			dataGridViewPets.EditingControlShowing += DataGridView1_EditingControlShowing;
			dataGridViewClothes.CellBeginEdit += DataGridViewClothes_CellBeginEdit; ;
			dataGridViewClothes.CellValidating += DataGridViewClothes_CellValidating; ;
			dataGridViewClothes.CellValueChanged += DataGridViewClothes_CellValueChanged; ;
			dataGridViewClothes.EditingControlShowing += DataGridViewClothes_EditingControlShowing; ;
			PopulatePetNamesMenu();
		}




	}
}
