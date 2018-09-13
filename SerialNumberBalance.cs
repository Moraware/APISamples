            // Example of using SerialNumber.Balance
            // This property exists starting in Version 5 of the JobTracker API
            // Prior to Version 5, you had to intuit this value from the total of all POs and other transactions

            // var DB = "yourdatabasename";
            var JTURL = "https://" + DB + ".moraware.net/";
            var UID = "api";
            // var PWD = "your password";

            Connection conn = new Connection(JTURL + "api.aspx", UID, PWD);
            conn.Connect();

            int snId = 6900; // a random Serial Number from my database. Yours will be different
            // also, note that this is the Serial Number ID, not the Serial Number Name (which is what users think of as the Serial Number)

            var sn = conn.GetSerialNumber(snId);
            Console.WriteLine("Serial Number: {0} | Balance: {1}", sn.SerialNumberName, sn.Balance);

            conn.Disconnect();
