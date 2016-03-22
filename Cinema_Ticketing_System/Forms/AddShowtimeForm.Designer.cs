namespace Cinema_Ticketing_System
{
    partial class AddShowtimeForm
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
            this.dateAndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.movieBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addShowtimeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateAndTimePicker
            // 
            this.dateAndTimePicker.CustomFormat = "MM-dd-yyyy HH:mm";
            this.dateAndTimePicker.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateAndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateAndTimePicker.Location = new System.Drawing.Point(130, 57);
            this.dateAndTimePicker.Name = "dateAndTimePicker";
            this.dateAndTimePicker.Size = new System.Drawing.Size(184, 28);
            this.dateAndTimePicker.TabIndex = 0;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.priceTextBox.Location = new System.Drawing.Point(130, 97);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(122, 28);
            this.priceTextBox.TabIndex = 1;
            // 
            // movieBox
            // 
            this.movieBox.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.movieBox.FormattingEnabled = true;
            this.movieBox.Location = new System.Drawing.Point(130, 10);
            this.movieBox.Name = "movieBox";
            this.movieBox.Size = new System.Drawing.Size(475, 29);
            this.movieBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Movie:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date and time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Price:";
            // 
            // addShowtimeButton
            // 
            this.addShowtimeButton.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addShowtimeButton.Location = new System.Drawing.Point(229, 156);
            this.addShowtimeButton.Name = "addShowtimeButton";
            this.addShowtimeButton.Size = new System.Drawing.Size(159, 40);
            this.addShowtimeButton.TabIndex = 6;
            this.addShowtimeButton.Text = "Add showtime";
            this.addShowtimeButton.UseVisualStyleBackColor = true;
            this.addShowtimeButton.Click += new System.EventHandler(this.addShowtimeButton_Click);
            // 
            // AddShowtimeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 208);
            this.Controls.Add(this.addShowtimeButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.movieBox);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.dateAndTimePicker);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddShowtimeWindow";
            this.ShowInTaskbar = false;
            this.Text = "Add showtime";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateAndTimePicker;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.ComboBox movieBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addShowtimeButton;
    }
}