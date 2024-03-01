﻿namespace ObjectOrientedPractics.View.Tabs
{
    partial class CartsTab
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
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CartPanel = new System.Windows.Forms.Panel();
            this.CartButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CreateOrderButton = new System.Windows.Forms.Button();
            this.RemoveItemButton = new System.Windows.Forms.Button();
            this.ClearCartButton = new System.Windows.Forms.Button();
            this.CustomerComboBox = new System.Windows.Forms.ComboBox();
            this.CartListBox = new System.Windows.Forms.ListBox();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.AmountHeaderLabel = new System.Windows.Forms.Label();
            this.CartLabel = new System.Windows.Forms.Label();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.ItemsPanel = new System.Windows.Forms.Panel();
            this.ItemButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AddToCartButton = new System.Windows.Forms.Button();
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.ItemsLabel = new System.Windows.Forms.Label();
            this.MainTableLayoutPanel.SuspendLayout();
            this.CartPanel.SuspendLayout();
            this.CartButtonsPanel.SuspendLayout();
            this.ItemsPanel.SuspendLayout();
            this.ItemButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.MainTableLayoutPanel.Controls.Add(this.CartPanel, 1, 0);
            this.MainTableLayoutPanel.Controls.Add(this.ItemsPanel, 0, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 1;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(876, 554);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // CartPanel
            // 
            this.CartPanel.Controls.Add(this.CartButtonsPanel);
            this.CartPanel.Controls.Add(this.CustomerComboBox);
            this.CartPanel.Controls.Add(this.CartListBox);
            this.CartPanel.Controls.Add(this.AmountLabel);
            this.CartPanel.Controls.Add(this.AmountHeaderLabel);
            this.CartPanel.Controls.Add(this.CartLabel);
            this.CartPanel.Controls.Add(this.CustomerLabel);
            this.CartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartPanel.Location = new System.Drawing.Point(353, 3);
            this.CartPanel.Name = "CartPanel";
            this.CartPanel.Size = new System.Drawing.Size(520, 548);
            this.CartPanel.TabIndex = 1;
            // 
            // CartButtonsPanel
            // 
            this.CartButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CartButtonsPanel.ColumnCount = 4;
            this.CartButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CartButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CartButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CartButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.CartButtonsPanel.Controls.Add(this.CreateOrderButton, 0, 0);
            this.CartButtonsPanel.Controls.Add(this.RemoveItemButton, 2, 0);
            this.CartButtonsPanel.Controls.Add(this.ClearCartButton, 3, 0);
            this.CartButtonsPanel.Location = new System.Drawing.Point(3, 251);
            this.CartButtonsPanel.Name = "CartButtonsPanel";
            this.CartButtonsPanel.RowCount = 1;
            this.CartButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CartButtonsPanel.Size = new System.Drawing.Size(514, 46);
            this.CartButtonsPanel.TabIndex = 7;
            // 
            // CreateOrderButton
            // 
            this.CreateOrderButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreateOrderButton.Location = new System.Drawing.Point(3, 3);
            this.CreateOrderButton.Name = "CreateOrderButton";
            this.CreateOrderButton.Size = new System.Drawing.Size(122, 40);
            this.CreateOrderButton.TabIndex = 2;
            this.CreateOrderButton.Text = "Create Order";
            this.CreateOrderButton.UseVisualStyleBackColor = true;
            this.CreateOrderButton.Click += new System.EventHandler(this.CreateOrderButton_Click);
            // 
            // RemoveItemButton
            // 
            this.RemoveItemButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveItemButton.Location = new System.Drawing.Point(259, 3);
            this.RemoveItemButton.Name = "RemoveItemButton";
            this.RemoveItemButton.Size = new System.Drawing.Size(122, 40);
            this.RemoveItemButton.TabIndex = 3;
            this.RemoveItemButton.Text = "Remove Item";
            this.RemoveItemButton.UseVisualStyleBackColor = true;
            this.RemoveItemButton.Click += new System.EventHandler(this.RemoveItemButton_Click);
            // 
            // ClearCartButton
            // 
            this.ClearCartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearCartButton.Location = new System.Drawing.Point(387, 3);
            this.ClearCartButton.Name = "ClearCartButton";
            this.ClearCartButton.Size = new System.Drawing.Size(124, 40);
            this.ClearCartButton.TabIndex = 4;
            this.ClearCartButton.Text = "Clear Cart";
            this.ClearCartButton.UseVisualStyleBackColor = true;
            this.ClearCartButton.Click += new System.EventHandler(this.ClearCartButton_Click);
            // 
            // CustomerComboBox
            // 
            this.CustomerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomerComboBox.FormattingEnabled = true;
            this.CustomerComboBox.Location = new System.Drawing.Point(72, 9);
            this.CustomerComboBox.Name = "CustomerComboBox";
            this.CustomerComboBox.Size = new System.Drawing.Size(445, 21);
            this.CustomerComboBox.TabIndex = 5;
            this.CustomerComboBox.SelectedIndexChanged += new System.EventHandler(this.CustomerComboBox_SelectedIndexChanged);
            // 
            // CartListBox
            // 
            this.CartListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CartListBox.FormattingEnabled = true;
            this.CartListBox.Location = new System.Drawing.Point(3, 67);
            this.CartListBox.Name = "CartListBox";
            this.CartListBox.Size = new System.Drawing.Size(514, 147);
            this.CartListBox.TabIndex = 2;
            // 
            // AmountLabel
            // 
            this.AmountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.AmountLabel.Location = new System.Drawing.Point(247, 228);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AmountLabel.Size = new System.Drawing.Size(270, 20);
            this.AmountLabel.TabIndex = 4;
            this.AmountLabel.Text = "49 999,90";
            this.AmountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AmountHeaderLabel
            // 
            this.AmountHeaderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AmountHeaderLabel.AutoSize = true;
            this.AmountHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.AmountHeaderLabel.Location = new System.Drawing.Point(464, 215);
            this.AmountHeaderLabel.Name = "AmountHeaderLabel";
            this.AmountHeaderLabel.Size = new System.Drawing.Size(53, 13);
            this.AmountHeaderLabel.TabIndex = 3;
            this.AmountHeaderLabel.Text = "Amount:";
            // 
            // CartLabel
            // 
            this.CartLabel.AutoSize = true;
            this.CartLabel.Location = new System.Drawing.Point(3, 51);
            this.CartLabel.Name = "CartLabel";
            this.CartLabel.Size = new System.Drawing.Size(29, 13);
            this.CartLabel.TabIndex = 2;
            this.CartLabel.Text = "Cart:";
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.CustomerLabel.Location = new System.Drawing.Point(3, 12);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(63, 13);
            this.CustomerLabel.TabIndex = 1;
            this.CustomerLabel.Text = "Customer:";
            // 
            // ItemsPanel
            // 
            this.ItemsPanel.Controls.Add(this.ItemButtonsPanel);
            this.ItemsPanel.Controls.Add(this.ItemsListBox);
            this.ItemsPanel.Controls.Add(this.ItemsLabel);
            this.ItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemsPanel.Location = new System.Drawing.Point(3, 3);
            this.ItemsPanel.Name = "ItemsPanel";
            this.ItemsPanel.Size = new System.Drawing.Size(344, 548);
            this.ItemsPanel.TabIndex = 0;
            // 
            // ItemButtonsPanel
            // 
            this.ItemButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemButtonsPanel.ColumnCount = 3;
            this.ItemButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ItemButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ItemButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ItemButtonsPanel.Controls.Add(this.AddToCartButton, 0, 0);
            this.ItemButtonsPanel.Location = new System.Drawing.Point(3, 500);
            this.ItemButtonsPanel.Name = "ItemButtonsPanel";
            this.ItemButtonsPanel.RowCount = 1;
            this.ItemButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ItemButtonsPanel.Size = new System.Drawing.Size(338, 45);
            this.ItemButtonsPanel.TabIndex = 6;
            // 
            // AddToCartButton
            // 
            this.AddToCartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddToCartButton.Location = new System.Drawing.Point(3, 3);
            this.AddToCartButton.Name = "AddToCartButton";
            this.AddToCartButton.Size = new System.Drawing.Size(106, 39);
            this.AddToCartButton.TabIndex = 0;
            this.AddToCartButton.Text = "Add To Cart";
            this.AddToCartButton.UseVisualStyleBackColor = true;
            this.AddToCartButton.Click += new System.EventHandler(this.AddToCartButton_Click);
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.Location = new System.Drawing.Point(3, 16);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(338, 472);
            this.ItemsListBox.TabIndex = 1;
            // 
            // ItemsLabel
            // 
            this.ItemsLabel.AutoSize = true;
            this.ItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.ItemsLabel.Location = new System.Drawing.Point(3, 0);
            this.ItemsLabel.Name = "ItemsLabel";
            this.ItemsLabel.Size = new System.Drawing.Size(37, 13);
            this.ItemsLabel.TabIndex = 0;
            this.ItemsLabel.Text = "Items";
            // 
            // CartsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(460, 307);
            this.Name = "CartsTab";
            this.Size = new System.Drawing.Size(876, 554);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.CartPanel.ResumeLayout(false);
            this.CartPanel.PerformLayout();
            this.CartButtonsPanel.ResumeLayout(false);
            this.ItemsPanel.ResumeLayout(false);
            this.ItemsPanel.PerformLayout();
            this.ItemButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Panel CartPanel;
        private System.Windows.Forms.Panel ItemsPanel;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Label AmountHeaderLabel;
        private System.Windows.Forms.Label CartLabel;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Label ItemsLabel;
        private System.Windows.Forms.ListBox CartListBox;
        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.ComboBox CustomerComboBox;
        private System.Windows.Forms.TableLayoutPanel ItemButtonsPanel;
        private System.Windows.Forms.Button AddToCartButton;
        private System.Windows.Forms.TableLayoutPanel CartButtonsPanel;
        private System.Windows.Forms.Button CreateOrderButton;
        private System.Windows.Forms.Button RemoveItemButton;
        private System.Windows.Forms.Button ClearCartButton;
    }
}
