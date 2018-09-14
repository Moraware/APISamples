            // Example of using GetJobs with filter
            // This method exists starting in Version 5 of the JobTracker API
            // Prior to Version 5, you had to llop through all jobs to find the ones you want

            // var DB = "yourdatabasename";
            var JTURL = "https://" + DB + ".moraware.net/";
            var UID = "api";
            // var PWD = "your password";

            Connection conn = new Connection(JTURL + "api.aspx", UID, PWD);
            conn.Connect();

            var po = new PagingOptions(0, int.MaxValue); // return all jobs at once

            // Name filter
            var jf = new JobFilter(); // by default, this will search the Job process - pass in another process if you wish
            jf.AddTextFilter(JobFilter.JobTextFilterFields_Enum.Name, new TextFilter("Jeff", false)); // find any jobs with "Jeff" in the name
            var jobs = conn.GetJobs(jf, po);
            foreach(var job in jobs) 
            {
                Console.WriteLine("Job ID: {0} | Job Name: {1}", job.JobId, job.JobName);
            }

            // Name filter - exact match
            jf = new JobFilter();
            jf.AddTextFilter(JobFilter.JobTextFilterFields_Enum.Name, new TextFilter("Sal Maglie", true)); // find all jobs named exactly Sal Maglie
            jobs = conn.GetJobs(jf, po);
            foreach (var job in jobs)
            {
                Console.WriteLine("Job ID: {0} | Job Name: {1}", job.JobId, job.JobName);
            }

            // Notes filter
            jf = new JobFilter();
            jf.AddTextFilter(JobFilter.JobTextFilterFields_Enum.Notes, new TextFilter("pink", false)); // find jobs with "pink" in the Job Notes field
            jobs = conn.GetJobs(jf, po);
            foreach (var job in jobs)
            {
                Console.WriteLine("Job ID: {0} | Job Name: {1}", job.JobId, job.JobName);
            }

            // Salesperson filter
            int[] salespeople = new int[] {8, 13}; // random salespeople from my system. Yours will be different
            jf = new JobFilter();
            jf.AddListOfValuesFilter(JobFilter.JobListOfValuesFilterFields_Enum.Salesperson, new ListOfValuesFilter(false, salespeople, false)); // find jobs with these salespeople
            jobs = conn.GetJobs(jf, po);
            foreach (var job in jobs)
            {
                Console.WriteLine("Job ID: {0} | Job Name: {1} | Job Status: {2}", job.JobId, job.JobName, job.JobStatus);
            }

            // Status filter
            // note that you can stack filters on top of each other - this adds job status to the existing salesperson filter from above
            jf.JobStatus = Job.JobStatus_Enum.jsComplete;
            jobs = conn.GetJobs(jf, po);
            foreach (var job in jobs)
            {
                Console.WriteLine("Job ID: {0} | Job Name: {1} | Job Status: {2}", job.JobId, job.JobName, job.JobStatus);
            }

            // Custom field filter
            int cf = 628; // random custom field id in my database. Yours will be different
            int[] values = new int[] {12526}; // random "list of values" field values from my database. Yours will be different
            jf = new JobFilter();
            jf.AddJobCustomFieldFilter(cf, new ListOfValuesFilter(false, values, false));
            jobs = conn.GetJobs(jf, po);
            foreach (var job in jobs)
            {
                Console.WriteLine("Job ID: {0} | Job Name: {1} | Job Status: {2}", job.JobId, job.JobName, job.JobStatus);
            }

            // View filter
            int viewId = 493; // random job view id from my system - just make a view in the UI and copy the view id from the URL
            jf = new JobFilter();
            jf.ViewId = viewId;
            jobs = conn.GetJobs(jf, po);
            foreach (var job in jobs)
            {
                Console.WriteLine("Job ID: {0} | Job Name: {1} | Job Status: {2}", job.JobId, job.JobName, job.JobStatus);
            }

            conn.Disconnect();
