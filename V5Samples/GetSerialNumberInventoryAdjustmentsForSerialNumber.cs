            // Example of using GetSerialNumberInventoryAdjustmentsForSerialNumber
            // And GetSerialNumberInventoryAdjustmentsForSerialNumbers
            // This property exists starting in Version 5 of the JobTracker API
            // Prior to Version 5, you had to intuit this value from the total of all POs and other transactions

            // var DB = "yourdatabasename";
            var JTURL = "https://" + DB + ".moraware.net/";
            var UID = "api";
            // var PWD = "your password";

            Connection conn = new Connection(JTURL + "api.aspx", UID, PWD);
            conn.Connect();

            int[] snIds = new int[] {6900, 6903}; // Random Serial Numbers from my database. Yours will be different
            // also, note that these are Serial Number IDs, not Serial Number Names (which is what users think of as the Serial Number)

            var adjs = conn.GetSerialNumberInventoryAdjustmentsForSerialNumber(snIds[0]);
            foreach (var adj in adjs)
            {
                Console.WriteLine("Serial Number: {0} | Adjustment id: {1} | Adjustment quantity: {2}", 
                    adj.SerialNumber.SerialNumberName, 
                    adj.SerialNumberInventoryAdjustmentId,
                    adj.Quantity);
            }

            adjs = conn.GetSerialNumberInventoryAdjustmentsForSerialNumbers(snIds);
            foreach (var adj in adjs)
            {
                Console.WriteLine("Serial Number: {0} | Adjustment id: {1} | Adjustment quantity: {2}",
                    adj.SerialNumber.SerialNumberName,
                    adj.SerialNumberInventoryAdjustmentId,
                    adj.Quantity);
            }

            conn.Disconnect();
