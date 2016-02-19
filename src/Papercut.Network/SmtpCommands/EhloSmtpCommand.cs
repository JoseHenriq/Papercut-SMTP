﻿namespace Papercut.Network.SmtpCommands
{
    using System.Collections.Generic;
    using System.Linq;

    using Papercut.Core.Helper;
    using Papercut.Core.Network;

    public class EhloSmtpCommand : BaseSmtpCommand
    {
        protected override IEnumerable<string> GetMatchCommands()
        {
            return new[] { "EHLO" };
        }

        protected override void Run(string command, string[] args)
        {
            Session.Sender = args.FirstOrDefault() ?? string.Empty;

            Connection.SendLine("250-{0}", NetworkHelper.GetLocalDnsHostName());
            Connection.SendLine("250-8BITMIME");
            Connection.SendLine("250 OK");
        }
    }
}