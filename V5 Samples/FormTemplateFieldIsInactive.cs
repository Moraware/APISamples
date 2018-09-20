            // Example of using FormTemplateField.IsInactive
            // This property exists starting in Version 5 of the JobTracker API
            // Prior to Version 5, there was no way to get this information from the API

            // var DB = "yourdatabasename";
            var JTURL = "https://" + DB + ".moraware.net/";
            var UID = "api";
            // var PWD = "your password";

            Connection conn = new Connection(JTURL + "api.aspx", UID, PWD);
            conn.Connect();

            int templateId = 1111; // a random form template from my database. Yours will be different

            var formTemplate = conn.GetFormTemplate(templateId, true);
            foreach (var field in formTemplate.FormFields)
            {
                Console.WriteLine("Field Id: {0} | Field Name: {1} | Inactive?: {2}",
                    field.FormTemplateFieldId,
                    field.FormTemplateFieldName,
                    field.IsInactive);
            }

            conn.Disconnect();
