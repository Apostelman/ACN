﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acn.Rdm;
using System.Net;

namespace Acn.Sockets
{
    public interface IRdmSocket
    {
        event EventHandler<NewPacketEventArgs<RdmPacket>> NewRdmPacket;
        event EventHandler<NewPacketEventArgs<RdmPacket>> RdmPacketSent;

        void SendRdm(RdmPacket packet, RdmEndPoint targetAddress, UId targetId);
        void SendRdm(RdmPacket packet, RdmEndPoint targetAddress, UId targetId, UId sourceId);
    }
}
