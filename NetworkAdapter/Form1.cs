using System;
using System.Drawing;
using System.Windows.Forms;
using NetworkAdapter.NetService;

namespace NetworkAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox1.KeyPress += (s, e) => e.Handled = true;
        }

        private readonly NetworkAdapterConfiguration netAdapter = new NetworkAdapterConfiguration();

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is NetAdapter adapter)
            {
                ipTextBox.Text = adapter.IpAddress;
                maskTextBox.Text = adapter.SubnetMask;
                gatewayTextBox.Text = adapter.Gateway;
                bool dhcpEnabled = netAdapter.IsDHCPEnabled(adapter);

                if (adapter.DNSservers != null)
                {
                    dnsRichTextBox.Text = string.Join("\n", adapter.DNSservers);
                }

                if (dhcpEnabled)
                {
                    dhcpLabel.Text = "DHCP Enabled";
                    dhcpLabel.BackColor = Color.ForestGreen;
                }
                else
                {
                    dhcpLabel.Text = "DHCP Disabled";
                    dhcpLabel.BackColor = Color.Red;
                }

                checkBox1.Checked = dhcpEnabled;
                checkBox2.Checked = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(netAdapter.GetAdapters());

            int countItems = comboBox1.Items.Count;
            if (countItems > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ipButton.Text = "Set IP(automatically)";
                groupBox2.Enabled = false;
            }
            else
            {
                ipButton.Text = "Set IP";
                groupBox2.Enabled = true;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                dnsButton.Text = "Set DNS(automatically)";
                groupBox3.Enabled = false;
            }
            else
            {
                dnsButton.Text = "Set DNS";
                groupBox3.Enabled = true;
            }
        }

        private void IpButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is NetAdapter adapter)
            {
                if (checkBox1.Checked)
                {
                    netAdapter.SetIp(adapter, null, null, null);
                }
                else
                {
                    netAdapter.SetIp(adapter, ipTextBox.Text, maskTextBox.Text, gatewayTextBox.Text);
                }
            }
        }

        private void DnsButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is NetAdapter adapter)
            {
                if (checkBox2.Checked)
                {
                    netAdapter.SetDns(adapter, null);
                }
                else
                {
                    netAdapter.SetDns(adapter, dnsRichTextBox.Text);
                }
            }
        }
    }
}