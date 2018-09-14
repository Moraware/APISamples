            // Example of using MoveJobToAccount
            // This method exists starting in Version 5 of the JobTracker API
            // Prior to Version 5, there was no way to accomplish this with the API

            // var DB = "yourdatabasename";
            var JTURL = "https://" + DB + ".moraware.net/";
            var UID = "api";
            // var PWD = "your password";

            Connection conn = new Connection(JTURL + "api.aspx", UID, PWD);
            conn.Connect();

            int jobId = 6405, acctId = 278; // random job and account from my database. Yours will be different

            conn.MoveJobToAccount(jobId, acctId);

            conn.Disconnect();
