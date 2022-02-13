﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MantisTests
{
    public class AuthTestBase : TestBase
    {
        [OneTimeSetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("administrator", "root"));
        }
    }
}
