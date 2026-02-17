namespace DogWalksEvents
{
    partial class EventsManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventsManager));
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            grbInputs = new GroupBox();
            numWalkEventDuration = new NumericUpDown();
            lblWalkEventDuration = new Label();
            dtpWalkEventDate = new DateTimePicker();
            lblWalkEventDate = new Label();
            numDogAge = new NumericUpDown();
            lblDogAge = new Label();
            txtDogBrand = new TextBox();
            lblDogBrand = new Label();
            txtDogName = new TextBox();
            lblDogName = new Label();
            txtClientPhoneNumber = new TextBox();
            lblClientPhoneNumber = new Label();
            txtClientLastName = new TextBox();
            lblClientLastName = new Label();
            txtClientFirstName = new TextBox();
            lblClientFirstName = new Label();
            btnSave = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            grpFilterOptions = new GroupBox();
            btnClearFilters = new Button();
            btnExecuteFilter = new Button();
            dtpWalkEventDateFilter = new DateTimePicker();
            lblWalkEventDateFilter = new Label();
            numDogAgeFilter = new NumericUpDown();
            lblDogAgeFilter = new Label();
            txtDogBrandFilter = new TextBox();
            lblDogBrandFilter = new Label();
            txtDogNameFilter = new TextBox();
            lblDogNameFilter = new Label();
            txtClientLastNameFilter = new TextBox();
            lblClientLastNameFilter = new Label();
            txtClientFirstNameFilter = new TextBox();
            lblClientFirstNameFilter = new Label();
            btnExit = new Button();
            gridWalkEvents = new DataGridView();
            EventId = new DataGridViewTextBoxColumn();
            ClientId = new DataGridViewTextBoxColumn();
            DogId = new DataGridViewTextBoxColumn();
            ClientFirstName = new DataGridViewTextBoxColumn();
            ClientLastName = new DataGridViewTextBoxColumn();
            ClientPhoneNumber = new DataGridViewTextBoxColumn();
            DogName = new DataGridViewTextBoxColumn();
            DogBrand = new DataGridViewTextBoxColumn();
            DogAge = new DataGridViewTextBoxColumn();
            WalkEventDate = new DataGridViewTextBoxColumn();
            WalkEventDuration = new DataGridViewTextBoxColumn();
            tltEventInputs = new ToolTip(components);
            grbInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numWalkEventDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDogAge).BeginInit();
            grpFilterOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDogAgeFilter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridWalkEvents).BeginInit();
            SuspendLayout();
            // 
            // grbInputs
            // 
            grbInputs.Controls.Add(numWalkEventDuration);
            grbInputs.Controls.Add(lblWalkEventDuration);
            grbInputs.Controls.Add(dtpWalkEventDate);
            grbInputs.Controls.Add(lblWalkEventDate);
            grbInputs.Controls.Add(numDogAge);
            grbInputs.Controls.Add(lblDogAge);
            grbInputs.Controls.Add(txtDogBrand);
            grbInputs.Controls.Add(lblDogBrand);
            grbInputs.Controls.Add(txtDogName);
            grbInputs.Controls.Add(lblDogName);
            grbInputs.Controls.Add(txtClientPhoneNumber);
            grbInputs.Controls.Add(lblClientPhoneNumber);
            grbInputs.Controls.Add(txtClientLastName);
            grbInputs.Controls.Add(lblClientLastName);
            grbInputs.Controls.Add(txtClientFirstName);
            grbInputs.Controls.Add(lblClientFirstName);
            grbInputs.Controls.Add(btnSave);
            grbInputs.Controls.Add(btnClear);
            grbInputs.Controls.Add(btnDelete);
            grbInputs.Location = new Point(882, 50);
            grbInputs.Name = "grbInputs";
            grbInputs.Size = new Size(304, 509);
            grbInputs.TabIndex = 0;
            grbInputs.TabStop = false;
            grbInputs.Text = "Dog Walk Event Data";
            // 
            // numWalkEventDuration
            // 
            numWalkEventDuration.Location = new Point(7, 412);
            numWalkEventDuration.Name = "numWalkEventDuration";
            numWalkEventDuration.Size = new Size(64, 23);
            numWalkEventDuration.TabIndex = 21;
            numWalkEventDuration.Enter += numWalkEventDuration_Enter;
            numWalkEventDuration.MouseDown += numWalkEventDuration_MouseDown;
            // 
            // lblWalkEventDuration
            // 
            lblWalkEventDuration.AutoSize = true;
            lblWalkEventDuration.Location = new Point(7, 394);
            lblWalkEventDuration.Name = "lblWalkEventDuration";
            lblWalkEventDuration.Size = new Size(128, 15);
            lblWalkEventDuration.TabIndex = 20;
            lblWalkEventDuration.Text = "Event Duration (Hours)";
            // 
            // dtpWalkEventDate
            // 
            dtpWalkEventDate.Format = DateTimePickerFormat.Short;
            dtpWalkEventDate.Location = new Point(7, 363);
            dtpWalkEventDate.Name = "dtpWalkEventDate";
            dtpWalkEventDate.Size = new Size(98, 23);
            dtpWalkEventDate.TabIndex = 19;
            // 
            // lblWalkEventDate
            // 
            lblWalkEventDate.AutoSize = true;
            lblWalkEventDate.Location = new Point(7, 345);
            lblWalkEventDate.Name = "lblWalkEventDate";
            lblWalkEventDate.Size = new Size(63, 15);
            lblWalkEventDate.TabIndex = 18;
            lblWalkEventDate.Text = "Event Date";
            // 
            // numDogAge
            // 
            numDogAge.Location = new Point(7, 312);
            numDogAge.Name = "numDogAge";
            numDogAge.Size = new Size(64, 23);
            numDogAge.TabIndex = 17;
            numDogAge.Enter += numDogAge_Enter;
            numDogAge.MouseDown += numDogAge_MouseDown;
            // 
            // lblDogAge
            // 
            lblDogAge.AutoSize = true;
            lblDogAge.Location = new Point(7, 294);
            lblDogAge.Name = "lblDogAge";
            lblDogAge.Size = new Size(53, 15);
            lblDogAge.TabIndex = 16;
            lblDogAge.Text = "Dog Age";
            // 
            // txtDogBrand
            // 
            txtDogBrand.Location = new Point(7, 259);
            txtDogBrand.MaxLength = 50;
            txtDogBrand.Name = "txtDogBrand";
            txtDogBrand.Size = new Size(291, 23);
            txtDogBrand.TabIndex = 15;
            // 
            // lblDogBrand
            // 
            lblDogBrand.AutoSize = true;
            lblDogBrand.Location = new Point(7, 242);
            lblDogBrand.Name = "lblDogBrand";
            lblDogBrand.Size = new Size(63, 15);
            lblDogBrand.TabIndex = 14;
            lblDogBrand.Text = "Dog Brand";
            // 
            // txtDogName
            // 
            txtDogName.Location = new Point(7, 206);
            txtDogName.MaxLength = 60;
            txtDogName.Name = "txtDogName";
            txtDogName.Size = new Size(291, 23);
            txtDogName.TabIndex = 13;
            // 
            // lblDogName
            // 
            lblDogName.AutoSize = true;
            lblDogName.Location = new Point(7, 189);
            lblDogName.Name = "lblDogName";
            lblDogName.Size = new Size(64, 15);
            lblDogName.TabIndex = 12;
            lblDogName.Text = "Dog Name";
            // 
            // txtClientPhoneNumber
            // 
            txtClientPhoneNumber.Location = new Point(7, 155);
            txtClientPhoneNumber.MaxLength = 20;
            txtClientPhoneNumber.Name = "txtClientPhoneNumber";
            txtClientPhoneNumber.Size = new Size(122, 23);
            txtClientPhoneNumber.TabIndex = 11;
            // 
            // lblClientPhoneNumber
            // 
            lblClientPhoneNumber.AutoSize = true;
            lblClientPhoneNumber.Location = new Point(7, 138);
            lblClientPhoneNumber.Name = "lblClientPhoneNumber";
            lblClientPhoneNumber.Size = new Size(122, 15);
            lblClientPhoneNumber.TabIndex = 10;
            lblClientPhoneNumber.Text = "Client Phone Number";
            // 
            // txtClientLastName
            // 
            txtClientLastName.Location = new Point(7, 100);
            txtClientLastName.MaxLength = 60;
            txtClientLastName.Name = "txtClientLastName";
            txtClientLastName.Size = new Size(291, 23);
            txtClientLastName.TabIndex = 9;
            // 
            // lblClientLastName
            // 
            lblClientLastName.AutoSize = true;
            lblClientLastName.Location = new Point(7, 82);
            lblClientLastName.Name = "lblClientLastName";
            lblClientLastName.Size = new Size(97, 15);
            lblClientLastName.TabIndex = 8;
            lblClientLastName.Text = "Client Last Name";
            // 
            // txtClientFirstName
            // 
            txtClientFirstName.Location = new Point(7, 45);
            txtClientFirstName.MaxLength = 60;
            txtClientFirstName.Name = "txtClientFirstName";
            txtClientFirstName.Size = new Size(291, 23);
            txtClientFirstName.TabIndex = 7;
            // 
            // lblClientFirstName
            // 
            lblClientFirstName.AutoSize = true;
            lblClientFirstName.Location = new Point(7, 28);
            lblClientFirstName.Name = "lblClientFirstName";
            lblClientFirstName.Size = new Size(98, 15);
            lblClientFirstName.TabIndex = 6;
            lblClientFirstName.Text = "Client First Name";
            // 
            // btnSave
            // 
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(7, 468);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 36);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Image = (Image)resources.GetObject("btnClear.Image");
            btnClear.ImageAlign = ContentAlignment.MiddleLeft;
            btnClear.Location = new Point(137, 468);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 36);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.TextAlign = ContentAlignment.MiddleRight;
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(224, 468);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 36);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.TextAlign = ContentAlignment.MiddleRight;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // grpFilterOptions
            // 
            grpFilterOptions.Controls.Add(btnClearFilters);
            grpFilterOptions.Controls.Add(btnExecuteFilter);
            grpFilterOptions.Controls.Add(dtpWalkEventDateFilter);
            grpFilterOptions.Controls.Add(lblWalkEventDateFilter);
            grpFilterOptions.Controls.Add(numDogAgeFilter);
            grpFilterOptions.Controls.Add(lblDogAgeFilter);
            grpFilterOptions.Controls.Add(txtDogBrandFilter);
            grpFilterOptions.Controls.Add(lblDogBrandFilter);
            grpFilterOptions.Controls.Add(txtDogNameFilter);
            grpFilterOptions.Controls.Add(lblDogNameFilter);
            grpFilterOptions.Controls.Add(txtClientLastNameFilter);
            grpFilterOptions.Controls.Add(lblClientLastNameFilter);
            grpFilterOptions.Controls.Add(txtClientFirstNameFilter);
            grpFilterOptions.Controls.Add(lblClientFirstNameFilter);
            grpFilterOptions.Location = new Point(12, 2);
            grpFilterOptions.Name = "grpFilterOptions";
            grpFilterOptions.Size = new Size(864, 107);
            grpFilterOptions.TabIndex = 1;
            grpFilterOptions.TabStop = false;
            grpFilterOptions.Text = "Filter Options";
            // 
            // btnClearFilters
            // 
            btnClearFilters.Image = (Image)resources.GetObject("btnClearFilters.Image");
            btnClearFilters.ImageAlign = ContentAlignment.MiddleLeft;
            btnClearFilters.Location = new Point(783, 66);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(75, 36);
            btnClearFilters.TabIndex = 13;
            btnClearFilters.Text = "Clear";
            btnClearFilters.TextAlign = ContentAlignment.MiddleRight;
            btnClearFilters.UseVisualStyleBackColor = true;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // btnExecuteFilter
            // 
            btnExecuteFilter.Image = (Image)resources.GetObject("btnExecuteFilter.Image");
            btnExecuteFilter.ImageAlign = ContentAlignment.MiddleLeft;
            btnExecuteFilter.Location = new Point(783, 22);
            btnExecuteFilter.Name = "btnExecuteFilter";
            btnExecuteFilter.Size = new Size(75, 36);
            btnExecuteFilter.TabIndex = 12;
            btnExecuteFilter.Text = "Filter";
            btnExecuteFilter.TextAlign = ContentAlignment.MiddleRight;
            btnExecuteFilter.UseVisualStyleBackColor = true;
            btnExecuteFilter.Click += btnExecuteFilter_Click;
            // 
            // dtpWalkEventDateFilter
            // 
            dtpWalkEventDateFilter.Checked = false;
            dtpWalkEventDateFilter.Format = DateTimePickerFormat.Short;
            dtpWalkEventDateFilter.Location = new Point(222, 79);
            dtpWalkEventDateFilter.Name = "dtpWalkEventDateFilter";
            dtpWalkEventDateFilter.ShowCheckBox = true;
            dtpWalkEventDateFilter.Size = new Size(98, 23);
            dtpWalkEventDateFilter.TabIndex = 11;
            // 
            // lblWalkEventDateFilter
            // 
            lblWalkEventDateFilter.AutoSize = true;
            lblWalkEventDateFilter.Location = new Point(222, 61);
            lblWalkEventDateFilter.Name = "lblWalkEventDateFilter";
            lblWalkEventDateFilter.Size = new Size(63, 15);
            lblWalkEventDateFilter.TabIndex = 10;
            lblWalkEventDateFilter.Text = "Event Date";
            // 
            // numDogAgeFilter
            // 
            numDogAgeFilter.Location = new Point(7, 79);
            numDogAgeFilter.Name = "numDogAgeFilter";
            numDogAgeFilter.Size = new Size(53, 23);
            numDogAgeFilter.TabIndex = 9;
            // 
            // lblDogAgeFilter
            // 
            lblDogAgeFilter.AutoSize = true;
            lblDogAgeFilter.Location = new Point(7, 61);
            lblDogAgeFilter.Name = "lblDogAgeFilter";
            lblDogAgeFilter.Size = new Size(53, 15);
            lblDogAgeFilter.TabIndex = 8;
            lblDogAgeFilter.Text = "Dog Age";
            // 
            // txtDogBrandFilter
            // 
            txtDogBrandFilter.Location = new Point(611, 35);
            txtDogBrandFilter.Name = "txtDogBrandFilter";
            txtDogBrandFilter.Size = new Size(123, 23);
            txtDogBrandFilter.TabIndex = 7;
            // 
            // lblDogBrandFilter
            // 
            lblDogBrandFilter.AutoSize = true;
            lblDogBrandFilter.Location = new Point(611, 17);
            lblDogBrandFilter.Name = "lblDogBrandFilter";
            lblDogBrandFilter.Size = new Size(63, 15);
            lblDogBrandFilter.TabIndex = 6;
            lblDogBrandFilter.Text = "Dog Brand";
            // 
            // txtDogNameFilter
            // 
            txtDogNameFilter.Location = new Point(439, 35);
            txtDogNameFilter.Name = "txtDogNameFilter";
            txtDogNameFilter.Size = new Size(150, 23);
            txtDogNameFilter.TabIndex = 5;
            // 
            // lblDogNameFilter
            // 
            lblDogNameFilter.AutoSize = true;
            lblDogNameFilter.Location = new Point(439, 17);
            lblDogNameFilter.Name = "lblDogNameFilter";
            lblDogNameFilter.Size = new Size(64, 15);
            lblDogNameFilter.TabIndex = 4;
            lblDogNameFilter.Text = "Dog Name";
            // 
            // txtClientLastNameFilter
            // 
            txtClientLastNameFilter.Location = new Point(222, 35);
            txtClientLastNameFilter.Name = "txtClientLastNameFilter";
            txtClientLastNameFilter.Size = new Size(196, 23);
            txtClientLastNameFilter.TabIndex = 3;
            // 
            // lblClientLastNameFilter
            // 
            lblClientLastNameFilter.AutoSize = true;
            lblClientLastNameFilter.Location = new Point(222, 17);
            lblClientLastNameFilter.Name = "lblClientLastNameFilter";
            lblClientLastNameFilter.Size = new Size(63, 15);
            lblClientLastNameFilter.TabIndex = 2;
            lblClientLastNameFilter.Text = "Last Name";
            // 
            // txtClientFirstNameFilter
            // 
            txtClientFirstNameFilter.Location = new Point(7, 35);
            txtClientFirstNameFilter.Name = "txtClientFirstNameFilter";
            txtClientFirstNameFilter.Size = new Size(196, 23);
            txtClientFirstNameFilter.TabIndex = 1;
            // 
            // lblClientFirstNameFilter
            // 
            lblClientFirstNameFilter.AutoSize = true;
            lblClientFirstNameFilter.Location = new Point(7, 17);
            lblClientFirstNameFilter.Name = "lblClientFirstNameFilter";
            lblClientFirstNameFilter.Size = new Size(64, 15);
            lblClientFirstNameFilter.TabIndex = 0;
            lblClientFirstNameFilter.Text = "First Name";
            // 
            // btnExit
            // 
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageAlign = ContentAlignment.MiddleLeft;
            btnExit.Location = new Point(1105, 12);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 36);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.TextAlign = ContentAlignment.MiddleRight;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // gridWalkEvents
            // 
            gridWalkEvents.AllowUserToAddRows = false;
            gridWalkEvents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.AppWorkspace;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            gridWalkEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            gridWalkEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridWalkEvents.Columns.AddRange(new DataGridViewColumn[] { EventId, ClientId, DogId, ClientFirstName, ClientLastName, ClientPhoneNumber, DogName, DogBrand, DogAge, WalkEventDate, WalkEventDuration });
            gridWalkEvents.Location = new Point(12, 115);
            gridWalkEvents.Name = "gridWalkEvents";
            gridWalkEvents.ReadOnly = true;
            gridWalkEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridWalkEvents.Size = new Size(864, 435);
            gridWalkEvents.TabIndex = 6;
            gridWalkEvents.DataBindingComplete += gridWalkEvents_DataBindingComplete;
            gridWalkEvents.SelectionChanged += gridWalkEvents_SelectionChanged;
            // 
            // EventId
            // 
            EventId.DataPropertyName = "Id";
            EventId.Frozen = true;
            EventId.HeaderText = "EventID";
            EventId.Name = "EventId";
            EventId.ReadOnly = true;
            EventId.Visible = false;
            // 
            // ClientId
            // 
            ClientId.DataPropertyName = "ClientId";
            ClientId.Frozen = true;
            ClientId.HeaderText = "ClientId";
            ClientId.Name = "ClientId";
            ClientId.ReadOnly = true;
            ClientId.Visible = false;
            // 
            // DogId
            // 
            DogId.DataPropertyName = "DogId";
            DogId.Frozen = true;
            DogId.HeaderText = "DigId";
            DogId.Name = "DogId";
            DogId.ReadOnly = true;
            DogId.Visible = false;
            // 
            // ClientFirstName
            // 
            ClientFirstName.DataPropertyName = "ClientFirstName";
            ClientFirstName.Frozen = true;
            ClientFirstName.HeaderText = "First Name";
            ClientFirstName.Name = "ClientFirstName";
            ClientFirstName.ReadOnly = true;
            // 
            // ClientLastName
            // 
            ClientLastName.DataPropertyName = "ClientLastName";
            ClientLastName.Frozen = true;
            ClientLastName.HeaderText = "Last Name";
            ClientLastName.Name = "ClientLastName";
            ClientLastName.ReadOnly = true;
            // 
            // ClientPhoneNumber
            // 
            ClientPhoneNumber.DataPropertyName = "PhoneNumber";
            ClientPhoneNumber.Frozen = true;
            ClientPhoneNumber.HeaderText = "Phone Number";
            ClientPhoneNumber.Name = "ClientPhoneNumber";
            ClientPhoneNumber.ReadOnly = true;
            // 
            // DogName
            // 
            DogName.DataPropertyName = "DogName";
            DogName.Frozen = true;
            DogName.HeaderText = "Dog Name";
            DogName.Name = "DogName";
            DogName.ReadOnly = true;
            // 
            // DogBrand
            // 
            DogBrand.DataPropertyName = "DogBrand";
            DogBrand.Frozen = true;
            DogBrand.HeaderText = "Dog Brand";
            DogBrand.Name = "DogBrand";
            DogBrand.ReadOnly = true;
            // 
            // DogAge
            // 
            DogAge.DataPropertyName = "DogAge";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            DogAge.DefaultCellStyle = dataGridViewCellStyle6;
            DogAge.Frozen = true;
            DogAge.HeaderText = "Dog Age";
            DogAge.Name = "DogAge";
            DogAge.ReadOnly = true;
            // 
            // WalkEventDate
            // 
            WalkEventDate.DataPropertyName = "WalkDate";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            WalkEventDate.DefaultCellStyle = dataGridViewCellStyle7;
            WalkEventDate.Frozen = true;
            WalkEventDate.HeaderText = "Event Date";
            WalkEventDate.Name = "WalkEventDate";
            WalkEventDate.ReadOnly = true;
            // 
            // WalkEventDuration
            // 
            WalkEventDuration.DataPropertyName = "Duration";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            WalkEventDuration.DefaultCellStyle = dataGridViewCellStyle8;
            WalkEventDuration.Frozen = true;
            WalkEventDuration.HeaderText = "Event Duration";
            WalkEventDuration.Name = "WalkEventDuration";
            WalkEventDuration.ReadOnly = true;
            // 
            // tltEventInputs
            // 
            tltEventInputs.ShowAlways = true;
            // 
            // EventsManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1192, 562);
            Controls.Add(gridWalkEvents);
            Controls.Add(btnExit);
            Controls.Add(grpFilterOptions);
            Controls.Add(grbInputs);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EventsManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dog Walk Events Manager";
            Load += EventsManager_Load;
            grbInputs.ResumeLayout(false);
            grbInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numWalkEventDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDogAge).EndInit();
            grpFilterOptions.ResumeLayout(false);
            grpFilterOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDogAgeFilter).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridWalkEvents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grbInputs;
        private GroupBox grpFilterOptions;
        private Button btnSave;
        private Button btnClear;
        private Button btnDelete;
        private Button btnExit;
        private DataGridView gridWalkEvents;
        private TextBox txtClientLastNameFilter;
        private Label lblClientLastNameFilter;
        private TextBox txtClientFirstNameFilter;
        private Label lblClientFirstNameFilter;
        private TextBox txtDogBrandFilter;
        private Label lblDogBrandFilter;
        private TextBox txtDogNameFilter;
        private Label lblDogNameFilter;
        private Button btnExecuteFilter;
        private DateTimePicker dtpWalkEventDateFilter;
        private Label lblWalkEventDateFilter;
        private NumericUpDown numDogAgeFilter;
        private Label lblDogAgeFilter;
        private Label lblClientFirstName;
        private TextBox txtClientPhoneNumber;
        private Label lblClientPhoneNumber;
        private TextBox txtClientLastName;
        private Label lblClientLastName;
        private TextBox txtClientFirstName;
        private TextBox txtDogName;
        private Label lblDogName;
        private NumericUpDown numDogAge;
        private Label lblDogAge;
        private TextBox txtDogBrand;
        private Label lblDogBrand;
        private DateTimePicker dtpWalkEventDate;
        private Label lblWalkEventDate;
        private NumericUpDown numWalkEventDuration;
        private Label lblWalkEventDuration;
        private ToolTip tltEventInputs;
        private Button btnClearFilters;
        private DataGridViewTextBoxColumn EventId;
        private DataGridViewTextBoxColumn ClientId;
        private DataGridViewTextBoxColumn DogId;
        private DataGridViewTextBoxColumn ClientFirstName;
        private DataGridViewTextBoxColumn ClientLastName;
        private DataGridViewTextBoxColumn ClientPhoneNumber;
        private DataGridViewTextBoxColumn DogName;
        private DataGridViewTextBoxColumn DogBrand;
        private DataGridViewTextBoxColumn DogAge;
        private DataGridViewTextBoxColumn WalkEventDate;
        private DataGridViewTextBoxColumn WalkEventDuration;
    }
}
