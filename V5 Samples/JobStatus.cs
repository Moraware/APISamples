            // Example of using Job.JobStatus
            // This property exists starting in Version 5 of the JobTracker API
            // Prior to Version 5, you have to loop through all activities on the job to determine the status

            // var DB = "yourdatabasename";
            var JTURL = "https://" + DB + ".moraware.net/";
            var UID = "api";
            // var PWD = "your password";

            Connection conn = new Connection(JTURL + "api.aspx", UID, PWD);
            conn.Connect();

            int jobid = 456; // a random job in my system - yours will be different

            var job = conn.GetJob(jobid);
            Console.WriteLine("Job {0} is {1}", job.JobName, job.JobStatus);

            if (job.JobStatus == Job.JobStatus_Enum.jsActive)
            {
                // do something
            }

            if (job.JobStatus == Job.JobStatus_Enum.jsComplete)
            {
                // do something
            }

            conn.Disconnect();
