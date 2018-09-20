            // Example of using GetSerialNumberAllocations
            // This method exists starting in Version 5 of the JobTracker API
            // Prior to Version 5, you had to loop through all POs and all jobs to get this info

            // var DB = "yourdatabasename";
            var JTURL = "https://" + DB + ".moraware.net/";
            var UID = "api";
            // var PWD = "your password";

            Connection conn = new Connection(JTURL + "api.aspx", UID, PWD);
            conn.Connect();

            int[] snIds = new int[] {6520, 6525, 6518}; // Random SNs from my database. Yours will be different

            var alls = conn.GetSerialNumberAllocations(snIds);
            foreach (var all in alls)
            {
                Console.WriteLine("Job: {0} | SN: {1} | Quantity: {2}", all.JobName, all.SerialNumberName, all.Quantity);
            }

            conn.Disconnect();
