namespace InsuranceAPIs.Logger
{
    public class ErrorHandler
    {
        public static void APIWriteError(Exception exp, string reqtRefNo, string quoteRefNo, string MethodName)
        {
            try
            {
                string ErrorFile = "";
                string ErrorPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Error\\";

                bool exists = System.IO.Directory.Exists(ErrorPath);

                if (!exists)
                    System.IO.Directory.CreateDirectory(ErrorPath);

                ErrorFile = ErrorPath + "APIError_" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                if (!File.Exists(ErrorFile))
                {
                    File.Create(ErrorFile).Close();
                }
                using (StreamWriter w = File.AppendText(ErrorFile))
                {
                    w.WriteLine("Error Details : ");
                    w.WriteLine("{0}", DateTime.Now.ToString("dd-MM-yy hh:mm:ss"));
                    w.WriteLine("\n");
                    w.WriteLine("Method Name : " + MethodName);
                    w.WriteLine("REFERENCE NO : " + reqtRefNo);
                    w.WriteLine("QUOTE REFERENCE NO : " + quoteRefNo);
                    w.WriteLine("ERROR DESCRIPTION :  " + exp.Message);
                    w.WriteLine("ERROR DESCRIPTION :  " + exp.InnerException);
                    w.WriteLine("ERROR SOURCE : " + "");
                    w.WriteLine("TARGET SITE : " + exp.TargetSite);
                    w.WriteLine("STACK TRACE : " + exp.StackTrace);
                    w.WriteLine("*******************************************************************************************************************************************************");
                    w.Flush();
                    w.Close();
                }

            }
            catch (Exception ex)
            {
                //WriteError(ex, string.Empty, string.Empty, "WriteError");
            }

        }
        public static void APIWriteLog(string log_header, string request, string reqtRefNo, string response)
        {
            try
            {
                string LogFile = "";
                string LogPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Logs\\";

                bool exists = System.IO.Directory.Exists(LogPath);

                if (!exists)
                    System.IO.Directory.CreateDirectory(LogPath);


                LogFile = LogPath + "APILog_" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                if (!File.Exists(LogFile))
                {
                    File.Create(LogFile).Close();
                }
                using (StreamWriter w = File.AppendText(LogFile))
                {
                    w.WriteLine("LOG ENTRY : ");
                    w.WriteLine("{0}", DateTime.Now.ToString("dd-MM-yy hh:mm:ss"));
                    w.WriteLine("\n");
                    w.WriteLine("REFERENCE NO : " + reqtRefNo);
                    w.WriteLine("LOG FOR: " + log_header);
                    w.WriteLine("Request :  " + request);
                    w.WriteLine("Response :  " + response);
                    w.WriteLine("*******************************************************************************************************************************************************");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                APIWriteError(ex, string.Empty, string.Empty, "WriteLog");
            }
        }

        public static void WriteError(Exception exp, string reqtRefNo, string quoteRefNo, string MethodName)
        {
            try
            {
                string ErrorFile = "";
                string ErrorPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Error\\";

                bool exists = System.IO.Directory.Exists(ErrorPath);

                if (!exists)
                    System.IO.Directory.CreateDirectory(ErrorPath);

                ErrorFile = ErrorPath + "Error_" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                if (!File.Exists(ErrorFile))
                {
                    File.Create(ErrorFile).Close();
                }
                using (StreamWriter w = File.AppendText(ErrorFile))
                {
                    w.WriteLine("Error Details : ");
                    w.WriteLine("{0}", DateTime.Now.ToString("dd-MM-yy hh:mm:ss"));
                    w.WriteLine("\n");
                    w.WriteLine("Method Name : " + MethodName);
                    w.WriteLine("REFERENCE NO : " + reqtRefNo);
                    w.WriteLine("QUOTE REFERENCE NO : " + quoteRefNo);
                    w.WriteLine("ERROR DESCRIPTION :  " + exp.Message);
                    w.WriteLine("ERROR DESCRIPTION :  " + exp.InnerException);
                    w.WriteLine("ERROR SOURCE : " + "");
                    w.WriteLine("TARGET SITE : " + exp.TargetSite);
                    w.WriteLine("STACK TRACE : " + exp.StackTrace);
                    w.WriteLine("*******************************************************************************************************************************************************");
                    w.Flush();
                    w.Close();
                }

            }
            catch (Exception ex)
            {
                //WriteError(ex, string.Empty, string.Empty, "WriteError");
            }

        }
        public static void WriteLog(string log_header, string log_desc, string reqtRefNo, string quoteRefNo)
        {
            try
            {
                string LogFile = "";
                string LogPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Logs\\";

                bool exists = System.IO.Directory.Exists(LogPath);

                if (!exists)
                    System.IO.Directory.CreateDirectory(LogPath);


                LogFile = LogPath + "Log_" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                if (!File.Exists(LogFile))
                {
                    File.Create(LogFile).Close();
                }
                using (StreamWriter w = File.AppendText(LogFile))
                {
                    w.WriteLine("LOG ENTRY : ");
                    w.WriteLine("{0}", DateTime.Now.ToString("dd-MM-yy hh:mm:ss"));
                    w.WriteLine("\n");
                    w.WriteLine("REFERENCE NO : " + reqtRefNo);
                    w.WriteLine("LOG FOR: " + log_header);
                    w.WriteLine("DESCRIPTION :  " + log_desc);
                    w.WriteLine("DESCRIPTION1 :  " + quoteRefNo);
                    w.WriteLine("*******************************************************************************************************************************************************");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                WriteError(ex, string.Empty, string.Empty, "WriteLog");
            }
        }
    }
}
