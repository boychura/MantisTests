using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinimalisticTelnet;

namespace MantisTests
{
    public class JamesHelper : BaseHelper
    {
        public JamesHelper(ApplicationManager manager) : base(manager) { }

        public void Add(AccountData account)
        {
            if (Verify(account))
            {
                return;
            }
            TelnetConnection telnet = LogiToJames();
            telnet.WriteLine("adduser" + account.Name + " " + account.Password);
            System.Console.WriteLine(telnet.Read());
        }

        public void Delete(AccountData account)
        {
            if (! Verify(account))
            {
                return;
            }
            TelnetConnection telnet = LogiToJames();
            telnet.WriteLine("deluser" + account.Name);
            System.Console.WriteLine(telnet.Read());
        }
        public bool Verify(AccountData account)
        {
            TelnetConnection telnet = LogiToJames();
            telnet.WriteLine("verify" + account.Name);
            String s = telnet.Read();
            System.Console.WriteLine(s);
            return ! s.Contains("does not exist");
        }

        private TelnetConnection LogiToJames()
        {
            TelnetConnection telnet = new TelnetConnection("localhost", 4555);
            System.Console.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.WriteLine(telnet.Read());
            telnet.WriteLine("root");
            System.Console.WriteLine(telnet.Read());
            return telnet;
        }
    }
}
