            // Example of using GetPurchaseOrdersOfJobs
            // This method exists starting in Version 5 of the JobTracker API
            // Prior to Version 5, there was no way to get this information from the API

            // var DB = "yourdatabasename";
            var JTURL = "https://" + DB + ".moraware.net/";
            var UID = "api";
            // var PWD = "your password";

            Connection conn = new Connection(JTURL + "api.aspx", UID, PWD);
            conn.Connect();

            int[] jobIds = new int[] {456, 590}; // Random jobs from my database. Yours will be different

            var pos = conn.GetPurchaseOrdersOfJobs(jobIds);
            foreach (var po in pos)
            {
                Console.WriteLine("PO Number: {0}", po.PurchaseOrderNumber);
            }

            conn.Disconnect();
