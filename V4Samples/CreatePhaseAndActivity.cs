            conn.Connect();

            int nActivityType = 256; // an activity type in my database - yours will be completely different
            /////////////////////////// call conn.GetJobActivityTypes to find them
            int nActivityStatus = 3; // an activity status in my database - yours will be completely different
            /////////////////////////// call conn.GetJobActivityStatuses to find them
            int nJob = 6490;        // a random job in my database - yours will be completely different

            // Create a job phase - note that you need the job id but not the Job object
            // To use an existing phase instead, get the Job object and figure out which phase you want from job.JobPhases

            var jp = new JobPhase(nJob, "Phase 2");
            conn.CreateJobPhase(jp); 

            var ja = new JobActivity(nJob, nActivityType, nActivityStatus);
            ja.JobPhases.Add(jp);
            conn.CreateJobActivity(ja);
