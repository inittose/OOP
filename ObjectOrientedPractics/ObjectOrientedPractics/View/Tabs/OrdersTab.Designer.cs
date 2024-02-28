namespace ObjectOrientedPractics.View.Tabs
{
    partial class OrdersTab
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
            this.OrderDataGridView = new System.Windows.Forms.DataGridView();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DataPanel = new System.Windows.Forms.Panel();
            this.SelectedOrderPanel = new System.Windows.Forms.Panel();
            this.OrdersLabel = new System.Windows.Forms.Label();
            this.SelectedOrderLabel = new System.Windows.Forms.Label();
            this.OrderItemsLabel = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            this.CreatedLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.AmountHeaderLabel = new System.Windows.Forms.Label();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.CreatedTextBox = new System.Windows.Forms.TextBox();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.AddressControl = new ObjectOrientedPractics.View.Controls.AddressControl();
            this.OrderItemsListBox = new System.Windows.Forms.ListBox();
            this.AmountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).BeginInit();
            this.MainTableLayoutPanel.SuspendLayout();
            this.DataPanel.SuspendLayout();
            this.SelectedOrderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrderDataGridView
            // 
            this.OrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderDataGridView.Location = new System.Drawing.Point(3, 16);
            this.OrderDataGridView.Name = "OrderDataGridView";
            this.OrderDataGridView.Size = new System.Drawing.Size(377, 556);
            this.OrderDataGridView.TabIndex = 0;
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.MainTableLayoutPanel.Controls.Add(this.DataPanel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.SelectedOrderPanel, 1, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 1;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(974, 581);
            this.MainTableLayoutPanel.TabIndex = 1;
            // 
            // DataPanel
            // 
            this.DataPanel.Controls.Add(this.OrdersLabel);
            this.DataPanel.Controls.Add(this.OrderDataGridView);
            this.DataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataPanel.Location = new System.Drawing.Point(3, 3);
            this.DataPanel.Name = "DataPanel";
            this.DataPanel.Size = new System.Drawing.Size(383, 575);
            this.DataPanel.TabIndex = 1;
            // 
            // SelectedOrderPanel
            // 
            this.SelectedOrderPanel.Controls.Add(this.AmountLabel);
            this.SelectedOrderPanel.Controls.Add(this.OrderItemsListBox);
            this.SelectedOrderPanel.Controls.Add(this.AddressControl);
            this.SelectedOrderPanel.Controls.Add(this.StatusComboBox);
            this.SelectedOrderPanel.Controls.Add(this.CreatedTextBox);
            this.SelectedOrderPanel.Controls.Add(this.IdTextBox);
            this.SelectedOrderPanel.Controls.Add(this.AmountHeaderLabel);
            this.SelectedOrderPanel.Controls.Add(this.StatusLabel);
            this.SelectedOrderPanel.Controls.Add(this.CreatedLabel);
            this.SelectedOrderPanel.Controls.Add(this.IdLabel);
            this.SelectedOrderPanel.Controls.Add(this.OrderItemsLabel);
            this.SelectedOrderPanel.Controls.Add(this.SelectedOrderLabel);
            this.SelectedOrderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedOrderPanel.Location = new System.Drawing.Point(392, 3);
            this.SelectedOrderPanel.Name = "SelectedOrderPanel";
            this.SelectedOrderPanel.Size = new System.Drawing.Size(579, 575);
            this.SelectedOrderPanel.TabIndex = 2;
            // 
            // OrdersLabel
            // 
            this.OrdersLabel.AutoSize = true;
            this.OrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.OrdersLabel.Location = new System.Drawing.Point(3, 0);
            this.OrdersLabel.Name = "OrdersLabel";
            this.OrdersLabel.Size = new System.Drawing.Size(44, 13);
            this.OrdersLabel.TabIndex = 1;
            this.OrdersLabel.Text = "Orders";
            // 
            // SelectedOrderLabel
            // 
            this.SelectedOrderLabel.AutoSize = true;
            this.SelectedOrderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.SelectedOrderLabel.Location = new System.Drawing.Point(3, 0);
            this.SelectedOrderLabel.Name = "SelectedOrderLabel";
            this.SelectedOrderLabel.Size = new System.Drawing.Size(92, 13);
            this.SelectedOrderLabel.TabIndex = 2;
            this.SelectedOrderLabel.Text = "Selected Order";
            // 
            // OrderItemsLabel
            // 
            this.OrderItemsLabel.AutoSize = true;
            this.OrderItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.OrderItemsLabel.Location = new System.Drawing.Point(0, 246);
            this.OrderItemsLabel.Name = "OrderItemsLabel";
            this.OrderItemsLabel.Size = new System.Drawing.Size(72, 13);
            this.OrderItemsLabel.TabIndex = 3;
            this.OrderItemsLabel.Text = "Order Items";
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(3, 30);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(24, 13);
            this.IdLabel.TabIndex = 5;
            this.IdLabel.Text = "ID: ";
            // 
            // CreatedLabel
            // 
            this.CreatedLabel.AutoSize = true;
            this.CreatedLabel.Location = new System.Drawing.Point(3, 55);
            this.CreatedLabel.Name = "CreatedLabel";
            this.CreatedLabel.Size = new System.Drawing.Size(47, 13);
            this.CreatedLabel.TabIndex = 6;
            this.CreatedLabel.Text = "Created:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(3, 80);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(40, 13);
            this.StatusLabel.TabIndex = 7;
            this.StatusLabel.Text = "Status:";
            // 
            // AmountHeaderLabel
            // 
            this.AmountHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AmountHeaderLabel.AutoSize = true;
            this.AmountHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.AmountHeaderLabel.Location = new System.Drawing.Point(523, 425);
            this.AmountHeaderLabel.Name = "AmountHeaderLabel";
            this.AmountHeaderLabel.Size = new System.Drawing.Size(53, 13);
            this.AmountHeaderLabel.TabIndex = 8;
            this.AmountHeaderLabel.Text = "Amount:";
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(56, 27);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(121, 20);
            this.IdTextBox.TabIndex = 9;
            // 
            // CreatedTextBox
            // 
            this.CreatedTextBox.Location = new System.Drawing.Point(56, 52);
            this.CreatedTextBox.Name = "CreatedTextBox";
            this.CreatedTextBox.Size = new System.Drawing.Size(121, 20);
            this.CreatedTextBox.TabIndex = 10;
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Location = new System.Drawing.Point(56, 77);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(121, 21);
            this.StatusComboBox.TabIndex = 11;
            // 
            // AddressControl
            // 
            this.AddressControl.Address = null;
            this.AddressControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressControl.Location = new System.Drawing.Point(6, 104);
            this.AddressControl.Name = "AddressControl";
            this.AddressControl.Size = new System.Drawing.Size(570, 139);
            this.AddressControl.TabIndex = 12;
            // 
            // OrderItemsListBox
            // 
            this.OrderItemsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrderItemsListBox.FormattingEnabled = true;
            this.OrderItemsListBox.Location = new System.Drawing.Point(0, 262);
            this.OrderItemsListBox.Name = "OrderItemsListBox";
            this.OrderItemsListBox.Size = new System.Drawing.Size(576, 160);
            this.OrderItemsListBox.TabIndex = 13;
            // 
            // AmountLabel
            // 
            this.AmountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.AmountLabel.Location = new System.Drawing.Point(-63, 440);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(639, 21);
            this.AmountLabel.TabIndex = 14;
            this.AmountLabel.Text = "49 999,90";
            this.AmountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // OrdersTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(764, 468);
            this.Name = "OrdersTab";
            this.Size = new System.Drawing.Size(974, 581);
            ((System.ComponentModel.ISupportInitialize)(this.OrderDataGridView)).EndInit();
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.DataPanel.ResumeLayout(false);
            this.DataPanel.PerformLayout();
            this.SelectedOrderPanel.ResumeLayout(false);
            this.SelectedOrderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView OrderDataGridView;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Panel DataPanel;
        private System.Windows.Forms.Panel SelectedOrderPanel;
        private System.Windows.Forms.Label OrdersLabel;
        private System.Windows.Forms.Label OrderItemsLabel;
        private System.Windows.Forms.Label SelectedOrderLabel;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.TextBox CreatedTextBox;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.Label AmountHeaderLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label CreatedLabel;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.ListBox OrderItemsListBox;
        private Controls.AddressControl AddressControl;
        private System.Windows.Forms.Label AmountLabel;
    }
}
