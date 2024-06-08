using System.Windows.Forms;

namespace ddv_edit
{
	partial class Edit_Pets_Form
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_Pets_Form));
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.decryptSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clothesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addAllClothesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unlockAllClothesinCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.petsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addAllPetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unlockAllCollectionCritterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unlockAllHousesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unlockAllSkinsNPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeInventorySpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.default42ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemINV68 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemINV80 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemINV100 = new System.Windows.Forms.ToolStripMenuItem();
			this.searchInListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabelName = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabelVersion = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabelStatut = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabelStarCoins = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabelDreamlight = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabelPixelDust = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabelMist = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabelUnknow = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
			this.lblNoResults = new System.Windows.Forms.ToolStripLabel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPagePets = new System.Windows.Forms.TabPage();
			this.dataGridViewPets = new System.Windows.Forms.DataGridView();
			this.tabPageClothes = new System.Windows.Forms.TabPage();
			this.dataGridViewClothes = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPagePets.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPets)).BeginInit();
			this.tabPageClothes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewClothes)).BeginInit();
			this.contextMenuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(159, 42);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(158, 38);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripLabelName,
            this.toolStripLabelVersion,
            this.toolStripSeparator2,
            this.toolStripLabelStatut,
            this.toolStripSeparator3,
            this.toolStripLabelStarCoins,
            this.toolStripSeparator4,
            this.toolStripLabelDreamlight,
            this.toolStripSeparator5,
            this.toolStripLabelPixelDust,
            this.toolStripSeparator6,
            this.toolStripLabelMist,
            this.toolStripSeparator7,
            this.toolStripLabelUnknow,
            this.toolStripSeparator8,
            this.toolStripLabel1,
            this.txtSearch,
            this.lblNoResults});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.Size = new System.Drawing.Size(2023, 42);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decryptSaveToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.clothesToolStripMenuItem,
            this.petsToolStripMenuItem,
            this.unlockAllHousesToolStripMenuItem,
            this.unlockAllSkinsNPCToolStripMenuItem,
            this.changeInventorySpaceToolStripMenuItem,
            this.searchInListToolStripMenuItem});
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(91, 36);
			this.toolStripDropDownButton1.Text = "Tools";
			// 
			// decryptSaveToolStripMenuItem
			// 
			this.decryptSaveToolStripMenuItem.Name = "decryptSaveToolStripMenuItem";
			this.decryptSaveToolStripMenuItem.Size = new System.Drawing.Size(404, 44);
			this.decryptSaveToolStripMenuItem.Text = "Load Save";
			this.decryptSaveToolStripMenuItem.Click += new System.EventHandler(this.DecryptSaveToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(404, 44);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// clothesToolStripMenuItem
			// 
			this.clothesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAllClothesToolStripMenuItem,
            this.unlockAllClothesinCollectionToolStripMenuItem});
			this.clothesToolStripMenuItem.Enabled = false;
			this.clothesToolStripMenuItem.Name = "clothesToolStripMenuItem";
			this.clothesToolStripMenuItem.Size = new System.Drawing.Size(404, 44);
			this.clothesToolStripMenuItem.Text = "Clothes ...";
			// 
			// addAllClothesToolStripMenuItem
			// 
			this.addAllClothesToolStripMenuItem.Enabled = false;
			this.addAllClothesToolStripMenuItem.Name = "addAllClothesToolStripMenuItem";
			this.addAllClothesToolStripMenuItem.Size = new System.Drawing.Size(489, 44);
			this.addAllClothesToolStripMenuItem.Text = "Add all clothes";
			this.addAllClothesToolStripMenuItem.Click += new System.EventHandler(this.AddAllClothesToolStripMenuItem_Click);
			// 
			// unlockAllClothesinCollectionToolStripMenuItem
			// 
			this.unlockAllClothesinCollectionToolStripMenuItem.Name = "unlockAllClothesinCollectionToolStripMenuItem";
			this.unlockAllClothesinCollectionToolStripMenuItem.Size = new System.Drawing.Size(489, 44);
			this.unlockAllClothesinCollectionToolStripMenuItem.Text = "Unlock all Clothes (in collection)";
			this.unlockAllClothesinCollectionToolStripMenuItem.Click += new System.EventHandler(this.unlockAllClothesinCollectionToolStripMenuItem_Click);
			// 
			// petsToolStripMenuItem
			// 
			this.petsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.addAllPetsToolStripMenuItem,
            this.unlockAllCollectionCritterToolStripMenuItem});
			this.petsToolStripMenuItem.Enabled = false;
			this.petsToolStripMenuItem.Name = "petsToolStripMenuItem";
			this.petsToolStripMenuItem.Size = new System.Drawing.Size(404, 44);
			this.petsToolStripMenuItem.Text = "Pets ...";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Enabled = false;
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(546, 44);
			this.addToolStripMenuItem.Text = "Add...";
			// 
			// addAllPetsToolStripMenuItem
			// 
			this.addAllPetsToolStripMenuItem.Enabled = false;
			this.addAllPetsToolStripMenuItem.Name = "addAllPetsToolStripMenuItem";
			this.addAllPetsToolStripMenuItem.Size = new System.Drawing.Size(546, 44);
			this.addAllPetsToolStripMenuItem.Text = "Add All Pets";
			this.addAllPetsToolStripMenuItem.Click += new System.EventHandler(this.AddAllPetsToolStripMenuItem_Click_1);
			// 
			// unlockAllCollectionCritterToolStripMenuItem
			// 
			this.unlockAllCollectionCritterToolStripMenuItem.Enabled = false;
			this.unlockAllCollectionCritterToolStripMenuItem.Name = "unlockAllCollectionCritterToolStripMenuItem";
			this.unlockAllCollectionCritterToolStripMenuItem.Size = new System.Drawing.Size(546, 44);
			this.unlockAllCollectionCritterToolStripMenuItem.Text = "Unlock All Companions (in collection)";
			this.unlockAllCollectionCritterToolStripMenuItem.Click += new System.EventHandler(this.unlockAllCollectionCritterToolStripMenuItem_Click_1);
			// 
			// unlockAllHousesToolStripMenuItem
			// 
			this.unlockAllHousesToolStripMenuItem.Enabled = false;
			this.unlockAllHousesToolStripMenuItem.Name = "unlockAllHousesToolStripMenuItem";
			this.unlockAllHousesToolStripMenuItem.Size = new System.Drawing.Size(404, 44);
			this.unlockAllHousesToolStripMenuItem.Text = "Unlock all Houses";
			this.unlockAllHousesToolStripMenuItem.Click += new System.EventHandler(this.unlockAllHousesToolStripMenuItem_Click);
			// 
			// unlockAllSkinsNPCToolStripMenuItem
			// 
			this.unlockAllSkinsNPCToolStripMenuItem.Enabled = false;
			this.unlockAllSkinsNPCToolStripMenuItem.Name = "unlockAllSkinsNPCToolStripMenuItem";
			this.unlockAllSkinsNPCToolStripMenuItem.Size = new System.Drawing.Size(404, 44);
			this.unlockAllSkinsNPCToolStripMenuItem.Text = "Unlock all Skins NPC";
			this.unlockAllSkinsNPCToolStripMenuItem.Click += new System.EventHandler(this.unlockAllSkinsNPCToolStripMenuItem_Click);
			// 
			// changeInventorySpaceToolStripMenuItem
			// 
			this.changeInventorySpaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.default42ToolStripMenuItem,
            this.toolStripMenuItemINV68,
            this.toolStripMenuItemINV80,
            this.toolStripMenuItemINV100});
			this.changeInventorySpaceToolStripMenuItem.Enabled = false;
			this.changeInventorySpaceToolStripMenuItem.Name = "changeInventorySpaceToolStripMenuItem";
			this.changeInventorySpaceToolStripMenuItem.Size = new System.Drawing.Size(404, 44);
			this.changeInventorySpaceToolStripMenuItem.Text = "Change inventory space";
			// 
			// default42ToolStripMenuItem
			// 
			this.default42ToolStripMenuItem.Name = "default42ToolStripMenuItem";
			this.default42ToolStripMenuItem.Size = new System.Drawing.Size(272, 44);
			this.default42ToolStripMenuItem.Text = "Default (42)";
			this.default42ToolStripMenuItem.Click += new System.EventHandler(this.default42ToolStripMenuItem_Click);
			// 
			// toolStripMenuItemINV68
			// 
			this.toolStripMenuItemINV68.Name = "toolStripMenuItemINV68";
			this.toolStripMenuItemINV68.Size = new System.Drawing.Size(272, 44);
			this.toolStripMenuItemINV68.Text = "68";
			this.toolStripMenuItemINV68.Click += new System.EventHandler(this.toolStripMenuItemINV68_Click);
			// 
			// toolStripMenuItemINV80
			// 
			this.toolStripMenuItemINV80.Name = "toolStripMenuItemINV80";
			this.toolStripMenuItemINV80.Size = new System.Drawing.Size(272, 44);
			this.toolStripMenuItemINV80.Text = "80";
			this.toolStripMenuItemINV80.Click += new System.EventHandler(this.toolStripMenuItemINV80_Click);
			// 
			// toolStripMenuItemINV100
			// 
			this.toolStripMenuItemINV100.Name = "toolStripMenuItemINV100";
			this.toolStripMenuItemINV100.Size = new System.Drawing.Size(272, 44);
			this.toolStripMenuItemINV100.Text = "100";
			this.toolStripMenuItemINV100.Click += new System.EventHandler(this.toolStripMenuItemINV100_Click);
			// 
			// searchInListToolStripMenuItem
			// 
			this.searchInListToolStripMenuItem.Name = "searchInListToolStripMenuItem";
			this.searchInListToolStripMenuItem.Size = new System.Drawing.Size(404, 44);
			this.searchInListToolStripMenuItem.Text = "Search in List";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
			// 
			// toolStripLabelName
			// 
			this.toolStripLabelName.Name = "toolStripLabelName";
			this.toolStripLabelName.Size = new System.Drawing.Size(61, 36);
			this.toolStripLabelName.Text = "Lvl : ";
			// 
			// toolStripLabelVersion
			// 
			this.toolStripLabelVersion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripLabelVersion.Name = "toolStripLabelVersion";
			this.toolStripLabelVersion.Size = new System.Drawing.Size(111, 36);
			this.toolStripLabelVersion.Text = "Version : ";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
			// 
			// toolStripLabelStatut
			// 
			this.toolStripLabelStatut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripLabelStatut.Name = "toolStripLabelStatut";
			this.toolStripLabelStatut.Size = new System.Drawing.Size(68, 36);
			this.toolStripLabelStatut.Text = "Idle...";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 42);
			// 
			// toolStripLabelStarCoins
			// 
			this.toolStripLabelStarCoins.Name = "toolStripLabelStarCoins";
			this.toolStripLabelStarCoins.Size = new System.Drawing.Size(139, 36);
			this.toolStripLabelStarCoins.Text = "Star Coins : ";
			this.toolStripLabelStarCoins.Click += new System.EventHandler(this.ToolStripLabelStarCoins_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 42);
			// 
			// toolStripLabelDreamlight
			// 
			this.toolStripLabelDreamlight.Name = "toolStripLabelDreamlight";
			this.toolStripLabelDreamlight.Size = new System.Drawing.Size(152, 36);
			this.toolStripLabelDreamlight.Text = "Dreamlight : ";
			this.toolStripLabelDreamlight.Click += new System.EventHandler(this.ToolStripLabelDreamlight_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 42);
			// 
			// toolStripLabelPixelDust
			// 
			this.toolStripLabelPixelDust.Name = "toolStripLabelPixelDust";
			this.toolStripLabelPixelDust.Size = new System.Drawing.Size(138, 36);
			this.toolStripLabelPixelDust.Text = "Pixel Dust : ";
			this.toolStripLabelPixelDust.Click += new System.EventHandler(this.ToolStripLabelPixelDust_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 42);
			// 
			// toolStripLabelMist
			// 
			this.toolStripLabelMist.Name = "toolStripLabelMist";
			this.toolStripLabelMist.Size = new System.Drawing.Size(79, 36);
			this.toolStripLabelMist.Text = "Mist : ";
			this.toolStripLabelMist.Click += new System.EventHandler(this.ToolStripLabelMist_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 42);
			// 
			// toolStripLabelUnknow
			// 
			this.toolStripLabelUnknow.Name = "toolStripLabelUnknow";
			this.toolStripLabelUnknow.Size = new System.Drawing.Size(156, 36);
			this.toolStripLabelUnknow.Text = "Daisy Coins : ";
			this.toolStripLabelUnknow.Click += new System.EventHandler(this.ToolStripLabelUnknow_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 42);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(79, 36);
			this.toolStripLabel1.Text = "Find : ";
			// 
			// txtSearch
			// 
			this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(200, 42);
			// 
			// lblNoResults
			// 
			this.lblNoResults.Name = "lblNoResults";
			this.lblNoResults.Size = new System.Drawing.Size(39, 36);
			this.lblNoResults.Text = ".....";
			this.lblNoResults.Visible = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPagePets);
			this.tabControl1.Controls.Add(this.tabPageClothes);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 42);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(2023, 954);
			this.tabControl1.TabIndex = 7;
			// 
			// tabPagePets
			// 
			this.tabPagePets.Controls.Add(this.dataGridViewPets);
			this.tabPagePets.Location = new System.Drawing.Point(8, 39);
			this.tabPagePets.Margin = new System.Windows.Forms.Padding(4);
			this.tabPagePets.Name = "tabPagePets";
			this.tabPagePets.Padding = new System.Windows.Forms.Padding(4);
			this.tabPagePets.Size = new System.Drawing.Size(2007, 907);
			this.tabPagePets.TabIndex = 0;
			this.tabPagePets.Text = "Pets ";
			this.tabPagePets.UseVisualStyleBackColor = true;
			// 
			// dataGridViewPets
			// 
			this.dataGridViewPets.AllowUserToAddRows = false;
			this.dataGridViewPets.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewPets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewPets.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridViewPets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewPets.Location = new System.Drawing.Point(4, 4);
			this.dataGridViewPets.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridViewPets.Name = "dataGridViewPets";
			this.dataGridViewPets.RowHeadersWidth = 82;
			this.dataGridViewPets.RowTemplate.Height = 33;
			this.dataGridViewPets.Size = new System.Drawing.Size(1999, 899);
			this.dataGridViewPets.TabIndex = 1;
			// 
			// tabPageClothes
			// 
			this.tabPageClothes.Controls.Add(this.dataGridViewClothes);
			this.tabPageClothes.Location = new System.Drawing.Point(8, 39);
			this.tabPageClothes.Margin = new System.Windows.Forms.Padding(4);
			this.tabPageClothes.Name = "tabPageClothes";
			this.tabPageClothes.Padding = new System.Windows.Forms.Padding(4);
			this.tabPageClothes.Size = new System.Drawing.Size(2007, 907);
			this.tabPageClothes.TabIndex = 1;
			this.tabPageClothes.Text = "Clothes ";
			this.tabPageClothes.UseVisualStyleBackColor = true;
			// 
			// dataGridViewClothes
			// 
			this.dataGridViewClothes.AllowUserToAddRows = false;
			this.dataGridViewClothes.BackgroundColor = System.Drawing.Color.White;
			this.dataGridViewClothes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewClothes.ContextMenuStrip = this.contextMenuStrip2;
			this.dataGridViewClothes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewClothes.Location = new System.Drawing.Point(4, 4);
			this.dataGridViewClothes.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridViewClothes.Name = "dataGridViewClothes";
			this.dataGridViewClothes.RowHeadersWidth = 82;
			this.dataGridViewClothes.RowTemplate.Height = 33;
			this.dataGridViewClothes.Size = new System.Drawing.Size(1999, 899);
			this.dataGridViewClothes.TabIndex = 2;
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.contextMenuStrip2.Name = "contextMenuStrip1";
			this.contextMenuStrip2.Size = new System.Drawing.Size(159, 42);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 38);
			this.toolStripMenuItem1.Text = "Delete";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
			// 
			// Edit_Pets_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(2023, 996);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Edit_Pets_Form";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "[DDV Save Editor] Edit Pets/Clothes & More ";
			this.Load += new System.EventHandler(this.Edit_Pets_Form_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPagePets.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPets)).EndInit();
			this.tabPageClothes.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewClothes)).EndInit();
			this.contextMenuStrip2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabelName;
		private System.Windows.Forms.ToolStripLabel toolStripLabelVersion;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem decryptSaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripLabel toolStripLabelStatut;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripLabel toolStripLabelStarCoins;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripLabel toolStripLabelDreamlight;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripLabel toolStripLabelPixelDust;
		private ToolStripSeparator toolStripSeparator6;
		private ToolStripLabel toolStripLabelUnknow;
		private ToolStripSeparator toolStripSeparator7;
		private ToolStripLabel toolStripLabelMist;
		private ToolStripSeparator toolStripSeparator8;
		private TabControl tabControl1;
		private TabPage tabPagePets;
		private TabPage tabPageClothes;
		private DataGridView dataGridViewClothes;
		private ToolStripMenuItem clothesToolStripMenuItem;
		private ToolStripMenuItem petsToolStripMenuItem;
		private ToolStripMenuItem addToolStripMenuItem;
		private ToolStripMenuItem addAllPetsToolStripMenuItem;
		private ToolStripMenuItem unlockAllCollectionCritterToolStripMenuItem;
		private ToolStripMenuItem addAllClothesToolStripMenuItem;
		public DataGridView dataGridViewPets;
		private ContextMenuStrip contextMenuStrip2;
		private ToolStripMenuItem toolStripMenuItem1;
		private ToolStripMenuItem unlockAllClothesinCollectionToolStripMenuItem;
		private ToolStripMenuItem unlockAllHousesToolStripMenuItem;
		private ToolStripMenuItem unlockAllSkinsNPCToolStripMenuItem;
		private ToolStripMenuItem changeInventorySpaceToolStripMenuItem;
		private ToolStripMenuItem default42ToolStripMenuItem;
		private ToolStripMenuItem toolStripMenuItemINV68;
		private ToolStripMenuItem toolStripMenuItemINV80;
		private ToolStripMenuItem toolStripMenuItemINV100;
		private ToolStripMenuItem searchInListToolStripMenuItem;
		private ToolStripTextBox txtSearch;
		private ToolStripLabel toolStripLabel1;
		private ToolStripLabel lblNoResults;
	}
}

