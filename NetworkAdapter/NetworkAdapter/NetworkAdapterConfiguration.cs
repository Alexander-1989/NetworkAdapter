using System;
using System.Management;
using System.Collections.Generic;

namespace NetworkAdapter.NetService
{
    internal class NetworkAdapterConfiguration
    {
        private readonly char[] separator = new char[]
        {
            ',',
            ';',
            ' ',
            '\n',
            '\t'
        };

        public void SetIp(NetAdapter adapter, string ipAddress, string subnetMask, string gateway)
        {
            string query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description = '{adapter.Name}' AND IPEnabled = True";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                using (ManagementObjectCollection managementCollection = searcher.Get())
                {
                    foreach (ManagementObject managementObject in managementCollection)
                    {
                        if (string.IsNullOrEmpty(ipAddress) || string.IsNullOrEmpty(subnetMask) || string.IsNullOrEmpty(gateway))
                        {
                            managementObject.InvokeMethod("EnableDHCP", null);
                        }
                        else
                        {
                            using (ManagementBaseObject setIp = managementObject.GetMethodParameters("EnableStatic"))
                            {
                                setIp["IPAddress"] = ipAddress.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                                setIp["SubnetMask"] = subnetMask.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                                managementObject.InvokeMethod("EnableStatic", setIp, null);
                            }

                            using (ManagementBaseObject setGateway = managementObject.GetMethodParameters("SetGateways"))
                            {
                                setGateway["DefaultIPGateway"] = gateway.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                                setGateway["GatewayCostMetric"] = new int[] { 1 };
                                managementObject.InvokeMethod("SetGateways", setGateway, null);
                            }
                        }
                        break;
                    }
                }
            }
        }

        public void SetDns(NetAdapter adapter, string dnsServers)
        {
            string query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description = '{adapter.Name}' AND IPEnabled = True";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                using (ManagementObjectCollection managementCollection = searcher.Get())
                {
                    foreach (ManagementObject managementObject in managementCollection)
                    {
                        using (ManagementBaseObject setDNS = managementObject.GetMethodParameters("SetDNSServerSearchOrder"))
                        {
                            setDNS["DNSServerSearchOrder"] = dnsServers.Split(separator, StringSplitOptions.RemoveEmptyEntries); ;
                            managementObject.InvokeMethod("SetDNSServerSearchOrder", setDNS, null);
                        }
                        break;
                    }
                }
            }
        }

        public void GetIpMaskGatewayDns(NetAdapter adapter)
        {
            string query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description = '{adapter.Name}' AND IPEnabled = True";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                using (ManagementObjectCollection managementCollection = searcher.Get())
                {
                    foreach (ManagementObject managementObject in managementCollection)
                    {
                        adapter.IpAddress = ((string[])managementObject["IPAddress"]).First();
                        adapter.SubnetMask = ((string[])managementObject["IPSubnet"]).First();
                        adapter.Gateway = ((string[])managementObject["DefaultIPGateway"]).First();
                        adapter.DNSservers = (string[])managementObject["DNSServerSearchOrder"];
                        break;
                    } 
                }
            }
        }

        public bool IsDHCPEnabled(NetAdapter adapter)
        {
            bool isEnabled = false;
            string query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description = '{adapter.Name}' AND IPEnabled = True";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                using (ManagementObjectCollection managementCollection = searcher.Get())
                {
                    foreach (ManagementObject managementObject in managementCollection)
                    {
                        isEnabled = Convert.ToBoolean(managementObject["DHCPEnabled"]);
                        break;
                    }
                }
            }
            return isEnabled;
        }

        public NetAdapter[] GetAdapters()
        {
            List<NetAdapter> adapters = new List<NetAdapter>();
            string query = "SELECT * FROM Win32_NetworkAdapter WHERE PhysicalAdapter = True";

            using (ManagementObjectSearcher management = new ManagementObjectSearcher(query))
            {
                using (ManagementObjectCollection managementCollection = management.Get())
                {
                    foreach (ManagementObject managementObject in managementCollection)
                    {
                        NetAdapter adapter = new NetAdapter
                            (
                            managementObject["Name"].ToString(),
                            managementObject["NetConnectionID"].ToString()
                            );
                        GetIpMaskGatewayDns(adapter);
                        adapters.Add(adapter);
                    }
                }
            }

            return adapters.ToArray();
        }
    }
}