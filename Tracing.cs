// How to use command tracing in the JobTracker API

/*
The JobTracker API is implemented using HTTP web services. 

Sometimes it's useful to see the actual XML commands and responses that are being sent under the covers.

You can do this by passing an object that implements ICommandTracer to your Connection constructor.

There's even a built-in implementation that simply outputs to a Windows console:
*/

// use built-in command tracker
Connection conn = new Connection(JTURL + "api.aspx", UID, PWD, new SimpleConsoleCommandTracer(true, true));

// in a console application, the following will output an xml command and response to the console
var accts = conn.GetAccounts(new AccountFilter(),new PagingOptions(0, 2));

/* 

Often, printing to the console window isn't what you want. By implementing your own ICommandTracer,
you can output whereever you want. For example, the following uses the Debug output window instead

*/

    public class MyTracer : ICommandTracer
    {
        public void Command(string commandDescription, string command)
        {
            Debug.WriteLine(commandDescription); // using System.Diagnostics
            Debug.WriteLine(command);
        }

        public void CommandResponse(string commandDescription, string response)
        {
            Debug.WriteLine(commandDescription);
            Debug.WriteLine(response);
        }
    }
    
    Connection conn = new Connection(JTURL + "api.aspx", UID, PWD, new MyTracer());
    
    // now output goes to Debug.Output
    var accts = conn.GetAccounts(new AccountFilter(),new PagingOptions(0, 2));
