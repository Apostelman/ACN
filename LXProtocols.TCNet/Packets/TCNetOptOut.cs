﻿using LXProtocols.TCNet.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LXProtocols.TCNet.Packets
{
    /// <summary>
    /// Notifies other nodes that node leaves network.
    /// </summary>
    /// <remarks>
    /// Broadcast once when leaving network.
    /// </remarks>
    /// <seealso cref="LXProtocols.TCNet.Packets.TCNetHeader" />
    public class TCNetOptOut:TCNetHeader
    {
        #region Setup and Initialisation

        /// <summary>
        /// Initializes a new instance of the <see cref="TCNetOptIn"/> class.
        /// </summary>
        public TCNetOptOut() : base(MessageTypes.OptOut)
        {
        }

        #endregion

        #region Packet Content

        /// <summary>
        /// Number of nodes registered by system
        /// </summary>
        public ushort NodeCount { get; set; }

        /// <summary>
        /// Listener port of node (Used to receive unicast messages)
        /// </summary>
        public ushort NodeListenerPort { get; set; }

        #endregion

        #region Read/Write

        /// <summary>
        /// Reads the data from a memory buffer into this packet object.
        /// </summary>
        /// <param name="data">The data to be read.</param>
        /// <remarks>
        /// Decodes the raw data into usable information.
        /// </remarks>
        public override void ReadData(TCNetBinaryReader data)
        {
            base.ReadData(data);

            NodeCount = data.ReadNetwork16();
            NodeListenerPort = data.ReadNetwork16();
        }

        /// <summary>
        /// Writes the contents of this packet into a memory buffer.
        /// </summary>
        /// <param name="data">The data buffer to write the packet contents to.</param>
        public override void WriteData(TCNetBinaryWriter data)
        {
            base.WriteData(data);

            data.WriteToNetwork(NodeCount);
            data.WriteToNetwork(NodeListenerPort);
        }

        #endregion
    }
}
