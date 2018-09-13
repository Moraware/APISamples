            // Example of using Account.CreateSeparateAddressForJob
            // This property exists starting in Version 5 of the JobTracker API
            // Prior to Version 5, there was no way to get/set this value from the API

            // var DB = "yourdatabasename";
            var JTURL = "https://" + DB + ".moraware.net/";
            var UID = "api";
            // var PWD = "your password";

            Connection conn = new Connection(JTURL + "api.aspx", UID, PWD);
            conn.Connect();

            int accountId = 291; // a random Account from my database. Yours will be different

            var account = conn.GetAccount(accountId);
            //read value
            Console.WriteLine("Account: {0} | CreateSeparateAddressForJob: {1}", account.AccountName, account.CreateSeparateAddressForJob);
            //change value
            account.CreateSeparateAddressForJob = !account.CreateSeparateAddressForJob;
            conn.UpdateAccount(account);
            //read value
            Console.WriteLine("Account: {0} | CreateSeparateAddressForJob: {1}", account.AccountName, account.CreateSeparateAddressForJob);

            conn.Disconnect();
