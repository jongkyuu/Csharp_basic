using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace UseCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            //[DllImport("kernel32.dll", SetLastError = true)]
            //[return: MarshalAs(UnmanagedType.Bool)]
            //static extern bool AllocConsole();

            try
            {
                //AllocConsole();
                ProcessStartInfo proInfo = new ProcessStartInfo();
                Process pro = new Process();

                // 실행할 파일명 입력 
                //proInfo.FileName = "cmd.exe";
                proInfo.FileName = @"cmd";
                // cmd창 보이기(false). 보이지않기(true)
                proInfo.CreateNoWindow = true;
                // ??
                proInfo.UseShellExecute = false;
                // cmd 데이터 받기
                proInfo.RedirectStandardOutput = true;
                // cmd 데이터 보내기
                proInfo.RedirectStandardInput = true;
                // cmd 오류내용 받기
                proInfo.RedirectStandardError = true;

                // Process 실행 정보 추가
                pro.StartInfo = proInfo;
                // Process 시작
                pro.Start();

                // cmd에 보낼 명령어를 입력
                pro.StandardInput.WriteLine(@"dir/w");
                pro.StandardInput.Close();

                // 결과값을 리턴
                string resultValue = pro.StandardOutput.ReadToEnd();
                pro.WaitForExit();
                pro.Close();


                // 결과값 확인
                Console.WriteLine(resultValue);

                Console.ReadLine();
            }
            catch (Win32Exception w)
            {
                Console.WriteLine(w.Message);
                Console.WriteLine(w.ErrorCode.ToString());
                Console.WriteLine(w.NativeErrorCode.ToString());
                Console.WriteLine(w.StackTrace);
                Console.WriteLine(w.Source);
                Exception e = w.GetBaseException();
                Console.WriteLine(e.Message);
            }
        }
    }
}
