namespace Cinema_Ticketing_System
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ticketSaleTab = new System.Windows.Forms.TabPage();
            this.scheduleGridView = new System.Windows.Forms.DataGridView();
            this.showtimeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runningTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movieId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chooseSeatButton = new System.Windows.Forms.Button();
            this.movieManagementTab = new System.Windows.Forms.TabPage();
            this.deleteMovieButton = new System.Windows.Forms.Button();
            this.editMovieButton = new System.Windows.Forms.Button();
            this.addMovieButton = new System.Windows.Forms.Button();
            this.movieGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._runningTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduleManagementTab = new System.Windows.Forms.TabPage();
            this.deleteShowtimeButton = new System.Windows.Forms.Button();
            this.editShowtimeButton = new System.Windows.Forms.Button();
            this.addShowtimeButton = new System.Windows.Forms.Button();
            this.showtimeGridView = new System.Windows.Forms.DataGridView();
            this._showtimeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dateAndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movieName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.ticketSaleTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGridView)).BeginInit();
            this.movieManagementTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movieGridView)).BeginInit();
            this.scheduleManagementTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showtimeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.ticketSaleTab);
            this.tabControl.Controls.Add(this.movieManagementTab);
            this.tabControl.Controls.Add(this.scheduleManagementTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1050, 390);
            this.tabControl.TabIndex = 0;
            // 
            // ticketSaleTab
            // 
            this.ticketSaleTab.Controls.Add(this.scheduleGridView);
            this.ticketSaleTab.Controls.Add(this.chooseSeatButton);
            this.ticketSaleTab.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ticketSaleTab.Location = new System.Drawing.Point(4, 29);
            this.ticketSaleTab.Name = "ticketSaleTab";
            this.ticketSaleTab.Padding = new System.Windows.Forms.Padding(3);
            this.ticketSaleTab.Size = new System.Drawing.Size(1042, 357);
            this.ticketSaleTab.TabIndex = 0;
            this.ticketSaleTab.Text = "Ticket sale";
            this.ticketSaleTab.UseVisualStyleBackColor = true;
            // 
            // scheduleGridView
            // 
            this.scheduleGridView.AllowUserToAddRows = false;
            this.scheduleGridView.AllowUserToDeleteRows = false;
            this.scheduleGridView.AllowUserToOrderColumns = true;
            this.scheduleGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scheduleGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.scheduleGridView.BackgroundColor = System.Drawing.Color.White;
            this.scheduleGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scheduleGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.scheduleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.showtimeId,
            this.dateAndTime,
            this.filmName,
            this.runningTime,
            this.price,
            this.movieId});
            this.scheduleGridView.Location = new System.Drawing.Point(8, 18);
            this.scheduleGridView.MultiSelect = false;
            this.scheduleGridView.Name = "scheduleGridView";
            this.scheduleGridView.ReadOnly = true;
            this.scheduleGridView.RowTemplate.Height = 24;
            this.scheduleGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scheduleGridView.Size = new System.Drawing.Size(1026, 245);
            this.scheduleGridView.TabIndex = 1;
            // 
            // showtimeId
            // 
            this.showtimeId.HeaderText = "";
            this.showtimeId.Name = "showtimeId";
            this.showtimeId.ReadOnly = true;
            this.showtimeId.Visible = false;
            // 
            // dateAndTime
            // 
            this.dateAndTime.HeaderText = "Date and time";
            this.dateAndTime.Name = "dateAndTime";
            this.dateAndTime.ReadOnly = true;
            // 
            // filmName
            // 
            this.filmName.HeaderText = "Film name";
            this.filmName.Name = "filmName";
            this.filmName.ReadOnly = true;
            // 
            // runningTime
            // 
            this.runningTime.HeaderText = "Running time";
            this.runningTime.Name = "runningTime";
            this.runningTime.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // movieId
            // 
            this.movieId.HeaderText = "";
            this.movieId.Name = "movieId";
            this.movieId.ReadOnly = true;
            this.movieId.Visible = false;
            // 
            // chooseSeatButton
            // 
            this.chooseSeatButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseSeatButton.Location = new System.Drawing.Point(438, 284);
            this.chooseSeatButton.Name = "chooseSeatButton";
            this.chooseSeatButton.Size = new System.Drawing.Size(168, 65);
            this.chooseSeatButton.TabIndex = 0;
            this.chooseSeatButton.Text = "Choose seat";
            this.chooseSeatButton.UseVisualStyleBackColor = true;
            this.chooseSeatButton.Click += new System.EventHandler(this.chooseSeatButton_Click);
            // 
            // movieManagementTab
            // 
            this.movieManagementTab.Controls.Add(this.deleteMovieButton);
            this.movieManagementTab.Controls.Add(this.editMovieButton);
            this.movieManagementTab.Controls.Add(this.addMovieButton);
            this.movieManagementTab.Controls.Add(this.movieGridView);
            this.movieManagementTab.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieManagementTab.Location = new System.Drawing.Point(4, 29);
            this.movieManagementTab.Name = "movieManagementTab";
            this.movieManagementTab.Padding = new System.Windows.Forms.Padding(3);
            this.movieManagementTab.Size = new System.Drawing.Size(1042, 357);
            this.movieManagementTab.TabIndex = 1;
            this.movieManagementTab.Text = "Movie management";
            this.movieManagementTab.UseVisualStyleBackColor = true;
            // 
            // deleteMovieButton
            // 
            this.deleteMovieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteMovieButton.Location = new System.Drawing.Point(388, 310);
            this.deleteMovieButton.Name = "deleteMovieButton";
            this.deleteMovieButton.Size = new System.Drawing.Size(168, 33);
            this.deleteMovieButton.TabIndex = 3;
            this.deleteMovieButton.Text = "Delete movie";
            this.deleteMovieButton.UseVisualStyleBackColor = true;
            this.deleteMovieButton.Click += new System.EventHandler(this.deleteMovieButton_Click);
            // 
            // editMovieButton
            // 
            this.editMovieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editMovieButton.Location = new System.Drawing.Point(195, 310);
            this.editMovieButton.Name = "editMovieButton";
            this.editMovieButton.Size = new System.Drawing.Size(168, 33);
            this.editMovieButton.TabIndex = 2;
            this.editMovieButton.Text = "Edit movie";
            this.editMovieButton.UseVisualStyleBackColor = true;
            this.editMovieButton.Click += new System.EventHandler(this.editMovieButton_Click);
            // 
            // addMovieButton
            // 
            this.addMovieButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addMovieButton.Location = new System.Drawing.Point(6, 310);
            this.addMovieButton.Name = "addMovieButton";
            this.addMovieButton.Size = new System.Drawing.Size(168, 33);
            this.addMovieButton.TabIndex = 1;
            this.addMovieButton.Text = "Add movie";
            this.addMovieButton.UseVisualStyleBackColor = true;
            this.addMovieButton.Click += new System.EventHandler(this.addMovieButton_Click);
            // 
            // movieGridView
            // 
            this.movieGridView.AllowUserToAddRows = false;
            this.movieGridView.AllowUserToDeleteRows = false;
            this.movieGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movieGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.movieGridView.BackgroundColor = System.Drawing.Color.White;
            this.movieGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.movieGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.movieGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.movieGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this._runningTime,
            this.description});
            this.movieGridView.Location = new System.Drawing.Point(8, 6);
            this.movieGridView.MultiSelect = false;
            this.movieGridView.Name = "movieGridView";
            this.movieGridView.ReadOnly = true;
            this.movieGridView.RowTemplate.Height = 24;
            this.movieGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.movieGridView.Size = new System.Drawing.Size(1026, 298);
            this.movieGridView.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // _runningTime
            // 
            this._runningTime.HeaderText = "Running time";
            this._runningTime.Name = "_runningTime";
            this._runningTime.ReadOnly = true;
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // scheduleManagementTab
            // 
            this.scheduleManagementTab.Controls.Add(this.deleteShowtimeButton);
            this.scheduleManagementTab.Controls.Add(this.editShowtimeButton);
            this.scheduleManagementTab.Controls.Add(this.addShowtimeButton);
            this.scheduleManagementTab.Controls.Add(this.showtimeGridView);
            this.scheduleManagementTab.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scheduleManagementTab.Location = new System.Drawing.Point(4, 29);
            this.scheduleManagementTab.Name = "scheduleManagementTab";
            this.scheduleManagementTab.Padding = new System.Windows.Forms.Padding(3);
            this.scheduleManagementTab.Size = new System.Drawing.Size(1042, 357);
            this.scheduleManagementTab.TabIndex = 2;
            this.scheduleManagementTab.Text = "Schedule management";
            this.scheduleManagementTab.UseVisualStyleBackColor = true;
            // 
            // deleteShowtimeButton
            // 
            this.deleteShowtimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteShowtimeButton.Location = new System.Drawing.Point(390, 311);
            this.deleteShowtimeButton.Name = "deleteShowtimeButton";
            this.deleteShowtimeButton.Size = new System.Drawing.Size(168, 33);
            this.deleteShowtimeButton.TabIndex = 6;
            this.deleteShowtimeButton.Text = "Delete showtime";
            this.deleteShowtimeButton.UseVisualStyleBackColor = true;
            this.deleteShowtimeButton.Click += new System.EventHandler(this.deleteShowtimeButton_Click);
            // 
            // editShowtimeButton
            // 
            this.editShowtimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editShowtimeButton.Location = new System.Drawing.Point(197, 311);
            this.editShowtimeButton.Name = "editShowtimeButton";
            this.editShowtimeButton.Size = new System.Drawing.Size(168, 33);
            this.editShowtimeButton.TabIndex = 5;
            this.editShowtimeButton.Text = "Edit showtime";
            this.editShowtimeButton.UseVisualStyleBackColor = true;
            this.editShowtimeButton.Click += new System.EventHandler(this.editShowtimeButton_Click);
            // 
            // addShowtimeButton
            // 
            this.addShowtimeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addShowtimeButton.Location = new System.Drawing.Point(8, 311);
            this.addShowtimeButton.Name = "addShowtimeButton";
            this.addShowtimeButton.Size = new System.Drawing.Size(168, 33);
            this.addShowtimeButton.TabIndex = 4;
            this.addShowtimeButton.Text = "Add showtime";
            this.addShowtimeButton.UseVisualStyleBackColor = true;
            this.addShowtimeButton.Click += new System.EventHandler(this.addShowtimeButton_Click);
            // 
            // showtimeGridView
            // 
            this.showtimeGridView.AllowUserToAddRows = false;
            this.showtimeGridView.AllowUserToDeleteRows = false;
            this.showtimeGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showtimeGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.showtimeGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.showtimeGridView.BackgroundColor = System.Drawing.Color.White;
            this.showtimeGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.showtimeGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.showtimeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showtimeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._showtimeId,
            this._dateAndTime,
            this.movieName,
            this._price});
            this.showtimeGridView.Location = new System.Drawing.Point(8, 6);
            this.showtimeGridView.Name = "showtimeGridView";
            this.showtimeGridView.ReadOnly = true;
            this.showtimeGridView.RowTemplate.Height = 24;
            this.showtimeGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.showtimeGridView.Size = new System.Drawing.Size(1026, 290);
            this.showtimeGridView.TabIndex = 0;
            // 
            // _showtimeId
            // 
            this._showtimeId.HeaderText = "Id";
            this._showtimeId.Name = "_showtimeId";
            this._showtimeId.ReadOnly = true;
            // 
            // _dateAndTime
            // 
            this._dateAndTime.HeaderText = "Date and time";
            this._dateAndTime.Name = "_dateAndTime";
            this._dateAndTime.ReadOnly = true;
            // 
            // movieName
            // 
            this.movieName.HeaderText = "Movie name";
            this.movieName.Name = "movieName";
            this.movieName.ReadOnly = true;
            // 
            // _price
            // 
            this._price.HeaderText = "Price";
            this._price.Name = "_price";
            this._price.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 390);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cinema Ticketing System";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControl.ResumeLayout(false);
            this.ticketSaleTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGridView)).EndInit();
            this.movieManagementTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.movieGridView)).EndInit();
            this.scheduleManagementTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.showtimeGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage ticketSaleTab;
        private System.Windows.Forms.TabPage movieManagementTab;
        private System.Windows.Forms.Button chooseSeatButton;
        private System.Windows.Forms.TabPage scheduleManagementTab;
        private System.Windows.Forms.DataGridView scheduleGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn showtimeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn filmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn runningTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn movieId;
        private System.Windows.Forms.DataGridView movieGridView;
        private System.Windows.Forms.DataGridView showtimeGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn _showtimeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dateAndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn movieName;
        private System.Windows.Forms.DataGridViewTextBoxColumn _price;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn _runningTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.Button addMovieButton;
        private System.Windows.Forms.Button deleteMovieButton;
        private System.Windows.Forms.Button editMovieButton;
        private System.Windows.Forms.Button deleteShowtimeButton;
        private System.Windows.Forms.Button editShowtimeButton;
        private System.Windows.Forms.Button addShowtimeButton;
    }
}

