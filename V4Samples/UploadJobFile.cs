// Here's the simplest way to upload a file to a job

            var jf = new JobFile(6404, "my test file.txt"); // job id, name of file after uploaded
            var fi = new FileInfo("c:\\data\\test.txt"); // full pathname of file to upload

            conn.UploadJobFile(jf, fi, false);

// -------------

// OPTIONAL
// If you want to get status updates while file is uploading, implement a class like this and 
// send an instance of it to UploadJobFile

    class StatusUpdater : IFileTransferMonitor {
        public void UpdateStatus(FileTransferProgressEvent e) {
            // do something with status 
        }
    }
