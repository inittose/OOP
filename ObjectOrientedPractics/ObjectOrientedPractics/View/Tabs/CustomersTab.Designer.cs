namespace ObjectOrientedPractics.View.Tabs
{
    partial class CustomersTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CustomersListPanel = new System.Windows.Forms.Panel();
            this.ButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.AddRandomButton = new System.Windows.Forms.Button();
            this.CustomersListBox = new System.Windows.Forms.ListBox();
            this.CustomersLabel = new System.Windows.Forms.Label();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SplitedTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SelectedItemPanel = new System.Windows.Forms.Panel();
            this.WrongAddressLabel = new System.Windows.Forms.Label();
            this.WrongFullNameLabel = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.FullNameLabel = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.SelectedCustomerLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CustomersListPanel.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            this.SplitedTableLayoutPanel.SuspendLayout();
            this.SelectedItemPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CustomersListPanel
            // 
            this.CustomersListPanel.Controls.Add(this.ButtonsPanel);
            this.CustomersListPanel.Controls.Add(this.CustomersListBox);
            this.CustomersListPanel.Controls.Add(this.CustomersLabel);
            this.CustomersListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomersListPanel.Location = new System.Drawing.Point(3, 3);
            this.CustomersListPanel.Name = "CustomersListPanel";
            this.CustomersListPanel.Size = new System.Drawing.Size(394, 694);
            this.CustomersListPanel.TabIndex = 0;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsPanel.ColumnCount = 3;
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonsPanel.Controls.Add(this.RemoveButton, 1, 0);
            this.ButtonsPanel.Controls.Add(this.AddButton, 0, 0);
            this.ButtonsPanel.Controls.Add(this.AddRandomButton, 2, 0);
            this.ButtonsPanel.Location = new System.Drawing.Point(3, 639);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.RowCount = 1;
            this.ButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.ButtonsPanel.Size = new System.Drawing.Size(388, 52);
            this.ButtonsPanel.TabIndex = 2;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveButton.Location = new System.Drawing.Point(132, 3);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(123, 46);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddButton.Location = new System.Drawing.Point(3, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(123, 46);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddRandomButton
            // 
            this.AddRandomButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddRandomButton.Location = new System.Drawing.Point(261, 3);
            this.AddRandomButton.Name = "AddRandomButton";
            this.AddRandomButton.Size = new System.Drawing.Size(124, 46);
            this.AddRandomButton.TabIndex = 2;
            this.AddRandomButton.Text = "Add Random";
            this.AddRandomButton.UseVisualStyleBackColor = true;
            this.AddRandomButton.Click += new System.EventHandler(this.AddRandomButton_Click);
            // 
            // CustomersListBox
            // 
            this.CustomersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomersListBox.FormattingEnabled = true;
            this.CustomersListBox.Location = new System.Drawing.Point(3, 22);
            this.CustomersListBox.Name = "CustomersListBox";
            this.CustomersListBox.Size = new System.Drawing.Size(388, 615);
            this.CustomersListBox.TabIndex = 1;
            this.CustomersListBox.SelectedIndexChanged += new System.EventHandler(this.CustomersListBox_SelectedIndexChanged);
            // 
            // CustomersLabel
            // 
            this.CustomersLabel.AutoSize = true;
            this.CustomersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.CustomersLabel.Location = new System.Drawing.Point(3, 3);
            this.CustomersLabel.Margin = new System.Windows.Forms.Padding(3);
            this.CustomersLabel.Name = "CustomersLabel";
            this.CustomersLabel.Size = new System.Drawing.Size(65, 13);
            this.CustomersLabel.TabIndex = 0;
            this.CustomersLabel.Text = "Customers";
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.MainTableLayoutPanel.Controls.Add(this.CustomersListPanel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.SplitedTableLayoutPanel, 1, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 1;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(1000, 700);
            this.MainTableLayoutPanel.TabIndex = 2;
            // 
            // SplitedTableLayoutPanel
            // 
            this.SplitedTableLayoutPanel.ColumnCount = 1;
            this.SplitedTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SplitedTableLayoutPanel.Controls.Add(this.SelectedItemPanel, 0, 0);
            this.SplitedTableLayoutPanel.Controls.Add(this.panel1, 0, 1);
            this.SplitedTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitedTableLayoutPanel.Location = new System.Drawing.Point(403, 3);
            this.SplitedTableLayoutPanel.Name = "SplitedTableLayoutPanel";
            this.SplitedTableLayoutPanel.RowCount = 2;
            this.SplitedTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SplitedTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SplitedTableLayoutPanel.Size = new System.Drawing.Size(594, 694);
            this.SplitedTableLayoutPanel.TabIndex = 1;
            // 
            // SelectedItemPanel
            // 
            this.SelectedItemPanel.Controls.Add(this.WrongAddressLabel);
            this.SelectedItemPanel.Controls.Add(this.WrongFullNameLabel);
            this.SelectedItemPanel.Controls.Add(this.AddressTextBox);
            this.SelectedItemPanel.Controls.Add(this.FullNameTextBox);
            this.SelectedItemPanel.Controls.Add(this.IdTextBox);
            this.SelectedItemPanel.Controls.Add(this.AddressLabel);
            this.SelectedItemPanel.Controls.Add(this.FullNameLabel);
            this.SelectedItemPanel.Controls.Add(this.IdLabel);
            this.SelectedItemPanel.Controls.Add(this.SelectedCustomerLabel);
            this.SelectedItemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedItemPanel.Location = new System.Drawing.Point(3, 3);
            this.SelectedItemPanel.Name = "SelectedItemPanel";
            this.SelectedItemPanel.Size = new System.Drawing.Size(588, 341);
            this.SelectedItemPanel.TabIndex = 3;
            // 
            // WrongAddressLabel
            // 
            this.WrongAddressLabel.AutoSize = true;
            this.WrongAddressLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.WrongAddressLabel.Location = new System.Drawing.Point(63, 107);
            this.WrongAddressLabel.Name = "WrongAddressLabel";
            this.WrongAddressLabel.Size = new System.Drawing.Size(29, 13);
            this.WrongAddressLabel.TabIndex = 10;
            this.WrongAddressLabel.Text = "Error";
            // 
            // WrongFullNameLabel
            // 
            this.WrongFullNameLabel.AutoSize = true;
            this.WrongFullNameLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.WrongFullNameLabel.Location = new System.Drawing.Point(63, 61);
            this.WrongFullNameLabel.Name = "WrongFullNameLabel";
            this.WrongFullNameLabel.Size = new System.Drawing.Size(29, 13);
            this.WrongFullNameLabel.TabIndex = 9;
            this.WrongFullNameLabel.Text = "Error";
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressTextBox.Enabled = false;
            this.AddressTextBox.Location = new System.Drawing.Point(66, 123);
            this.AddressTextBox.Multiline = true;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(519, 215);
            this.AddressTextBox.TabIndex = 7;
            this.AddressTextBox.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            this.AddressTextBox.Leave += new System.EventHandler(this.AddressTextBox_Leave);
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FullNameTextBox.Enabled = false;
            this.FullNameTextBox.Location = new System.Drawing.Point(66, 77);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(519, 20);
            this.FullNameTextBox.TabIndex = 6;
            this.FullNameTextBox.TextChanged += new System.EventHandler(this.FullNameTextBox_TextChanged);
            this.FullNameTextBox.Leave += new System.EventHandler(this.FullNameTextBox_Leave);
            // 
            // IdTextBox
            // 
            this.IdTextBox.Enabled = false;
            this.IdTextBox.Location = new System.Drawing.Point(66, 31);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(100, 20);
            this.IdTextBox.TabIndex = 5;
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(3, 126);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(48, 13);
            this.AddressLabel.TabIndex = 4;
            this.AddressLabel.Text = "Address:";
            // 
            // FullNameLabel
            // 
            this.FullNameLabel.AutoSize = true;
            this.FullNameLabel.Location = new System.Drawing.Point(3, 80);
            this.FullNameLabel.Name = "FullNameLabel";
            this.FullNameLabel.Size = new System.Drawing.Size(57, 13);
            this.FullNameLabel.TabIndex = 3;
            this.FullNameLabel.Text = "Full Name:";
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(3, 34);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(21, 13);
            this.IdLabel.TabIndex = 2;
            this.IdLabel.Text = "ID:";
            // 
            // SelectedCustomerLabel
            // 
            this.SelectedCustomerLabel.AutoSize = true;
            this.SelectedCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.SelectedCustomerLabel.Location = new System.Drawing.Point(3, 3);
            this.SelectedCustomerLabel.Name = "SelectedCustomerLabel";
            this.SelectedCustomerLabel.Size = new System.Drawing.Size(113, 13);
            this.SelectedCustomerLabel.TabIndex = 1;
            this.SelectedCustomerLabel.Text = "Selected Customer";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 341);
            this.panel1.TabIndex = 4;
            // 
            // CustomersTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.MaximumSize = new System.Drawing.Size(1000, 700);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "CustomersTab";
            this.Size = new System.Drawing.Size(1000, 700);
            this.CustomersListPanel.ResumeLayout(false);
            this.CustomersListPanel.PerformLayout();
            this.ButtonsPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.SplitedTableLayoutPanel.ResumeLayout(false);
            this.SelectedItemPanel.ResumeLayout(false);
            this.SelectedItemPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CustomersListPanel;
        private System.Windows.Forms.Label CustomersLabel;
        private System.Windows.Forms.TableLayoutPanel ButtonsPanel;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox CustomersListBox;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel SplitedTableLayoutPanel;
        private System.Windows.Forms.Panel SelectedItemPanel;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Label FullNameLabel;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label SelectedCustomerLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label WrongAddressLabel;
        private System.Windows.Forms.Label WrongFullNameLabel;
        private System.Windows.Forms.Button AddRandomButton;
    }
}
