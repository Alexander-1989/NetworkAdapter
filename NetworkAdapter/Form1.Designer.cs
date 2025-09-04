
namespace NetworkAdapter
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gatewayLabel = new System.Windows.Forms.Label();
            this.gatewayTextBox = new System.Windows.Forms.TextBox();
            this.subnetLabel = new System.Windows.Forms.Label();
            this.maskTextBox = new System.Windows.Forms.TextBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.ipButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dnsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.dnsLabel = new System.Windows.Forms.Label();
            this.dnsButton = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dhcpLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Adapter Name";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(289, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gatewayLabel);
            this.groupBox2.Controls.Add(this.gatewayTextBox);
            this.groupBox2.Controls.Add(this.subnetLabel);
            this.groupBox2.Controls.Add(this.maskTextBox);
            this.groupBox2.Controls.Add(this.ipLabel);
            this.groupBox2.Controls.Add(this.ipTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 138);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IP";
            // 
            // gatewayLabel
            // 
            this.gatewayLabel.AutoSize = true;
            this.gatewayLabel.Location = new System.Drawing.Point(6, 94);
            this.gatewayLabel.Name = "gatewayLabel";
            this.gatewayLabel.Size = new System.Drawing.Size(49, 13);
            this.gatewayLabel.TabIndex = 6;
            this.gatewayLabel.Text = "Gateway";
            // 
            // gatewayTextBox
            // 
            this.gatewayTextBox.Location = new System.Drawing.Point(6, 110);
            this.gatewayTextBox.Name = "gatewayTextBox";
            this.gatewayTextBox.Size = new System.Drawing.Size(289, 20);
            this.gatewayTextBox.TabIndex = 5;
            // 
            // subnetLabel
            // 
            this.subnetLabel.AutoSize = true;
            this.subnetLabel.Location = new System.Drawing.Point(6, 55);
            this.subnetLabel.Name = "subnetLabel";
            this.subnetLabel.Size = new System.Drawing.Size(41, 13);
            this.subnetLabel.TabIndex = 4;
            this.subnetLabel.Text = "Subnet";
            // 
            // maskTextBox
            // 
            this.maskTextBox.Location = new System.Drawing.Point(6, 71);
            this.maskTextBox.Name = "maskTextBox";
            this.maskTextBox.Size = new System.Drawing.Size(289, 20);
            this.maskTextBox.TabIndex = 3;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(6, 16);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(45, 13);
            this.ipLabel.TabIndex = 2;
            this.ipLabel.Text = "Address";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(6, 32);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(289, 20);
            this.ipTextBox.TabIndex = 1;
            // 
            // ipButton
            // 
            this.ipButton.Location = new System.Drawing.Point(12, 234);
            this.ipButton.Name = "ipButton";
            this.ipButton.Size = new System.Drawing.Size(301, 23);
            this.ipButton.TabIndex = 5;
            this.ipButton.Text = "Set IP";
            this.ipButton.UseVisualStyleBackColor = true;
            this.ipButton.Click += new System.EventHandler(this.IpButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 74);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Set IP(automatically)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dnsRichTextBox);
            this.groupBox3.Controls.Add(this.dnsLabel);
            this.groupBox3.Location = new System.Drawing.Point(12, 293);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 83);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DNS";
            // 
            // dnsRichTextBox
            // 
            this.dnsRichTextBox.Location = new System.Drawing.Point(6, 32);
            this.dnsRichTextBox.Name = "dnsRichTextBox";
            this.dnsRichTextBox.Size = new System.Drawing.Size(289, 45);
            this.dnsRichTextBox.TabIndex = 3;
            this.dnsRichTextBox.Text = "";
            // 
            // dnsLabel
            // 
            this.dnsLabel.AutoSize = true;
            this.dnsLabel.Location = new System.Drawing.Point(6, 16);
            this.dnsLabel.Name = "dnsLabel";
            this.dnsLabel.Size = new System.Drawing.Size(89, 13);
            this.dnsLabel.TabIndex = 2;
            this.dnsLabel.Text = "Preferred Servers";
            // 
            // dnsButton
            // 
            this.dnsButton.Location = new System.Drawing.Point(12, 382);
            this.dnsButton.Name = "dnsButton";
            this.dnsButton.Size = new System.Drawing.Size(301, 23);
            this.dnsButton.TabIndex = 6;
            this.dnsButton.Text = "Set DNS";
            this.dnsButton.UseVisualStyleBackColor = true;
            this.dnsButton.Click += new System.EventHandler(this.DnsButton_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(18, 276);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(135, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Set DNS(automatically)";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // dhcpLabel
            // 
            this.dhcpLabel.AutoSize = true;
            this.dhcpLabel.Location = new System.Drawing.Point(146, 75);
            this.dhcpLabel.Name = "dhcpLabel";
            this.dhcpLabel.Size = new System.Drawing.Size(79, 13);
            this.dhcpLabel.TabIndex = 7;
            this.dhcpLabel.Text = "DHCP Enabled";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 412);
            this.Controls.Add(this.dhcpLabel);
            this.Controls.Add(this.dnsButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ipButton);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Network Adapter Configuration";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label gatewayLabel;
        private System.Windows.Forms.TextBox gatewayTextBox;
        private System.Windows.Forms.Label subnetLabel;
        private System.Windows.Forms.TextBox maskTextBox;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label dnsLabel;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button ipButton;
        private System.Windows.Forms.Button dnsButton;
        private System.Windows.Forms.Label dhcpLabel;
        private System.Windows.Forms.RichTextBox dnsRichTextBox;
    }
}