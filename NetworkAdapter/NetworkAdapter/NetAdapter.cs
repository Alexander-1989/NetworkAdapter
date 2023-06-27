namespace NetworkAdapter.NetService
{
    internal class NetAdapter
    {
        public string Name { get; }
        public string NetConnectionID { get; }
        public string IpAddress { get; set; }
        public string SubnetMask { get; set; }
        public string Gateway { get; set; }
        public string DNSservers { get; set; }

        public NetAdapter(string name, string connectionID)
        {
            Name = name;
            NetConnectionID = connectionID;
        }

        public override string ToString()
        {
            return NetConnectionID + $" ({Name})";
        }
    }
}