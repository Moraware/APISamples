            // Example of using AddPurchaseOrderToJob and AddPurchaseOrdersToJob
            // These methods exists starting in Version 5 of the JobTracker API
            // Prior to Version 5, there was no way to accomplish this using the API

            // var DB = "yourdatabasename";
            var JTURL = "https://" + DB + ".moraware.net/";
            var UID = "api";
            // var PWD = "your password";

            Connection conn = new Connection(JTURL + "api.aspx", UID, PWD);
            conn.Connect();

            int[] poIds = new int[] {3756, 3754, 3703}; // Random POs from my database. Yours will be different
            int jobId = 6405;

            // add 1 PO
            conn.AddPurchaseOrderToJob(poIds[0], jobId);

            // add many POs
            conn.AddPurchaseOrdersToJob(poIds, jobId);

            conn.Disconnect();
