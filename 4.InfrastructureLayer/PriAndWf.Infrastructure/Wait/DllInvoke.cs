using System;
using System.Runtime.InteropServices;

namespace PriAndWf.Infrastructure.Wait
{
    public class DllInvoke
    {
        #region LoadLibrary/GetProcAddress/FreeLibrary
        /// <summary>
        /// 装载动态链接库
        /// 原型 : HMODULE LoadLibrary(LPCTSTR lpFileName);
        /// </summary>
        /// <param name="lpFileName">动态链接库文件名（查找顺序 : 程序当前目录->System32目录->环境变量Path所设置路径）</param>
        /// <returns>函数库模块的句柄</returns>
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        /// <summary>
        /// 获取要引入的函数
        /// 原型 : FARPROC GetProcAddress(HMODULE hModule, LPCWSTR lpProcName);
        /// </summary>
        /// <param name="hModule">函数库模块的句柄</param>
        /// <param name="lpProcName">调用函数的名称</param>
        /// <returns>函数指针</returns>
        [DllImport("kernel32.dll")]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        /// <summary>
        /// 释放动态链接库
        /// 原型 : BOOL FreeLibrary(HMODULE hModule);
        /// </summary>
        /// <param name="hModule">需要释放的“函数库模块的句柄”</param>
        /// <returns>是否释放指定的动态链接库</returns>
        [DllImport("kernel32.dll")]
        static extern bool FreeLibrary(IntPtr hModule);
        #endregion

        private IntPtr hModule;
        public DllInvoke(string dllPath)
        {
            hModule = LoadLibrary(dllPath);
        }
        ~DllInvoke()
        {
            FreeLibrary(hModule);
        }

        public Delegate Invoke(string funName, Type type)
        {
            IntPtr hFun = GetProcAddress(hModule, funName);
            return Marshal.GetDelegateForFunctionPointer(hFun, type);
        }
    }
}
