            // Example of using GetJobsOfPurchaseOrders
            // This method exists starting in Version 5 of the JobTracker API
            // Prior to Version 5, there was no way to get this information from the API
            // See also GetPurchaseOrdersOfJobs

            // var DB = "yourdatabasename";
            var JTURL = "https://" + DB + ".moraware.net/";
            var UID = "api";
            // var PWD = "your password";

            Connection conn = new Connection(JTURL + "api.aspx", UID, PWD);
            conn.Connect();

            int[] poIds = new int[] {3756, 3754, 3703}; // Random POs from my database. Yours will be different

            var jobs = conn.GetJobsOfPurchaseOrders(poIds);
            foreach (var job in jobs)
            {
                Console.WriteLine("Job ID: {0} | Job Name: {1}", job.JobId, job.JobName);
            }

            conn.Disconnect();
