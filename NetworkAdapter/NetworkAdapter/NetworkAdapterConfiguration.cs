using System;
using System.Linq;
using System.Management;
using System.Collections.Generic;

namespace NetworkAdapter.NetService
{
    internal class NetworkAdapterConfiguration
    {
        private readonly char[] separator = new char[] { ',', ';', ' ' };

        public void SetIp(string name, string ipAddress, string subnetMask, string gateway)
        {
            string query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description = '{name}' AND IPEnabled = True";
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

        public void SetDns(string name, string dnsServers)
        {
            string query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description = '{name}' AND IPEnabled = True";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                using (ManagementObjectCollection managementCollection = searcher.Get())
                {
                    foreach (ManagementObject managementObject in managementCollection)
                    {
                        using (ManagementBaseObject setDNS = managementObject.GetMethodParameters("SetDNSServerSearchOrder"))
                        {
                            setDNS["DNSServerSearchOrder"] = dnsServers?.Split(separator, StringSplitOptions.RemoveEmptyEntries);
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
                        adapter.IpAddress = managementObject["IPAddress"] != null ? ((string[])managementObject["IPAddress"])[0] : "";
                        adapter.SubnetMask = managementObject["IPSubnet"] != null ? ((string[])managementObject["IPSubnet"])[0] : "";
                        adapter.Gateway = managementObject["DefaultIPGateway"] != null ? ((string[])managementObject["DefaultIPGateway"])[0] : "";
                        adapter.DNSservers = managementObject["DNSServerSearchOrder"] != null ? string.Join("; ", (string[])managementObject["DNSServerSearchOrder"]) : "";
                        break;
                    } 
                }
            }
        }

        public bool IsDHCPEnabled(NetAdapter adapter)
        {
            bool result = false;
            string query = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description = '{adapter.Name}' AND IPEnabled = True";
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                using (ManagementObjectCollection managementCollection = searcher.Get())
                {
                    foreach (ManagementObject managementObject in managementCollection)
                    {
                        result = (bool)managementObject["DHCPEnabled"];
                        break;
                    }
                }
            }
            return result;
        }

        public NetAdapter[] GetAdapters()
        {
            List<NetAdapter> adapters = new List<NetAdapter>();
            string query = "SELECT * FROM Win32_NetworkAdapter WHERE PhysicalAdapter = True";

            using (ManagementObjectSearcher management = new ManagementObjectSearcher(query))
            {
                using (ManagementObjectCollection managementCollection = management.Get())
                {
                    foreach (ManagementBaseObject managementObject in managementCollection)
                    {
                        adapters.Add(new NetAdapter($"{managementObject["Name"]}", $"{managementObject["NetConnectionID"]}"));
                    }
                }
            }

            return adapters.ToArray();
        }
    }
}