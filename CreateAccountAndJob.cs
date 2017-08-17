            conn.Connect();
    
            // In order to create a job, first you need to get an account id
            // You should probably check to see if it exists first

            Account a;
            string accountName = "Foo";
            int accountId = -1; // not a meaningful account id - must be set before using

            var acts = conn.GetAccounts(accountName);
            if (acts.Count == 0) {
                // account doesn't exist, so create it
                a = new Account(accountName);
                accountId = conn.CreateAccount(a); // this is what writes to the db and causes the object to exist online
            }
            else if (acts.Count == 1) {
                // account exists, so use it
                a = acts[0];
                accountId = a.AccountId;
            }
            else {
                // more than one account exists with the same name, so figure out something else
                return;
            }

            // Now you can create the job

            string jobName = "Bar";
            int processID = 1; // if anything other than Job, you'll have to go spelunking for this
            int jobID;

            Job j = new Job(accountId, jobName, processID);
            // fill in other values
            j.Address = new Address(); // if you want to fill in the address, you have to create an object first
            j.Address.AddressLine1 = "1604 Willis NW";
            j.Address.City = "Grand Rapids";
            j.CustomFieldValues.SetFieldValue(597, "S12345"); // I simply did a View Page Source on the custom fields page to figure out what the id of a custom field was in my system
                                                              // yours will be different
                                                              // to be precise, call conn.GetCustomJobFieldTypes (false) and explore the results
            jobID = conn.CreateJob(j); // this is what writes to the db and causes the object to exist online

            // note, you can add the jobId onto your URL to get a link to the job
            // https://patrick.moraware.net/d.aspx?wp=2&jobId=
