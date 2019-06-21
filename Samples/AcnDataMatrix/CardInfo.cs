﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;

namespace AcnDataMatrix
{

    public class CardInfo
    {
        public CardInfo(NetworkInterface info, int addressIndex)
        {
            Interface = info;
            AddressIndex = addressIndex;
        }


        private NetworkInterface netInterface;

        public NetworkInterface Interface
        {
            get { return netInterface; }
            set { if (netInterface != value) { netInterface = value; InterfaceId = value.Id;  } }
        }
                        
        public string InterfaceId{ get; set; }        

        public int AddressIndex { get; set; }

        public IPAddress IpAddress
        {
            get
            {
                if (Interface.GetIPProperties().UnicastAddresses.Count > AddressIndex)
                {
                    return Interface.GetIPProperties().UnicastAddresses[AddressIndex].Address;
                }
                else
                {
                    return null;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{1}:  {0}", Interface.Description, IpAddress?.ToString());
        }

        public void SetUpInterfaceFromId(string netInterfaceId)
        {
            foreach (NetworkInterface currInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (currInterface.Id == netInterfaceId)
                {
                    Interface = currInterface;
                }

            }
        }
    }
}
